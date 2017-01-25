namespace MangaRipper.Strategy
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;

    class MangafoxRipper : IRipper
    {
        public string RipManga(string url)
        {
            string result;
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream data = response.GetResponseStream();
            using (var sr = new StreamReader(data))
            {
                result = sr.ReadToEnd();
                sr.Close();
            }
            return GetImageSource(result);
        }

        public string GetImageSource(string html)
        {
            string imageUrl = String.Empty;
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            List<HtmlNode> toftitle = doc.DocumentNode.Descendants().Where
            (x => (x.Name == "section") && x.Attributes["class"] != null && x.Attributes["class"].Value.Contains("read_img")).ToList();
            var sample = toftitle.First().ChildNodes.Where(x => (x.Name == "a")).ToList();
            var sample2 = sample.First().ChildNodes.Where(x => (x.Name == "img") && x.Attributes["id"] != null && x.Attributes["id"].Value.Contains("image")).ToList();
            imageUrl = sample2.First().Attributes["src"].Value;
            //&& x.Attributes["id"] != null && x.Attributes["id"].Value.Contains("image"))
            return imageUrl;
        }
    }
}
