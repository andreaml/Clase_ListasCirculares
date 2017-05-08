using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_ListasCirculares
{
    class Ruta
    {
        private Base _primero;
        //private Base _ultimo;

        public Ruta()  
        {
            _primero = null;
            //_ultimo = null;
        }

        public void agregarBase(Base baseNueva)
        {
            if (_primero == null)
            {
                _primero = baseNueva;
                _primero.siguiente = baseNueva;
                _primero.anterior = baseNueva;
            }
            else
            {
                _primero.anterior.siguiente = baseNueva;
                baseNueva.anterior = _primero.anterior;
                baseNueva.siguiente = _primero;
                _primero.anterior = baseNueva;

            }
        }

        public void agregarBaseInicio(Base baseNueva)
        {
            if (_primero == null)
            {
                _primero = baseNueva;
                _primero.siguiente = baseNueva;
                _primero.anterior = baseNueva;
            }
            else
            {
                baseNueva.anterior = _primero.anterior;
                baseNueva.siguiente = _primero;
                _primero.anterior.siguiente = baseNueva;
                _primero.anterior = baseNueva;
                _primero = baseNueva;
            }
        }

        public void insertarBaseDespuesDe(string nombreBase, Base baseNueva)
        {
            Base busquedaBase = buscarBase(nombreBase);
            if (busquedaBase != null)
            {
                busquedaBase.siguiente.anterior = baseNueva;
                baseNueva.siguiente = busquedaBase.siguiente;
                busquedaBase.siguiente = baseNueva;
                baseNueva.anterior = busquedaBase;
            }
            else
            {
                agregarBaseInicio(baseNueva);
            }
        }

        public Base buscarBase(string nombreBase)
        {
            if (_primero != null)
                return buscarBase(_primero, nombreBase);
            return null;
        }

        private Base buscarBase(Base actual, string nombreBase)
        {
            if (actual.nombre == nombreBase)
                return actual;
            else if (actual.siguiente != _primero)
            {
                return buscarBase(actual.siguiente, nombreBase);
            }
            return null;
        }

        public string eliminarBase(string nombreBase)
        {
            string mensaje = "Base no encontrada";
            Base busquedaBase = buscarBase(nombreBase);
            if (busquedaBase != null)
            {
                if (busquedaBase.siguiente == busquedaBase && busquedaBase.anterior == busquedaBase)
                {
                    _primero = null;
                    mensaje = "Producto eliminado";
                }
                else
                {
                    busquedaBase.anterior.siguiente = busquedaBase.siguiente;
                    busquedaBase.siguiente.anterior = busquedaBase.anterior;
                    if (busquedaBase == _primero)
                        _primero = _primero.siguiente;
                    mensaje = "Producto eliminado";
                }
            }
            return mensaje;
        }

        public string reporte()
        {
            string reporte = "";
            Base actual = _primero;
            do
            {
                reporte += actual.ToString() + Environment.NewLine + "----------------------------" + Environment.NewLine;
                actual = actual.siguiente;
            } while (actual != null && actual != _primero);
            return reporte;
        }

        public string recorrido(string nombre, DateTime horaInicio, DateTime horaFin)
        {
            Base busquedaBase = buscarBase(nombre);
            if (busquedaBase != null)
                return recorrido(busquedaBase, horaInicio, horaFin);
            else
                return "";

        }

        private string recorrido(Base ultimo, DateTime horaInicio, DateTime horaFin)
        {
            string ruta = "";
            DateTime sumaMins = horaInicio.AddMinutes(ultimo.siguiente.minutos);
            if ( sumaMins <= horaFin)
            {
                ruta += ultimo.nombre + horaInicio.ToShortTimeString() + Environment.NewLine + recorrido(ultimo.siguiente, sumaMins, horaFin);
            }
            else
            {
                ruta += ultimo.nombre + horaInicio.ToShortTimeString();
            }
            return ruta;
        }
    }
}
