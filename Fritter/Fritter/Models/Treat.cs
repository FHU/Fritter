using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Fritter.Models
{
    public class Treat
    {
        //[Key]
        public int TreatId { get; set; }

        public string Text { get; set; }
        public DateTime TimeStamp { get; set; }

        public ApplicationUser Creator { get; set; }
        public string CreatorID { get; set; }

    }
}