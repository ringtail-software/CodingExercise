using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZachAlbertCodingExercise.Models
{
    public class User
    {

        [Key]
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }

}
}