using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceDesk.extra_code
{
    public class Ansatte
    {
        public int ID { get; set; }
        public string fornavn { get; set; }
        public string efternavn { get; set; }
        public int telefon { get; set; }
        public int type { get; set; }
        public string email { get; set; }
    }
}