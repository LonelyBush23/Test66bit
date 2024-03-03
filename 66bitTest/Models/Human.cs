using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace _66bitTest.Models
{
    public class Human
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [ForeignKey("team_id")]
        public virtual required Team Team { get; set; }

        [Column("first_name")]
        [MaxLength(30)]
        [Display(Name = "Имя")]
        public required string FirstName { get; set; }

        [Column("second_name")]
        [MaxLength(30)]
        [Display(Name = "Фамилия")]
        public required string SecondName { get; set; }

        [Column("gender")]
        [Display(Name = "Пол")]
        public required string Gender { get; set; }

        [Column("birth_date")]
        [Display(Name = "Дата рождения")]
        public required DateOnly BirthDate { get; set; }

        [Column("country")]
        [Display(Name = "Страна")]
        public required string Country { get; set; }
    }
}
