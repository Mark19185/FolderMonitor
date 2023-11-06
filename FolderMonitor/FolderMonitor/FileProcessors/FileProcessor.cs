using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FolderMonitor.FileProcessors
{
    //Абстрактный класс процессора
    //Чтобы не было проблем с доступом к содержимому файла, реализована цикличная проверка возможности чтения
    public abstract class FileProcessor
    {
        public string ResultFilePath { get; set; }
        public string FilePath { get; set; }
        internal string FileContent
        {
            get
            {
                bool isWaiting = true;

                while (isWaiting)
                {
                    try
                    {
                        using (System.IO.File.Open(FilePath, FileMode.Open, FileAccess.Read, FileShare.Read)) { }
                        isWaiting = false;
                    }
                    catch (System.IO.IOException)
                    {
                        Thread.Sleep(1000);
                    }
                }

                return File.ReadAllText(FilePath);
            }
        }


        /// <summary>
        /// Полиморфный метод для вызова обработки
        /// </summary>
        public abstract void Execute();

        internal void WriteResult(string info)
        { 
            lock (this) 
            {
                File.AppendAllText(ResultFilePath, $"{Path.GetFileName(FilePath)} - {info}\n");
            }
        }
    }
}
