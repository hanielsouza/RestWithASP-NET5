using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNET5Udemy.Model.Base
{
    //classe Base com o campo ID em comum para as tabelas que usarem
    public class BaseEntity
    {

        [Column("id")]
        public long Id { get; set; }

    }
}
