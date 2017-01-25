namespace MangaRipper
{
    using System;
    using Services;
    using Strategy;

    class Program
    {

        static void Main(string[] args)
        {
            IRipper mangafoxRipper = new MangafoxRipper();
            IDownloader downloader = new Downloader();
            Console.Write("input url: ");
            var url = Console.ReadLine();
            try
            {
                Uri uri = new Uri(url);
                var imageUrl = mangafoxRipper.RipManga(url);
                downloader.Download(imageUrl);
                Console.WriteLine(imageUrl);
            }
            catch (Exception err)
            {
                Console.Clear();
                Console.WriteLine(err.Message);
            }
            Console.ReadKey();
        }
    }
}
