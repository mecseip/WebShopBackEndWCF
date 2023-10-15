using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SERVER.Models
{
    [DataContract]
    public class Felhasznalo : Record
    {
        [DataMember]

        public string Fnev { get; set; }

        [DataMember]

        public string SALT { get; set; }

        [DataMember]

        public string HASH { get; set; }

        [DataMember]

        public string Nev { get; set; }

        [DataMember]

        public byte Jog { get; set; }

        [DataMember]

        public bool Aktiv { get; set; }

        [DataMember]

        public string Email { get; set; }

        [DataMember]

        public string FenykepUtvonal { get; set; }
    }
}