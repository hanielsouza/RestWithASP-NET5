using RestWithASPNET5Udemy.Hypermedia;
using RestWithASPNET5Udemy.Hypermedia.Abstract;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RestWithASPNET5Udemy.Data.VO
{

    public class PersonVO:ISuportsHyperMedia
    {
        
        //[JsonPropertyName("code")] - Muda o nome de exibição do campo
        public long Id { get; set; }

        //[JsonPropertyName("name")]
        public string FirstName { get; set; }

        //[JsonPropertyName("last_name")]
        public string LastName { get; set; }
        
        //[JsonIgnore] - Ignora a exibição e validação
        public string Address { get; set; }

        //[JsonPropertyName("Sex")]
        public string Gender { get; set; }

        public bool Enabled { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
