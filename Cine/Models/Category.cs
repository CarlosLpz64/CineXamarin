using System;
using System.Collections.Generic;
using System.Text;

namespace Cine.Models
{
    public class Category
    {
        public int id {  get; set; }
        public string name { get; set; }
        public string categoryString => $"Categoría: {name}.";

    }
}
