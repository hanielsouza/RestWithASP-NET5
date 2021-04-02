using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNET5Udemy.Model.Base
{
    public class BaseEntity
    {

        [Column("id")]
        public long Id { get; set; }

    }
}
