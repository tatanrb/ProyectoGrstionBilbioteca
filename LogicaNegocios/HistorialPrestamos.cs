using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Gestion_de_Biblioteca.Entidades;
using Gestion_de_Biblioteca.Interfaces;
using Gestion_de_Biblioteca.Utilidades;

namespace Gestion_de_Biblioteca.LogicaNegocios
{
    public class HistorialPrestamos
    {
        public Dictionary<EstadoPrestamo, HashSet<IPrestable>> prestamos = new Dictionary<EstadoPrestamo, HashSet<IPrestable>>();
        public HashSet<IPrestable> historialPrestamos = new HashSet<IPrestable>();

        public HistorialPrestamos()
        {
            prestamos.Add(EstadoPrestamo.Prestado, new HashSet<IPrestable>());
            prestamos.Add(EstadoPrestamo.Devuelto, new HashSet<IPrestable>());
        }

        public void RegistrarPrestamo(IPrestable itemPrestable)
        {
            EstadoPrestamo estado = EstadoPrestamo.Prestado;

            // Verificar si ya existe una lista para el estado Prestado
            if (!prestamos.ContainsKey(estado))
            {
                prestamos.Add(estado, new HashSet<IPrestable>());
            }

            // Agregar el IPrestable a la lista correspondiente al estado Prestado
            prestamos[estado].Add(itemPrestable);
            historialPrestamos.Add(itemPrestable);
        }

        public bool RegistrarDevolucion(IPrestable itemPrestable)
        {
            bool devuelto = false;
            EstadoPrestamo estado = EstadoPrestamo.Devuelto;

            // Verificar si el elemento está en la lista de Prestado
            if (prestamos[EstadoPrestamo.Prestado].Contains(itemPrestable))
            {
                // Remover el elemento de la lista de Prestado y agregarlo a Devuelto
                prestamos[EstadoPrestamo.Prestado].Remove(itemPrestable);
                prestamos[estado].Add(itemPrestable);

                Console.WriteLine("Devolución registrada correctamente.");

                devuelto = true;
            }
            else
            {
                Console.WriteLine("El elemento no está marcado como prestado.");
            }

            return devuelto;
        }

        // Método para imprimir los elementos prestados
        public void ImprimirPrestados()
        {
            Console.WriteLine("Elementos prestados:");
            foreach (var item in prestamos[EstadoPrestamo.Prestado])
            {
                item.MostrarInformacion();
            }
        }

        // Método para imprimir los elementos devueltos
        public void ImprimirDevueltos()
        {
            Console.WriteLine("Elementos devueltos:");
            foreach (var item in prestamos[EstadoPrestamo.Devuelto])
            {
                item.MostrarInformacion();
            }
        }

        public void ImprimirHistorial()
        {
            Console.WriteLine("Elementos prestados:");
            foreach (var item in historialPrestamos)
            {
                item.MostrarInformacion();
            }
        }
    }
}
