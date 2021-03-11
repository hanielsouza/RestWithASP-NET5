using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNET5Udemy.Model
{
    [Table("person")]// referencia a tabela person
    public class Person
    {
        
        [Column("id")]//Referencia ao campo
        public long Id { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("address")]
        public string Address { get; set; }
        [Column("gender")]
        public string Gender { get; set; }
    }
}
