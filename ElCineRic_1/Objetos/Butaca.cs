using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElCineRic_1.Objetos
{
    public class Butaca
    {
       
        public string id;        
        public bool ocupado = false;
        public string id_silla;

        public Butaca(string id, bool ocupado, string id_silla)
        {
            this.id = id;
            this.ocupado = ocupado;
            this.id_silla = id_silla;

        }
    }
}