using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace CarpeLibrum_BookClub_23.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        [Display (Name = "Name: ")]
        [Required]
        public string FullName { get; set; }

        [Display(Name = "Email: ")]
        [DataType (DataType.EmailAddress)]
        [EmailAddress]
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Display(Name = "Comment: ")]
        [DataType(DataType.MultilineText)]
        [Required]
        public string Comment { get; set; }

        [Display(Name = "Date: ")]
        [DataType(DataType.Date)]
        public DateTime DateOfMessage { get; set; }
    }
}