using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace SEO_Tool
{
    public partial class SEO : Form
    {
        DataTable SEO_DataTable = new DataTable();

        public SEO()
        {
            InitializeComponent();
            //bWorker.RunWorkerAsync();
        }

        private void bWorker_DoWork_1(object sender, DoWorkEventArgs e)
        {
            String website = "www.smokeball.com.au";
            String keyword = "Conveyancing Software";
            int _Count = 0;

            keyword results = GetPosition(website, keyword);
            if (results.Link != null)
            {
                string link = results.Link;
                var linkParser = new Regex(@"\b(?:https?://|www\.)\S+\b?&amp;sa", RegexOptions.Compiled | RegexOptions.IgnoreCase);

                foreach (Match m in linkParser.Matches(link))
                    link = m.Value;
                string pattern = "&amp;sa";
                string replacement = "";
                Regex rgx = new Regex(pattern);
                string new_link = rgx.Replace(link, replacement);
                if (results.Postion > 0)
                {
                    SEO_DataTable.Rows.Add(website, keyword, results.Postion.ToString(), link);
                    if (SEOData.InvokeRequired)
                    {
                        SEOData.Invoke(new MethodInvoker(delegate { SEOData.DataSource = SEO_DataTable; }));
                    }
                    _Count++;
                }
            }
        }

        private keyword GetPosition(string Url, string searchTerm)
        {
            string html;
            keyword result = new keyword();
            try
            {
                string raw = "https://www.google.com.au/search?num=100&q=conveyancing+Software";
                string search = string.Format(raw, System.Uri.EscapeDataString(searchTerm));
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(search);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {

                        html = reader.ReadToEnd();
                        result = FindPosition(html, Url);

                    }
                }
            }
            catch (WebException ex)
            {
                using (var sr = new StreamReader(ex.Response.GetResponseStream()))
                    html = sr.ReadToEnd();
            }
            return result;
        }

        private keyword FindPosition(string html, string url)
        {
            keyword result = new keyword();
            var Webget = new HtmlWeb();
            var page = Webget.Load("https://www.google.com.au");
            page.LoadHtml(html);

            var list = page.DocumentNode.SelectNodes("//h3[@class='r']//a");
            int count = list.Count();
            int i = 0;
            foreach (var obj in list)
            {
                i++;
                if (i > count)
                {
                    break;
                }
                else
                {
                    var urls = obj.SelectSingleNode(".").Attributes["href"].Value;
                    if (urls.Contains(url))
                    {
                        result.Link = urls;
                        result.Postion = i;
                        return result;
                    }
                }
            }
            return null;
        }

        private void SEO_Load(object sender, EventArgs e)
        {
            try
            {
                SEO_DataTable.Columns.Add("Website");
                SEO_DataTable.Columns.Add("keyword");
                SEO_DataTable.Columns.Add("position");
                SEO_DataTable.Columns.Add("link");
                bWorker.RunWorkerAsync();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
