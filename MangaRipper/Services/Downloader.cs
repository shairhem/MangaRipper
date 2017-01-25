namespace MangaRipper.Services
{
    using System;
    using System.IO;
    using System.Net;

    class Downloader : IDownloader
    {

        public string BaseUrl { get; set; }
        public int PageNum { get; set; }
        public string CurrentPage { get; set; }

        public void Download(string imageUrl)
        {

            this.BaseUrl = imageUrl.Substring(0, imageUrl.LastIndexOf('/') + 2);
            this.PageNum = int.Parse(imageUrl.Substring(imageUrl.LastIndexOf('/') + 2, 3));
            var location = "C:\\manga\\haikyuu\\c231";
            try
            {
                Directory.CreateDirectory(location);
                using (var client = new WebClient())
                {
                    while (true)
                    {
                        IteratePage();
                        client.DownloadFile(this.CurrentPage, location + PageNum + ".jpg");
                        PageNum++;
                    }
                }
            }
            catch (Exception err)
            {
                Console.Write(err.Message);
            }
        }



        public string IteratePage()
        {
            string page;
            if (this.PageNum < 10)
            {
                page = "00";
            }
            else if(this.PageNum < 100)
            {
                page = "0";
            }
            else
            {
                page = "";
            }
            page += this.PageNum;

            this.CurrentPage = this.BaseUrl + page + ".jpg";
            return String.Empty;
        }
    }
}
