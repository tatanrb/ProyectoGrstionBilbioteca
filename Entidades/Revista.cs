using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_de_Biblioteca.Interfaces;
using Gestion_de_Biblioteca.Utilidades;

namespace Gestion_de_Biblioteca.Entidades
{
    public class Revista : Biblioteca, IPrestable
    {
        public int NumeroEdicion { get; set; }

        public Revista(string titulo, string autor, int añoPublicacion, int numeroEdicion) : base(titulo, autor, añoPublicacion)
        {
            NumeroEdicion = numeroEdicion;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Número de Edición: {NumeroEdicion}\n");
        }

        public bool Prestar()
        {
            if (Estado == EstadoLibro.Prestado)
            {
                Console.WriteLine("Lo siento, la revista ya está prestada!");
                return false;
            }
            else
            {
                Estado = EstadoLibro.Prestado;
                Console.WriteLine("Revista prestada!");
                Console.WriteLine($"Estado de la revista ha cambiado a: {Estado}");
                return true;
            }

        }

        public bool Devolver()
        {
            if (Estado != EstadoLibro.Prestado)
            {
                Console.WriteLine("Lo siento, la revista aún no está prestada!");
                return false;
            }
            else
            {
                Estado = EstadoLibro.Disponible;
                Console.WriteLine($"Estado de la revista ha cambiado a: {Estado}");
                return true;
            }
        }

        public override void ActualizarInformación()
        {
            Console.Write("Ingrese el título: ");
            this.Titulo = Console.ReadLine();

            Console.Write("Ingrese el autor: ");
            this.Autor = Console.ReadLine();

            Console.Write("Ingrese el año de publicacion: ");
            this.AñoPublicacion = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese el número de edición: ");
            this.NumeroEdicion = Convert.ToInt32(Console.ReadLine());
        }

        public bool estaDisponible()
        {
            return this.Estado == EstadoLibro.Disponible;
        
        }
    }

}
