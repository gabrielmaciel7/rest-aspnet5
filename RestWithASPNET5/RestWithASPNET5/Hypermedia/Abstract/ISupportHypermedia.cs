using System.Collections.Generic;

namespace RestWithASPNET5.Hypermedia.Abstract
{
    public interface ISupportHypermedia
    {
        List<HyperMediaLink> Links { get; set; }
    }
}
