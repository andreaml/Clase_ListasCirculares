using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_ListasCirculares
{
    class Base
    {
        private string _nombre;
        public string nombre { get { return _nombre; } }
        private int _minutos; //Minutos para llegar desde la base anterior.
        public int minutos { get { return _minutos; } set { _minutos = value; } }
        private Base _anterior;
        public Base anterior { set { _anterior = value; } get { return _anterior; } }
        private Base _siguiente;
        public Base siguiente { set { _siguiente = value; } get { return _siguiente; } }

        public Base(string nombre, int minutos)
        {
            _nombre = nombre;
            _minutos = minutos;
        }

        public override string ToString()
        {
            return "Base: " + _nombre + Environment.NewLine + _minutos + " minutos para llegar desde la base anterior: " + _anterior.nombre + Environment.NewLine + Environment.NewLine;
        }
    }
}
