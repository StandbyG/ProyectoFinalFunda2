using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class eControlHoras
    {
        public int Id_ControlHoras { get; set; }
        public int Id_Trabajador { get; set; }
        public string Hora_Ingreso { get; set; }
        public string Hora_Salida { get; set; }
        public string Fecha_Registro { get; set; }
    }
}  
