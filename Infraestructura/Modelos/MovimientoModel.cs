using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Modelos
{
    public class MovimientoModel
    {
        public int id_movimientos { get; set; }
        public int idfk_cuentas{ get; set; }
        public DateTime fechamovimiento { get; set; }
        public string tipomovimiento { get; set; }
        public float saldoanterior {  get; set; }
        public float saldoactual {  get; set; }
        public float montomovimiento { get; set; }
        public float cuentaorigen {  get; set; }
        public float cuentadestino {  get; set; }
        public float canal {  get; set; }
        public MovimientoModel() { }
    }
}
