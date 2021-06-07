using System;
using System.Collections.Generic;
using System.Text;

namespace mongodb_youtube
{
   public class video
    {
        public string title { get; set; }
        
        public string description { get; set; }

        public List<comment> comments { get; set; }

        public video(string tilte, string description)
        {
            this.title = tilte;
            this.description = description;
        }
    }
}
