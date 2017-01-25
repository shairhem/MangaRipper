namespace MangaRipper.Services
{
    interface IDownloader
    {
        
        void Download(string imgUrl);
        string IteratePage();
    }
}
