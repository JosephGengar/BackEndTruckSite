using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackHeavyMachine.Models.Repuestas
{
    public class Respuesta
    {
        public int exito { get; set; }
        public object data { get; set; }
        public string mensajes { get; set; }
    }
}
