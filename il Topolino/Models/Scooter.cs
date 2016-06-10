using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace il_Topolino.Models
{
    public class Scooter : Voertuig
    {
        public Scooter() : base()
        {
            this.snelheid = 15;
            this.type = "Vespa";
        }
    }
}