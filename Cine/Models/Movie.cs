using System;
using System.Collections.Generic;
using System.Text;

namespace Cine.Models
{
    public class Movie
    {
        public int id { get; set; }
        public string name { get; set; }
        public int duration { get; set; }
        public string synopsis { get; set; }
        public string cover_path { get; set; }
        public int director_id { get; set; }
        public int category_id { get; set; }
        public Category category { get; set; }
        public Director director { get; set; }

        // Extras
        public string durationString => $"Duración: {duration} minutos.";
    }
}
