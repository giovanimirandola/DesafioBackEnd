﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesafioPaschoalottoBackEnd.Models
{
    public class Root
    {
        public int code { get; set; }
        public string status { get; set; }
        public string copyright { get; set; }
        public string attributionText { get; set; }
        public string attributionHTML { get; set; }
        public string etag { get; set; }
        public Data data { get; set; }
    }
}