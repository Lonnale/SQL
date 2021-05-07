using System;
using System.Collections.Generic;

#nullable disable

namespace PersonDBApp.Models
{
    public partial class Phone
    {
        public long Id { get; set; }
        public long Personid { get; set; }
        public string Phonenumber { get; set; }
        public string Test { get; set; }
    }
}
