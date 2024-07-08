using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Biblioteca.Interfaces
{
    public interface IPrestable
    {
        public bool Prestar();
        public bool Devolver();

        public void MostrarInformacion();

        public bool estaDisponible();
    }
}
