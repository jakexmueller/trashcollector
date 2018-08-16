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

        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }

        [Display(Name = "Pickup Day")]
        public string PickupDay { get; set;}

        [Display(Name = "Extra Pickup")]
        public string ExtraPickup { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        public string Password { get; set; }

        public int Balance { get; set; }

        [Display(Name = "Pickup Complete?")]
        public bool PickupComplete { get; set; }


    }
}