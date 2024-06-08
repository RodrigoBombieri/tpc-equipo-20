using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Incidente
    {
        public int Id { get; set; }
        public TipoIncidente Tipo { get; set; }
        public Prioridad Prioridad { get; set; }
        public Estado Estado { get; set; }
        public string Detalle { get; set; }
        public Usuario UsuarioAsignado { get; set; }
        public Usuario UsuarioCreador { get; set; }
    }
}
