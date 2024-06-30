using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Usuario
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Nick { get; set; }
        public string Dni { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public Rol Rol { get; set; }
        public string Password { get; set; }
        public string ImagenPerfil { get; set; }

        public override string ToString()
        {       
                return Apellido + ", " + Nombre;
         }
    }
}
