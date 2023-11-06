using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FolderMonitor.Common.StringExtension
{
    public static class StringExtension
    {
        /// <summary>
        /// Возвращает количество вхождений паттерна в строку
        /// </summary>
        /// <param name="pattern">Регулярное выражение</param>
        /// <returns></returns>
        public static int CountOfOccurrences(this string text, string pattern)
        {
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(text);

            return matches.Count;
        }
    }
}
