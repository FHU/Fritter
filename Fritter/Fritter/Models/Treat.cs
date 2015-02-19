using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fritter.Models
{
    public class Treat
    {
        public int TreatId { get; set; }

        public string Text { get; set; }
        
        //TO DO: This should be the User class NOT string
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        
        public DateTime Timestamp { get; set; }

        //TO DO: This should be the User class NOT string
        public List<string> Bites { get; set; }
        
        //TO DO: This should be the User class NOT string
        public List<string> Replies { get; set; }

        public Treat()
        {
            this.Timestamp = DateTime.Now;
        }

        public Treat(int id, string Text = "", string UserName = "")
        {
            this.TreatId = id;
            this.Text = Text;
            
            this.Timestamp = DateTime.Now;
        }
    }
}