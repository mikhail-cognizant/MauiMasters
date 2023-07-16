using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiMasters;

public partial class HttpClientService
{
    public partial HttpMessageHandler GetPlatfromSpecificHttpMessageHandler()
    {
        var handler = new NSUrlSessionHandler
        {
            TrustOverrideForUrl = bool (NSUrlSessionHandlerSender, url, secTrust) => url.StartsWith("https://localhost")
        };
        return handler;
    }
}
