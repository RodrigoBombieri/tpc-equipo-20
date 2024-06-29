using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Accion
    {
        public long Id { get; set; }
        public long IDIncidente { get; set; }
        public string Detalle { get; set; }
        public long IDUsuario { get; set; }
        public TipoAccion Tipo { get; set; }
        public DateTime Fecha { get; set; }
    }
}
