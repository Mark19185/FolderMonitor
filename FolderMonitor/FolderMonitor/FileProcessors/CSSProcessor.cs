using FolderMonitor.Common.StringExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderMonitor.FileProcessors
{
    public class CSSProcessor : FileProcessor
    {
        public override void Execute()
        {
            CompareBrackets();
        }

        private bool CompareBrackets()
        {
            var openBracketCount = base.FileContent.CountOfOccurrences("{");
            var closingBracketCount = base.FileContent.CountOfOccurrences("}");

            var isCountSame = openBracketCount == closingBracketCount;

            base.WriteResult($"проверка совпадения скобок - {(isCountSame ? "совпадает" : "не совпадает")}");

            return isCountSame;
        }
    }
}
