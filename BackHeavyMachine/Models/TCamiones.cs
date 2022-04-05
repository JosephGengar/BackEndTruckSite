using System;
using System.Collections.Generic;

namespace BackHeavyMachine.Models
{
    public partial class TCamiones
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public int Peso { get; set; }
        public int Idcliente { get; set; }
        public int Cantidad { get; set; }
        public int Total { get; set; }

        public virtual TCliente IdclienteNavigation { get; set; }
    }
}
