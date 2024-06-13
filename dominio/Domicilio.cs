﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Domicilio
    {
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Piso { get; set; }
        public string Departamento { get; set; }
        public string Observaciones { get; set; }
        public string Localidad { get; set; }
        public Provincia Provincia { get; set; }
        public string CodigoPostal { get; set; }
    }
}
