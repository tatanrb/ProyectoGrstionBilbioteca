using Gestion_de_Biblioteca.LogicaNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Biblioteca.Entidades
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public int IDUsuario { get; set; }
        public HistorialPrestamos historialPrestamos { get; set; }

        public Usuario(string nombre, int idUsuario)
        {
            Nombre = nombre;
            IDUsuario = idUsuario;
            historialPrestamos = new HistorialPrestamos();
        }
    }
}

