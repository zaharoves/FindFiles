namespace FindFileInDirectory
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.directoryButton = new System.Windows.Forms.Button();
            this.directoryTextBox = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.directoryNameLabel = new System.Windows.Forms.Label();
            this.templateNameLabel = new System.Windows.Forms.Label();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.symbolsNameLabel = new System.Windows.Forms.Label();
            this.templateTextBox = new System.Windows.Forms.TextBox();
            this.findButton = new System.Windows.Forms.Button();
            this.timerLabel = new System.Windows.Forms.Label();
            this.timerNameLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.countFoundFilesNameLabel = new System.Windows.Forms.Label();
            this.countFoundFilesLabel = new System.Windows.Forms.Label();
            this.pauseButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.statusNameLabel = new System.Windows.Forms.Label();
            this.symbolsTextBox = new System.Windows.Forms.TextBox();
            this.findFilesTreeView = new System.Windows.Forms.TreeView();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.templateHelpLabel = new System.Windows.Forms.Label();
            this.symbolsHelpLabel = new System.Windows.Forms.Label();
            this.ResultsTreeNameLabel = new System.Windows.Forms.Label();
            this.SearchParameterNameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // directoryButton
            // 
            this.directoryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.directoryButton.Location = new System.Drawing.Point(414, 84);
            this.directoryButton.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.directoryButton.Name = "directoryButton";
            this.directoryButton.Size = new System.Drawing.Size(124, 24);
            this.directoryButton.TabIndex = 0;
            this.directoryButton.Text = "Обзор";
            this.directoryButton.UseVisualStyleBackColor = true;
            this.directoryButton.Click += new System.EventHandler(this.directoryButton_Click);
            // 
            // directoryTextBox
            // 
            this.directoryTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.directoryTextBox.Location = new System.Drawing.Point(15, 55);
            this.directoryTextBox.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.directoryTextBox.Name = "directoryTextBox";
            this.directoryTextBox.ReadOnly = true;
            this.directoryTextBox.Size = new System.Drawing.Size(523, 23);
            this.directoryTextBox.TabIndex = 1;
            // 
            // directoryNameLabel
            // 
            this.directoryNameLabel.AutoSize = true;
            this.directoryNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.directoryNameLabel.Location = new System.Drawing.Point(12, 35);
            this.directoryNameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.directoryNameLabel.Name = "directoryNameLabel";
            this.directoryNameLabel.Size = new System.Drawing.Size(236, 17);
            this.directoryNameLabel.TabIndex = 2;
            this.directoryNameLabel.Text = "Выберите директорию для поиска";
            // 
            // templateNameLabel
            // 
            this.templateNameLabel.AutoSize = true;
            this.templateNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.templateNameLabel.Location = new System.Drawing.Point(13, 123);
            this.templateNameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.templateNameLabel.Name = "templateNameLabel";
            this.templateNameLabel.Size = new System.Drawing.Size(151, 17);
            this.templateNameLabel.TabIndex = 5;
            this.templateNameLabel.Text = "Шаблон имени файла";
            // 
            // resultTextBox
            // 
            this.resultTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultTextBox.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.resultTextBox.Location = new System.Drawing.Point(15, 298);
            this.resultTextBox.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.resultTextBox.Multiline = true;
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.ReadOnly = true;
            this.resultTextBox.Size = new System.Drawing.Size(523, 43);
            this.resultTextBox.TabIndex = 4;
            // 
            // symbolsNameLabel
            // 
            this.symbolsNameLabel.AutoSize = true;
            this.symbolsNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.symbolsNameLabel.Location = new System.Drawing.Point(12, 187);
            this.symbolsNameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.symbolsNameLabel.Name = "symbolsNameLabel";
            this.symbolsNameLabel.Size = new System.Drawing.Size(372, 17);
            this.symbolsNameLabel.TabIndex = 8;
            this.symbolsNameLabel.Text = "Набор символов, который может содержаться в файле";
            // 
            // templateTextBox
            // 
            this.templateTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.templateTextBox.Location = new System.Drawing.Point(15, 147);
            this.templateTextBox.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.templateTextBox.Name = "templateTextBox";
            this.templateTextBox.Size = new System.Drawing.Size(524, 23);
            this.templateTextBox.TabIndex = 7;
            // 
            // findButton
            // 
            this.findButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.findButton.Location = new System.Drawing.Point(414, 347);
            this.findButton.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(125, 24);
            this.findButton.TabIndex = 9;
            this.findButton.Text = "Найти";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timerLabel.Location = new System.Drawing.Point(128, 354);
            this.timerLabel.Margin = new System.Windows.Forms.Padding(0);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(52, 17);
            this.timerLabel.TabIndex = 12;
            this.timerLabel.Text = "0:0:0:0";
            // 
            // timerNameLabel
            // 
            this.timerNameLabel.AutoSize = true;
            this.timerNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timerNameLabel.Location = new System.Drawing.Point(12, 354);
            this.timerNameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.timerNameLabel.Name = "timerNameLabel";
            this.timerNameLabel.Size = new System.Drawing.Size(104, 17);
            this.timerNameLabel.TabIndex = 13;
            this.timerNameLabel.Text = "Время поиска:";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusLabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.statusLabel.Location = new System.Drawing.Point(83, 414);
            this.statusLabel.Margin = new System.Windows.Forms.Padding(0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(184, 17);
            this.statusLabel.TabIndex = 14;
            this.statusLabel.Text = "Выбор параметров поиска";
            // 
            // countFoundFilesNameLabel
            // 
            this.countFoundFilesNameLabel.AutoSize = true;
            this.countFoundFilesNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.countFoundFilesNameLabel.Location = new System.Drawing.Point(12, 384);
            this.countFoundFilesNameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.countFoundFilesNameLabel.Name = "countFoundFilesNameLabel";
            this.countFoundFilesNameLabel.Size = new System.Drawing.Size(220, 17);
            this.countFoundFilesNameLabel.TabIndex = 16;
            this.countFoundFilesNameLabel.Text = "Количество найденных файлов:";
            // 
            // countFoundFilesLabel
            // 
            this.countFoundFilesLabel.AutoSize = true;
            this.countFoundFilesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.countFoundFilesLabel.Location = new System.Drawing.Point(250, 384);
            this.countFoundFilesLabel.Margin = new System.Windows.Forms.Padding(0);
            this.countFoundFilesLabel.Name = "countFoundFilesLabel";
            this.countFoundFilesLabel.Size = new System.Drawing.Size(16, 17);
            this.countFoundFilesLabel.TabIndex = 15;
            this.countFoundFilesLabel.Text = "0";
            // 
            // pauseButton
            // 
            this.pauseButton.Enabled = false;
            this.pauseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pauseButton.Location = new System.Drawing.Point(414, 377);
            this.pauseButton.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(124, 24);
            this.pauseButton.TabIndex = 17;
            this.pauseButton.Text = "Пауза";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stopButton.Location = new System.Drawing.Point(414, 407);
            this.stopButton.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(124, 24);
            this.stopButton.TabIndex = 18;
            this.stopButton.Text = "Стоп";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // statusNameLabel
            // 
            this.statusNameLabel.AutoSize = true;
            this.statusNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusNameLabel.Location = new System.Drawing.Point(12, 414);
            this.statusNameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.statusNameLabel.Name = "statusNameLabel";
            this.statusNameLabel.Size = new System.Drawing.Size(57, 17);
            this.statusNameLabel.TabIndex = 19;
            this.statusNameLabel.Text = "Статус:";
            // 
            // symbolsTextBox
            // 
            this.symbolsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.symbolsTextBox.Location = new System.Drawing.Point(15, 211);
            this.symbolsTextBox.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.symbolsTextBox.Name = "symbolsTextBox";
            this.symbolsTextBox.Size = new System.Drawing.Size(524, 23);
            this.symbolsTextBox.TabIndex = 20;
            // 
            // findFilesTreeView
            // 
            this.findFilesTreeView.Location = new System.Drawing.Point(550, 25);
            this.findFilesTreeView.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.findFilesTreeView.Name = "findFilesTreeView";
            this.findFilesTreeView.Size = new System.Drawing.Size(355, 406);
            this.findFilesTreeView.TabIndex = 0;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // templateHelpLabel
            // 
            this.templateHelpLabel.AutoSize = true;
            this.templateHelpLabel.Font = new System.Drawing.Font("Monotype Corsiva", 15.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.templateHelpLabel.ForeColor = System.Drawing.Color.LimeGreen;
            this.templateHelpLabel.Location = new System.Drawing.Point(164, 119);
            this.templateHelpLabel.Margin = new System.Windows.Forms.Padding(0);
            this.templateHelpLabel.Name = "templateHelpLabel";
            this.templateHelpLabel.Size = new System.Drawing.Size(18, 25);
            this.templateHelpLabel.TabIndex = 21;
            this.templateHelpLabel.Text = "i";
            // 
            // symbolsHelpLabel
            // 
            this.symbolsHelpLabel.AutoSize = true;
            this.symbolsHelpLabel.Font = new System.Drawing.Font("Monotype Corsiva", 15.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.symbolsHelpLabel.ForeColor = System.Drawing.Color.LimeGreen;
            this.symbolsHelpLabel.Location = new System.Drawing.Point(384, 183);
            this.symbolsHelpLabel.Margin = new System.Windows.Forms.Padding(0);
            this.symbolsHelpLabel.Name = "symbolsHelpLabel";
            this.symbolsHelpLabel.Size = new System.Drawing.Size(18, 25);
            this.symbolsHelpLabel.TabIndex = 22;
            this.symbolsHelpLabel.Text = "i";
            // 
            // ResultsTreeNameLabel
            // 
            this.ResultsTreeNameLabel.AutoSize = true;
            this.ResultsTreeNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResultsTreeNameLabel.Location = new System.Drawing.Point(547, 5);
            this.ResultsTreeNameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.ResultsTreeNameLabel.Name = "ResultsTreeNameLabel";
            this.ResultsTreeNameLabel.Size = new System.Drawing.Size(158, 17);
            this.ResultsTreeNameLabel.TabIndex = 23;
            this.ResultsTreeNameLabel.Text = "Результаты поиска:";
            // 
            // SearchParameterNameLabel
            // 
            this.SearchParameterNameLabel.AutoSize = true;
            this.SearchParameterNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchParameterNameLabel.Location = new System.Drawing.Point(12, 5);
            this.SearchParameterNameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.SearchParameterNameLabel.Name = "SearchParameterNameLabel";
            this.SearchParameterNameLabel.Size = new System.Drawing.Size(252, 17);
            this.SearchParameterNameLabel.TabIndex = 24;
            this.SearchParameterNameLabel.Text = "Введите параметры для поиска:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 274);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "Процесс поиска:";
            // 
            // errorTextBox
            // 
            this.errorTextBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.errorTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.errorTextBox.ForeColor = System.Drawing.Color.Red;
            this.errorTextBox.Location = new System.Drawing.Point(550, 233);
            this.errorTextBox.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.errorTextBox.Multiline = true;
            this.errorTextBox.Name = "errorTextBox";
            this.errorTextBox.ReadOnly = true;
            this.errorTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.errorTextBox.Size = new System.Drawing.Size(355, 198);
            this.errorTextBox.TabIndex = 26;
            this.errorTextBox.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 443);
            this.Controls.Add(this.errorTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SearchParameterNameLabel);
            this.Controls.Add(this.ResultsTreeNameLabel);
            this.Controls.Add(this.symbolsHelpLabel);
            this.Controls.Add(this.templateHelpLabel);
            this.Controls.Add(this.findFilesTreeView);
            this.Controls.Add(this.symbolsTextBox);
            this.Controls.Add(this.statusNameLabel);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.countFoundFilesNameLabel);
            this.Controls.Add(this.countFoundFilesLabel);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.timerNameLabel);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.symbolsNameLabel);
            this.Controls.Add(this.templateTextBox);
            this.Controls.Add(this.templateNameLabel);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.directoryNameLabel);
            this.Controls.Add(this.directoryTextBox);
            this.Controls.Add(this.directoryButton);
            this.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.Name = "Form1";
            this.Text = "Поиск файлов";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FindFilesForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button directoryButton;
        private System.Windows.Forms.TextBox directoryTextBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label directoryNameLabel;
        private System.Windows.Forms.Label templateNameLabel;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.Label symbolsNameLabel;
        private System.Windows.Forms.TextBox templateTextBox;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Label timerNameLabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label countFoundFilesNameLabel;
        private System.Windows.Forms.Label countFoundFilesLabel;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Label statusNameLabel;
        private System.Windows.Forms.TextBox symbolsTextBox;
        private System.Windows.Forms.TreeView findFilesTreeView;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Label symbolsHelpLabel;
        private System.Windows.Forms.Label templateHelpLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label SearchParameterNameLabel;
        private System.Windows.Forms.Label ResultsTreeNameLabel;
        private System.Windows.Forms.TextBox errorTextBox;
    }
}

