using MonitorVersaoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorVersaoFinal.Interfaces
{
    public interface IRssFeedService
    {
        void FetchRssFeeds(List<RssSource> sources);

    }
}
