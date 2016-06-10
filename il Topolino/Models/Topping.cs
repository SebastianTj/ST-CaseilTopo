using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace il_Topolino.Models
{
    public class Topping
    {
        public int prijs { get; set; }

        public Topping() : base()
        {
            this.prijs = 1;
        }
    }
}