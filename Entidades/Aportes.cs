using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_AP1_Felix_20180570.Entidades
{
    public class Aportes
    {
        [Key]
        public int AporteID { get; set; }
        public DateTime Fecha { get; set; }
        public string Persona { get; set; }
        public string Concepto { get; set; }
        public double Monto { get; set; }
    }
}
