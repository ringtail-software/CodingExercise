using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Investment.API.Entities
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public Guid UserName { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public ICollection<Investment> Investments { get; set; } = new List<Investment>();
    }
}
