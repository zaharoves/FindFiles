using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindFileInDirectory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FindTimer.Interval = 10;
            FindTimer.Tick += new EventHandler(FindTimer_Tick);

            //Устанавливаем справку для поля шаблона файла
            ToolTip templateHelpTooltip = new ToolTip();
            templateHelpTooltip.AutoPopDelay = 20000;
            templateHelpTooltip.SetToolTip(templateHelpLabel, Consts.TemplateHelp);

            //Устанавливаем справку для поля набора символов, которые могут содержаться в названии файла
            ToolTip symbolsHelpTooltip = new ToolTip();
            symbolsHelpTooltip.AutoPopDelay = 20000;
            symbolsHelpTooltip.SetToolTip(symbolsHelpLabel, Consts.SymbolsHelp);

            //Устанавливаем значения полей, которые были при закрытии программы в последний раз
            directoryTextBox.Text = Properties.Settings.Default.Directory;
            templateTextBox.Text = Properties.Settings.Default.Template;
            symbolsTextBox.Text = Properties.Settings.Default.Symbols;

            FillTreeDriveNodes();
        }

        /// <summary>
        /// Таймер, который отслеживает время, затраченное на поиск файлов
        /// </summary>
        private System.Windows.Forms.Timer FindTimer { get; set; } = new System.Windows.Forms.Timer();

        /// <summary>
        /// Срабатывает при каждом тике таймера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan findTime = new TimeSpan();
            findTime = DateTime.Now - StartDate - WaitTime;
            timerLabel.Text = $"{findTime.Hours}:{findTime.Minutes}:{findTime.Seconds}:{findTime.Milliseconds}";
        }

        /// <summary>
        /// Дата и время начала поиска
        /// </summary>
        private DateTime StartDate { get; set; }

        /// <summary>
        /// Дата и время нажатия кнопки "Пауза"
        /// </summary>
        private DateTime PauseDate { get; set; }

        /// <summary>
        /// Промежуток времени, в течение которого поиск был поставлен на паузу
        /// </summary>
        private TimeSpan WaitTime { get; set; }

        /// <summary>
        /// Количество найденных файлов
        /// </summary>
        public long CountFoundFiles { get; set; }

        /// <summary>
        /// Директория для поиска
        /// </summary>
        private FolderBrowserDialog FolderPath { get; } = new FolderBrowserDialog();

        /// <summary>
        /// Директория, в которой производится поиск
        /// </summary>
        private string SearchDirectory { get; set; }

        /// <summary>
        /// Шаблон файла для поиска
        /// </summary>
        private string SearchTemplate { get; set; }

        /// <summary>
        /// Наборы cимволов, которые могут содержаться в файлах при поиске
        /// </summary>
        private string SearchCharsSet { get; set; }

        /// <summary>
        /// Событие при нажатии кнопки "Обзор"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void directoryButton_Click(object sender, EventArgs e)
        {
            try
            {
                FolderPath.ShowNewFolderButton = false;
                FolderPath.Description = Consts.DirectoryDescription;

                if (FolderPath.ShowDialog() == DialogResult.OK)
                {
                    directoryTextBox.Text = FolderPath.SelectedPath;
                    SearchDirectory = FolderPath.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                SetAfterError(ex.Message);
            }
        }


        /// <summary>
        /// Событие для паузы поиска файлов
        /// </summary>
        private ManualResetEvent FindFilesEvent { get; set; } = new ManualResetEvent(true);

        /// <summary>
        /// Поток поиска файлов
        /// </summary>
        private Task FindFilesTask { get; set; }

        public CancellationTokenSource CancelFindTokenSource { get; set; }
        public CancellationToken CancelFindToken { get; set; }


        /// <summary>
        /// Событие при нажатии кнопки "Найти"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void findButton_Click(object sender, EventArgs e)
        {
            try
            {
                errorTextBox.Visible = false;
                findFilesTreeView.Height = 406;

                FindTimer.Dispose();
                timerLabel.Text = Consts.TimerZeroValue;
                CountFoundFiles = 0;
                countFoundFilesLabel.Text = "0";

                findFilesTreeView.Nodes.Clear();
                FillTreeDriveNodes();

                templateTextBox.ReadOnly = true;
                symbolsTextBox.ReadOnly = true;

                SearchTemplate = templateTextBox.Text;
                SearchCharsSet = symbolsTextBox.Text;

                StartDate = DateTime.Now;
                WaitTime = System.TimeSpan.Zero;
                FindTimer.Start();

                CancelFindTokenSource = new CancellationTokenSource();
                CancelFindToken = CancelFindTokenSource.Token;

                FindFilesEvent.Set();
                FindFilesTask = new Task(() => FindFiles(FindFilesEvent));
                FindFilesTask.Start();

                EnableButtons(false, false, true, true);
                ChangeStatus(Consts.Statuses.Searching, Color.RoyalBlue);
            }
            catch (Exception ex)
            {
                SetAfterError(ex.Message);
            }
        }


        /// <summary>
        /// Режим работы кнопки "Пауза"
        /// True - Поиск на паузе
        /// False - Поиск продолжается
        /// </summary>
        private bool SearchOnPause { get; set; } = false;

        /// <summary>
        /// Событие при нажатии кнопки "Пауза/Продолжить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pauseButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!SearchOnPause)
                {
                    PauseDate = DateTime.Now;

                    FindTimer.Stop();
                    FindFilesEvent.Reset();

                    pauseButton.Text = Consts.Continue;
                    SearchOnPause = true;
                    ChangeStatus(Consts.Statuses.SearchPause, Color.Orange);
                }
                else
                {
                    WaitTime += DateTime.Now - PauseDate;

                    FindTimer.Start();
                    FindFilesEvent.Set();

                    pauseButton.Text = Consts.Pause;
                    SearchOnPause = false;
                    ChangeStatus(Consts.Statuses.Searching, Color.RoyalBlue);

                }
            }
            catch (Exception ex)
            {
                SetAfterError(ex.Message);
            }
        }


        /// <summary>
        /// Событие при нажатии кнопки "Стоп"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stopButton_Click(object sender, EventArgs e)
        {
            try
            {
                CancelFindTokenSource.Cancel();
                CancelFindTokenSource.Dispose();
                CancelFindTokenSource = null;

                SetDefaultValues();

                EnableButtons(true, true, false, false);
                ChangeStatus(Consts.Statuses.SearchStop, Color.Orange);

            }
            catch (Exception ex)
            {
                SetAfterError(ex.Message);
            }
        }

        /// <summary>
        /// Устанавливает значения по умолчанию у полей
        /// </summary>
        public void SetDefaultValues()
        {
            this.Invoke(new Action(() =>
            {
                FindTimer.Dispose();
                timerLabel.Text = Consts.TimerZeroValue;

                templateTextBox.ReadOnly = false;
                symbolsTextBox.ReadOnly = false;

                CountFoundFiles = 0;
                countFoundFilesLabel.Text = "0";
                resultTextBox.Text = String.Empty;

                pauseButton.Text = Consts.Pause;
                SearchOnPause = false;
            }));

        }

        /// <summary>
        /// Действия после возникновения ошибки
        /// </summary>
        /// <param name="errorMessage"></param>
        private void SetAfterError(string errorMessage)
        {
            ChangeStatus(Consts.Statuses.Error, Color.Red);

            FindTimer.Stop();

            this.Invoke(new Action(() =>
            {
                errorTextBox.Text = $"Текст ошибки: {errorMessage}";
                errorTextBox.Visible = true;
                findFilesTreeView.Height -= errorTextBox.Height;
                templateTextBox.ReadOnly = false;
                symbolsTextBox.ReadOnly = false;
                EnableButtons(true, true, false, false);

            }));

        }


        /// <summary>
        /// Поиск файлов
        /// </summary>
        /// <param name="manualEvent"></param>
        private void FindFiles(object manualEvent)
        {
            try
            {
                SearchDirectory = directoryTextBox.Text;

                if (SearchTemplate.Replace(" ", String.Empty) != String.Empty)
                    RecursiveFileSearch(SearchDirectory, SearchTemplate);
                else
                    RecursiveFileSearch(SearchDirectory);

                if (CancelFindToken.IsCancellationRequested)
                {
                    SetDefaultValues();
                    return;
                }

                FindTimer.Stop();

                this.Invoke(new Action(() =>
                {
                    ChangeStatus(Consts.Statuses.SearchCompleted, Color.Green);

                    CountFoundFiles = 0;
                    resultTextBox.Text = String.Empty;

                    templateTextBox.ReadOnly = false;
                    symbolsTextBox.ReadOnly = false;

                    EnableButtons(true, true, false, false);
                }));

            }
            catch (Exception ex)
            {
                SetAfterError(ex.Message);
            }
        }

        /// <summary>
        /// Рекурсивный поиск файлов
        /// </summary>
        /// <param name="searchDirectory">Директория, в которой ведется поиск</param>
        private void RecursiveFileSearch(string searchDirectory)
        {
            try
            {
                string[] folders = Directory.GetDirectories(searchDirectory);
                foreach (string folder in folders)
                {
                    if (CancelFindToken.IsCancellationRequested)
                    {
                        SetDefaultValues();
                        return;
                    }
                    RecursiveFileSearch(folder);
                }

                string[] files = Directory.GetFiles(searchDirectory);

                foreach (string filename in files)
                {
                    if (CancelFindToken.IsCancellationRequested)
                    {
                        SetDefaultValues();
                        return;
                    }

                    bool fileIsChecked = false;
                    while (FindFilesEvent.WaitOne() && !fileIsChecked)
                    {
                        //Отбражение файла, который в данный момент проверяется
                        this.Invoke(new Action(() => { resultTextBox.Text = filename; }));

                        if (SearchCharsSet.Replace(" ", String.Empty) == String.Empty ||
                            SearchCharsSet.Replace(" ", String.Empty) != String.Empty && CheckSymbols(filename))
                        {
                            DisplayInTree(filename);

                            //Прибавляем к числу найденных файлов 1
                            CountFoundFiles++;
                            this.Invoke(new Action(() => { countFoundFilesLabel.Text = CountFoundFiles.ToString(); }));
                        }
                        fileIsChecked = true;
                    }
                }
            }
            catch (UnauthorizedAccessException) { }
        }

        /// <summary>
        /// Рекурсивный поиск файлов
        /// </summary>
        /// <param name="searchDirectory">Директория, в которой ведется поиск</param>
        /// <param name="searchTemplate">Шаблон для поиска файлов</param>
        private void RecursiveFileSearch(string searchDirectory, string searchTemplate)
        {
            try
            {
                string[] folders = Directory.GetDirectories(searchDirectory);
                foreach (string folder in folders)
                {
                    if (CancelFindToken.IsCancellationRequested)
                    {
                        SetDefaultValues();
                        return;
                    }
                    RecursiveFileSearch(folder, searchTemplate);
                }

                string[] files = Directory.GetFiles(searchDirectory, searchTemplate);

                foreach (string filename in files)
                {
                    if (CancelFindToken.IsCancellationRequested)
                    {
                        SetDefaultValues();
                        return;
                    }

                    bool fileIsChecked = false;
                    while (FindFilesEvent.WaitOne() && !fileIsChecked)
                    {
                        //Отбражение файла, который в данный момент проверяется
                        this.Invoke(new Action(() => { resultTextBox.Text = filename; }));

                        if (SearchCharsSet.Replace(" ", String.Empty) == String.Empty ||
                            SearchCharsSet.Replace(" ", String.Empty) != String.Empty && CheckSymbols(filename))
                        {
                            DisplayInTree(filename);

                            //Прибавляем к числу найденных файлов 1
                            CountFoundFiles++;
                            this.Invoke(new Action(() => { countFoundFilesLabel.Text = CountFoundFiles.ToString(); }));
                        }
                        fileIsChecked = true;
                    }
                }
            }

            catch (UnauthorizedAccessException) { }
        }

        /// <summary>
        /// Проверен ли файл на наличие набора символов в названии
        /// </summary>
        private bool SymbolsChecked { get; set; }

        /// <summary>
        /// Проверяет файл на наличие наборов символов
        /// </summary>
        /// <param name="filename">Полное имя файла</param>
        /// <returns>Возвращает true, если файл прошел проверку на наличие наборов символов. Иначе вовращает false.</returns>
        private bool CheckSymbols(string filename)
        {
            SymbolsChecked = true;

            string fileName = filename.Split('\\')[filename.Split('\\').Length - 1];
            string[] symbolsArray = SearchCharsSet.Split('*');

            foreach (string symbols in symbolsArray)
                SymbolsChecked = SymbolsChecked && fileName.Contains(symbols);

            return SymbolsChecked;
        }


        /// <summary>
        /// Отображает файл в дереве
        /// </summary>
        /// <param name="filename">Полное имя файла</param>
        private void DisplayInTree(string filename)
        {
            string[] foldersNames = filename.Split('\\');

            TreeNode rootNode = new TreeNode();
            rootNode = GetDiskNode(filename);

            TreeNode[] childNodeArray;
            bool isFirstCheck = true;

            foreach (string folderName in foldersNames)
            {
                if (!isFirstCheck)
                {
                    childNodeArray = rootNode.Nodes.Find(folderName, false);
                    bool isFound = childNodeArray.Length != 0;

                    if (!isFound)
                    {
                        findFilesTreeView.Invoke(new Action(() =>
                        {
                            rootNode.Nodes.Add(folderName, folderName);
                            rootNode = rootNode.LastNode;
                        }));
                    }
                    else if (isFound)
                        findFilesTreeView.Invoke(new Action(() => { rootNode = childNodeArray[0]; }));
                }
                isFirstCheck = false;
            }
        }


        /// <summary>
        /// Предоставляет ноду диска, в котором находится файл
        /// </summary>
        /// <param name="filepath">Полный путь файла</param>
        /// <returns>Ноду диска, в котором находится файл</returns>
        private TreeNode GetDiskNode(string filepath)
        {
            string[] pathFolders = filepath.Split('\\');
            TreeNode[] disk = findFilesTreeView.Nodes.Find(pathFolders[0], true);
            return disk[0];
        }

        /// <summary>
        /// Изменить статус поиска файлов
        /// </summary>
        /// <param name="status">Текст нового статуса</param>
        /// <param name="foreColor">Цвет текста</param>
        private void ChangeStatus(string status, Color foreColor)
        {
            statusLabel.Invoke(new Action(() =>
            {
                statusLabel.ForeColor = foreColor;
                statusLabel.Text = status;
            }));
        }

        /// <summary>
        /// Разрешает/запрещает нажатие кнопок. true - предоставить управление, false - запретить управление.
        /// </summary>
        /// <param name="directoryButtonMode">Режим управления кнопки "Обзор"</param>
        /// <param name="findButtonMode">Режим управления кнопки "Найти"</param>
        /// <param name="pauseButtonMode">Режим управления кнопки "Пауза/Продолжить"</param>
        /// <param name="stopButtonMode">Режим управления кнопки "Стоп"</param>
        private void EnableButtons(bool directoryButtonMode, bool findButtonMode, bool pauseButtonMode, bool stopButtonMode)
        {
            this.directoryButton.Enabled = directoryButtonMode;
            this.findButton.Enabled = findButtonMode;
            this.pauseButton.Enabled = pauseButtonMode;
            this.stopButton.Enabled = stopButtonMode;
        }

        /// <summary>
        /// Заполнят дерево нодами дисков
        /// </summary>
        private void FillTreeDriveNodes()
        {
            try
            {
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    TreeNode driveNode = new TreeNode { Text = drive.Name.Replace(@"\", ""), Name = drive.Name.Replace(@"\", "") };
                    findFilesTreeView.Nodes.Add(driveNode);
                }
            }
            catch (Exception ex) 
            {
                SetAfterError(ex.Message);
            }
        }


        /// <summary>
        /// При закрытии программы сохраняет директорию, шаблон файла и набор символов, 
        /// который может содержаться в файлах, для последующего запуска программы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindFilesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Directory = directoryTextBox.Text;
            Properties.Settings.Default.Template = templateTextBox.Text;
            Properties.Settings.Default.Symbols = symbolsTextBox.Text;
            Properties.Settings.Default.Save();
        }
    }
}

