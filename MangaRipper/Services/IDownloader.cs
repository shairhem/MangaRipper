namespace MangaRipper.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    interface IDownloader
    {
        
        void Download(string imgUrl);
        string IteratePage();
    }
}
