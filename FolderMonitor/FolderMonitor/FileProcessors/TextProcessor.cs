using FolderMonitor.Common.StringExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderMonitor.FileProcessors
{
    public class TextProcessor : FileProcessor
    {
        public override void Execute()
        {
            GetPunctuationMarksCount();
        }

        private int GetPunctuationMarksCount()
        {
            var punctuationMarksCount = base.FileContent.CountOfOccurrences("[.!?,\\-';:]");

            base.WriteResult($"подсчет знаков препинания - {punctuationMarksCount}");

            return punctuationMarksCount;
        }
    }
}
