using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catedra.src.Models
{
      public class User
    {
        public int Id {get;set; }
        public int Rut {get;set; }
        public string Nombre {get;set; } = string.Empty;
        public string Correo {get;set; } = string.Empty;

        public string Genero {get;set; } = string.Empty;

        public string Fecha {get;set; } = string.Empty;
    }
}