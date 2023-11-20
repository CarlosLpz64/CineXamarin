using System;
using System.Collections.Generic;
using System.Text;

namespace Cine.Models
{
    public class MoviePlay
    {
        public string movie_id { get; set; }
        public string room_id { get; set; }
        public string hour_function { get; set; }
        public string date_function { get; set; }
        public Movie movie { get; set; }
        public Room room { get; set; }
    }
}
