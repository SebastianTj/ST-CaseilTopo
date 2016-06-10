using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace il_Topolino.Models
{
    public class Auto : Voertuig
    {
        public int aantalDeuren { get; set; }
        

        public Auto() : base()
        {
            this.snelheid = 50;
            this.type = "Fiat 500";
            this.aantalDeuren = 3;
        }
    }
}