using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _66bitTest.Models
{
    public class Team
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [ForeignKey("direction_id")]
        public virtual required Direction Direction { get; set; }

        [Column("title")]
        [MaxLength(100)]
        [Display(Name = "Название команды")]
        public required string Title { get; set; }

        public virtual ICollection<Human> People { get; set; }
    }
}
