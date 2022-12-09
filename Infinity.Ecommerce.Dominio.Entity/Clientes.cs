using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infinity.Ecommerce.Dominio.Entity
{
    public class Clientes
    {
        public int CodClient { get; set; }
        public string Usuario { get; set; }
        public string Nombres { get; set; }
        public string Cargo { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public int CodTipoClienteFK { get; set; }
    }
}
