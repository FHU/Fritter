using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fritter.Models
{
    public class Treat
    {
        public string Text { get; set; }
        
        //TO DO: This should be the User class NOT string
        public string UserName { get; set; }
        
        public DateTime Timestamp { get; set; }

        //TO DO: This should be the User class NOT string
        public List<string> Bites { get; set; }
        
        //TO DO: This should be the User class NOT string
        public List<string> Replies { get; set; }

        public Treat()
        {
            this.Timestamp = DateTime.Now;
        }

        public Treat(string Text = "", string UserName = "")
        {
            this.Text = Text;
            this.UserName = UserName;
            this.Timestamp = DateTime.Now;
        }
    }
}