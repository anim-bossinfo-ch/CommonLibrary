using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BossInfo.Dms.CommonLibrary
{
    public static class HtmlHelper
    {
        public static string GetPlainText(string html)
        {
            return Regex.Replace(html, "<[^>]+?>", string.Empty).Trim();
        }
    }
}
