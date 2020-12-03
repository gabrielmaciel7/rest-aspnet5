using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNET5.Entities
{
    public class Base
    {
        [Column("id")]
        public long Id { get; set; }
    }
}
