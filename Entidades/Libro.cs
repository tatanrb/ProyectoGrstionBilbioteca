using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_de_Biblioteca.Interfaces;
using Gestion_de_Biblioteca.Utilidades;

namespace Gestion_de_Biblioteca.Entidades
{
    public class Libro : Biblioteca, IPrestable
    {
        public string ISBN { get; set; }

        public Libro(string titulo, string autor, int añoPublicacion, string isbn) : base(titulo, autor, añoPublicacion)
        {
            ISBN = isbn;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"ISBN: {ISBN}\n");
        }

        public bool Prestar()
        {
            if (Estado == EstadoLibro.Prestado)
            {
                Console.WriteLine("Lo siento, el libro ya está prestado!");

                return false;
            }
            else
            {
                Estado = EstadoLibro.Prestado;
                Console.WriteLine("Libro prestado!");
                Console.WriteLine($"Estado del libro ha cambiado a: {Estado}");
                return true;
            }

        }

        public bool Devolver()
        {
            if (Estado != EstadoLibro.Prestado)
            {
                Console.WriteLine("Lo siento, el libro aún no está prestado!");
                return false;
            }
            else
            {
                Estado = EstadoLibro.Disponible;
                Console.WriteLine($"Estado del libro ha cambiado a: {Estado}");
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

            Console.Write("Ingrese el ISBN: ");
            this.ISBN = Console.ReadLine();
        }

        public bool estaDisponible()
        {
            return this.Estado == EstadoLibro.Disponible;
        }
    }

}
