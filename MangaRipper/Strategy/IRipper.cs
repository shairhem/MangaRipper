﻿namespace MangaRipper.Strategy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    interface IRipper
    {
        string RipManga(string siteUrl);
    }
}
