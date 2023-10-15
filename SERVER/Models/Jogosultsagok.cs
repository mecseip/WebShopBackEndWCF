using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SERVER.Models
{
    public class Jogosultsagok : Record
    {
        [DataMember]
        public int JogId { get; set; }

        [DataMember]
        public string Nev { get; set;}
    }
}