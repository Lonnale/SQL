using System;
using System.Collections.Generic;

#nullable disable

namespace PersonDBApp.Models
{
    public partial class Yhteystiedot
    {
        public long Id { get; set; }
        public long Personid { get; set; }
        public string Tyyppi { get; set; }
        public string Arvo { get; set; }
        public string Phonenumber { get; set; }

        public virtual Person Person { get; set; }
    }
}
