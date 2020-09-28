using HtmlAgilityPack;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Utity
{
    public class HtmlHelp
    {
        /// <summary>
        /// 读取网页内容
        /// </summary>
        /// <param name="htmldoc">获取html文档</param>
        /// <param name="rootTags">上级Tag</param>
        /// <param name="rangeTags">重复值Tag xpath </param>
        /// <param name="rootXpath">上级Tag获取范围 xpath</param>
        /// <param name="rangeXpath">范围Tag获取范围xpath</param>
        /// <param name="rootValues">上级获取到的键值对</param>
        /// <param name="rangeValues">范围值获取到的键值对</param>
        /// <param name="rangeSkipStartRow">跳过第一行</param>
        /// <param name="rangeSkipEndRow">跳过末行</param>
        /// <param name="rangeSkip">跳过特定行</param>
        public static void GetBodyInfo(Func<string> htmldoc, Dictionary<string, FeildDetail> rootTags, Dictionary<string, FeildDetail> rangeTags, string rootXpath, string rangeXpath, out Dictionary<string, string> rootValues, out List<Dictionary<string, string>> rangeValues, bool rangeSkipStartRow = true, bool rangeSkipEndRow = false, IEnumerable<int> rangeSkip = null)
        {
            rootValues = new Dictionary<string, string>();
            rangeValues = new List<Dictionary<string, string>>();
            string response = htmldoc.Invoke();
            if (response == null)
            {
                return;
            }
            HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(response);
            //获取第一级的值
            HtmlNode rootnode = doc.DocumentNode.SelectSingleNode(rootXpath);
            if (rootnode != null)
            {
                foreach (KeyValuePair<string, FeildDetail> key in rootTags)
                {
                    HtmlNode tag = rootnode.SelectSingleNode(key.Value.Xpath);
                    switch (key.Value.ContentType)
                    {
                        case ContentType.InnerHtml:
                            rootValues.Add(key.Key, tag.InnerHtml);
                            break;
                        case ContentType.AttributeValue:
                            rootValues.Add(key.Key, tag.GetAttributeValue(key.Value.AttributeKey, ""));
                            break;
                        case ContentType.InnerText:
                            if (tag != null)
                            {
                                rootValues.Add(key.Key, tag.InnerText);
                            }
                            else
                            {
                                rootValues.Add(key.Key, "");
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            if (!string.IsNullOrEmpty(rangeXpath))
            {
                HtmlNodeCollection rangenodes = doc.DocumentNode.SelectNodes(rangeXpath);
                if (rangenodes != null)
                {
                    for (int i = 0; i < rangenodes.Count; i++)
                    {
                        if (rangeSkipStartRow)
                        {
                            if (i == 0)
                            {
                                continue;
                            }
                        }
                        if (rangeSkipEndRow)
                        {
                            if (i == rangenodes.Count - 1)
                            {
                                continue;
                            }
                        }
                        if (rangeSkip != null)
                        {
                            if (rangeSkip.Contains(i))
                            {
                                continue;
                            }
                        }
                        Dictionary<string, string> singValue = new Dictionary<string, string>();
                        foreach (KeyValuePair<string, FeildDetail> key in rangeTags)
                        {
                            HtmlNode tag = rangenodes[i].SelectSingleNode(key.Value.Xpath);
                            switch (key.Value.ContentType)
                            {
                                case ContentType.InnerHtml:
                                    singValue.Add(key.Key, tag.InnerHtml);
                                    break;
                                case ContentType.AttributeValue:
                                    singValue.Add(key.Key, tag.GetAttributeValue(key.Value.AttributeKey, ""));
                                    break;
                                case ContentType.InnerText:
                                    singValue.Add(key.Key, tag.InnerText);
                                    break;
                                default:
                                    break;
                            }
                        }
                        rangeValues.Add(singValue);
                    }
                }
            }
        }

        public static List<List<string>> GetTable(string html)
        {
            html = html.Replace("<br>", " | ");
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            List<List<string>> dta = new List<List<string>>();
            List<string> kb = new List<string>();
            foreach (HtmlNode div in doc.DocumentNode.SelectNodes("//div"))
            {
                if (div.Id == "kb")
                {
                    if (div.SelectNodes("table") == null)
                    {
                        return null;
                    }

                    foreach (HtmlNode table in div.SelectNodes("table"))
                    {
                        foreach (HtmlNode row in table.SelectNodes("tr"))
                        {
                            kb = new List<string>();
                            foreach (HtmlNode cell in row.SelectNodes("th|td"))
                            {
                                kb.Add(cell.InnerText.Replace("&nbsp;", ""));
                            }
                            dta.Add(kb);

                        }
                    }

                }
                Console.WriteLine();
                break;
            }
            return dta;
        }

    }
}
