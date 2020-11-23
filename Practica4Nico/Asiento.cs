using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica4Nico
{
    public class Asiento
    {
        private int columna;
        private int fila;
        private String estado;  


        public Asiento(int columna, int fila, string estado)
        {
            this.columna = columna;
            this.fila = fila;
            this.estado = estado;
        }


        public int Columna { get => columna; set => columna = value; }
        public int Fila { get => fila; set => fila = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}
