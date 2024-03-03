using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _66bitTest.Models
{
    // Точка расширения в случае добавления не только футболистов
    public class Direction
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("title")]
        [MaxLength(100)]
        public required string Title { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
