using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFileInDirectory
{
    public static class Consts
    {
        public const string TemplateHelp = 
            "Может содержать сочетание допустимого\n" +
            "литерального пути и подстановочного символа (* и ?), где\n" +
            "? - один любой символ,\n" +
            "* - любое кол-во любых символов.\n" +
            "Если оставить поле пустым, будет выполнен поиск всех файлов.\n\n" +
            "Пример:\n" +
            "*.txt - поиск всех файлов формата txt.";
       
        public const string SymbolsHelp = 
            "Символы, которые могут содержаться в названии файла.\n" +
            "Если необходимо проверка на несколько наборов символов,\n" +
            "то вводить их следует через символ *.\n\n" +
            "Пример:\n" +
            "abc - поиск всех файлов, у которых в названии содержится \"abc\";\n" +
            "abc*def - поиск всех файлов, у которых в названии содержится \"abc\", а также \"def\". ";


        public const string DirectoryDescription = "Выберите директорию для поиска";       
        public const string Continue = "Продолжить";
        public const string Pause = "Пауза";
        public const string TimerZeroValue = "0:0:0:0";

        public static class Statuses
        {
            public const string Searching = "Идет поиск файлов";
            public const string SearchCompleted = "Поиск завершен";
            public const string SearchPause = "Поиск на паузе";
            public const string SearchStop = "Поиск остановлен";
            public const string Error = "Ошибка!";
        }
    }
}
