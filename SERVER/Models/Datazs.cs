using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SERVER.Models
{
    [DataContract]
    public class Datazs
    {
        [DataMember]
        public string Fnev { get; set; }
        [DataMember]
        public string Jelszo { get; set; }
    }
}