using System;
using System.Collections.Generic;

#nullable disable

namespace PersonDBApp.Models
{
    public partial class Shoe
    {
        public long Id { get; set; }
        public long Personid { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        public virtual Person Person { get; set; }
    }
}
