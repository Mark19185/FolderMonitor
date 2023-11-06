using FolderMonitor.Common.StringExtension;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FolderMonitor.FileProcessors
{
    public class HtmlProcessor : FileProcessor
    {
        public override void Execute()
        {
            GetElementsCount("div");
        }

        private void GetElementsCount(string element)
        {
                var divElementsCount = base.FileContent.CountOfOccurrences(element);
                base.WriteResult($"Подсчет элементов {new Regex("[^\\w\\d]").Replace(element, "[^\\w\\d]")} - {divElementsCount}");
        }

    }
}
