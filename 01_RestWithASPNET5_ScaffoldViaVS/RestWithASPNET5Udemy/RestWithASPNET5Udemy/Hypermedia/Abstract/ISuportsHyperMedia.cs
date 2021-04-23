using System.Collections.Generic;

namespace RestWithASPNET5Udemy.Hypermedia.Abstract
{
    public interface ISuportsHyperMedia
    {
        List<HyperMediaLink>Links { get; set; }
    }
}
