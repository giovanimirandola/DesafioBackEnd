using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesafioPaschoalottoBackEnd.Models
{
    public class Result
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime modified { get; set; }
        public string resourceURI { get; set; }
        public Comics comics { get; set; }
        public Series series { get; set; }
        public Stories stories { get; set; }
        public Events events { get; set; }
    }
}