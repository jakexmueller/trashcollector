using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace trashcollector.Models
{
    public class AnonymousUser
    {
        [Key]
        public int ID { get; set; }
    }
}