﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesafioPaschoalottoBackEnd.Models
{
    public class Stories
    {
        public int available { get; set; }
        public string collectionURI { get; set; }
        public List<Item> items { get; set; }
        public int returned { get; set; }
    }
}