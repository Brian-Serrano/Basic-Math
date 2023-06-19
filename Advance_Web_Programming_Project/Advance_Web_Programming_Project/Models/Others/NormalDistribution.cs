using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Hosting;

namespace Advance_Web_Programming_Project.Models.Others
{
    public static class NormalDistribution // Web Scraper
    {
        public static double GetNormalDistribution(double zScore)
        {
            double modified = zScore * 10 + 30;
            double isNegative = zScore >= 0 ? modified - Math.Floor(modified) : Math.Abs(modified - Math.Ceiling(modified));
            double colIndex = Math.Round(isNegative, 1);
            double rowIndex = zScore >= 0 ? Math.Floor(modified) : Math.Ceiling(modified);

            return double.Parse(GetDistributionTable()[(int)rowIndex][(int)(colIndex * 10)]);
        }

        private static List<List<string>> GetDistributionTable()
        {
            List<List<string>> wholeTable = new List<List<string>>();

            string html = GetHtmlFromFile(HostingEnvironment.MapPath("~/Assets/Basic Math Course Topics/Normal_Distribution_Table.html"));

            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(html);

            HtmlNode table = document.DocumentNode.SelectSingleNode("//table");
            if (table != null)
            {
                HtmlNodeCollection tbody = table.SelectNodes("tbody");
                if (tbody != null)
                {
                    foreach(var tb in tbody)
                    {
                        HtmlNodeCollection rows = tb.SelectNodes("tr");
                        if (rows != null)
                        {
                            for(int i = 1; i < rows.Count; i++)
                            {
                                HtmlNodeCollection cells = rows[i].SelectNodes("td");
                                if (cells != null)
                                {
                                    List<string> tableData = new List<string>();

                                    for(int j = 1; j < cells.Count; j++)
                                    {
                                        tableData.Add(cells[j].InnerText);
                                    }

                                    wholeTable.Add(tableData);
                                }
                            }
                        }
                    }
                }
            }

            return wholeTable;
        }

        private static string GetHtmlFromFile(string filePath)
        {
            string html = string.Empty;

            using (var reader = new StreamReader(filePath))
            {
                html = reader.ReadToEnd();
            }

            return html;
        }
    }
}