using RestWithASPNET5Udemy.Hypermedia.Abstract;
using System.Collections.Generic;

namespace RestWithASPNET5Udemy.Hypermedia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }
}
