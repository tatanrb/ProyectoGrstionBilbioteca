using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Biblioteca.Entidades
{
    public class Periodico : Biblioteca
    {
        public DateTime FechaPublicacion { get; set; }

        public Periodico(string titulo, string autor, int añoPublicacion, DateTime fechaPublicacion) : base(titulo, autor, añoPublicacion)
        {
            FechaPublicacion = fechaPublicacion;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Fecha de Publicación: {FechaPublicacion.ToShortDateString()} \n");
        }

        public override void ActualizarInformación()
        {
            Console.Write("Ingrese el título: ");
            this.Titulo = Console.ReadLine();

            Console.Write("Ingrese el autor: ");
            this.Autor = Console.ReadLine();

            Console.Write("Ingrese el año de publicacion: ");
            this.AñoPublicacion = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese la fecha de publicación del periódico (en formato dd/MM/yyyy):");
            DateTime fechaIngresada;

            // Leer la entrada del usuario y convertirla a DateTime
            while (!DateTime.TryParse(Console.ReadLine(), out fechaIngresada))
            {
                Console.WriteLine("Formato de fecha incorrecto. Por favor, ingrese una fecha válida (dd/MM/yyyy):");
            }

            this.FechaPublicacion = fechaIngresada;
        }
    }
}
