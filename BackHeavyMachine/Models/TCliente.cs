using System;
using System.Collections.Generic;

namespace BackHeavyMachine.Models
{
    public partial class TCliente
    {
        public TCliente()
        {
            TCamiones = new HashSet<TCamiones>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public int Estado { get; set; }

        public virtual ICollection<TCamiones> TCamiones { get; set; }
    }
}
