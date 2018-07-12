using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace trashcollector.Models
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public int ZipCode { get; set; }
        public string PickupDay { get; set;}
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Balance { get; set; }


    }
}