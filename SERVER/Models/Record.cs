﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SERVER.Models
{
    [DataContract]

    public class Record
    {
        [DataMember]
        public int Id { get; set; }
    }
}