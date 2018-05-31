using System.Text.RegularExpressions;

namespace Common
{
    public static class HtmlHelper
    {
        /// <summary>
        /// 去掉HTML中的所有标签,只留下纯文本
        /// </summary>
        /// <param name="strHtml"></param>
        /// <returns></returns>
        public static string CleanHtml(this string strHtml)
        {
            if (string.IsNullOrEmpty(strHtml))
            {
                return strHtml;
            }

            //删除脚本
            strHtml = Regex.Replace(strHtml, "(\\<script(.+?)\\</script\\>)|(\\<style(.+?)\\</style\\>)", "", RegexOptions.IgnoreCase | RegexOptions.Singleline);

            //删除标签
            var reg = new Regex(@"<\/?[^>]*>", RegexOptions.IgnoreCase);
            Match match;
            for (match = reg.Match(strHtml); match.Success; match = match.NextMatch())
            {
                strHtml = strHtml.Replace(match.Groups[0].ToString(), "");
            }

            return strHtml.Trim();
        }
    }
}
