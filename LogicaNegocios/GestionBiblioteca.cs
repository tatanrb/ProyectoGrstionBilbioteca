using Gestion_de_Biblioteca.Entidades;
using Gestion_de_Biblioteca.Interfaces;
using Gestion_de_Biblioteca.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Biblioteca.LogicaNegocios
{
    public class GestionBiblioteca
    {
        public HashSet<Biblioteca> biblioteca;
        public HashSet<Usuario> usuarios;
        public HashSet<IPrestable> prestados;
        Dictionary<IPrestable, Queue<Usuario>> listaEspera = new Dictionary<IPrestable, Queue<Usuario>>();
        

        public GestionBiblioteca()
        {
            this.biblioteca = new HashSet<Biblioteca> { };
            this.usuarios = new HashSet<Usuario> { };
            this.prestados = new HashSet<IPrestable> ();
        }

        public void AgregarElemento(int tipoElemento)
        {
            Console.Write("Ingrese el título: ");
            string titulo = Console.ReadLine();

            Console.Write("Ingrese el autor: ");
            string autor = Console.ReadLine();

            Console.Write("Ingrese el año de publicacion: ");
            int annoPublicion = Convert.ToInt32(Console.ReadLine());

            // Libro
            if (tipoElemento == 1)
            {
                Console.Write("Ingrese el ISBN: ");
                string isbn = Console.ReadLine();

                Libro libro = new Libro(titulo, autor, annoPublicion, isbn);
                biblioteca.Add(libro);

                Console.WriteLine("Libro agregado correctamente");
            } 
            // Revista
            else if (tipoElemento == 2)
            {
                Console.Write("Ingrese el numero de edición: ");
                int numeroEdicion = Convert.ToInt32(Console.ReadLine());

                Revista revista = new Revista(titulo, autor, annoPublicion, numeroEdicion);
                biblioteca.Add(revista);

                Console.WriteLine("Libro agregado correctamente");
            } 
            // Periódico
            else if (tipoElemento == 3)
            {
                Console.WriteLine("Ingrese la fecha de publicación del periódico (en formato dd/MM/yyyy):");
                DateTime fechaIngresada;

                // Leer la entrada del usuario y convertirla a DateTime
                while (!DateTime.TryParse(Console.ReadLine(), out fechaIngresada))
                {
                    Console.WriteLine("Formato de fecha incorrecto. Por favor, ingrese una fecha válida (dd/MM/yyyy):");
                }

                Periodico periodico = new Periodico(titulo, autor, annoPublicion, fechaIngresada);
                biblioteca.Add(periodico);

                Console.WriteLine("Libro agregado correctamente");
            } else
            {
                Console.WriteLine("Opción inválida");
            }
        }

        public void DeshabilitarElemento()
        {
            // Convierte de HashSet a List porque HashSet no permite eliminar elementos en una posición
            List<Biblioteca> bibliotecasList = new List<Biblioteca>(biblioteca);

            // Recorre los elementos mostrando un índice para que el usuario elija cuál desea borrar
            for (int i = 0; i < bibliotecasList.Count; i++)
            {
                Console.Write($"{i+1}) ");
                bibliotecasList[i].MostrarInformacion();
                Console.WriteLine();
            }

            // Convertir opción a entero
            Console.Write("Ingrese la opción que desea deshabilitar: ");
            int posicion = Convert.ToInt32(Console.ReadLine());

            // Valida la opción escogida
            if (posicion < 1 || posicion > bibliotecasList.Count)
            {
                Console.WriteLine("Opción inválida");
            } else
            {
                // Cambia el estado a no disponible
                bibliotecasList[posicion - 1].CambiarEstado(Utilidades.EstadoLibro.NoDisponible);
                Console.WriteLine("Elemento deshabilitado con éxito");
                Console.WriteLine("Vuelve a consultar los elementos para ver los cambios reflejados!");

                // Devuelve la lista a hashset, sin el elemento que ya se deshabilitó
                biblioteca = new HashSet<Biblioteca>(bibliotecasList);
            }

        }

        public void ActualizarElemento()
        {
            // Convierte de HashSet a List porque HashSet no permite eliminar elementos en una posición
            List<Biblioteca> bibliotecasList = new List<Biblioteca>(biblioteca);

            // Recorre los elementos mostrando un índice para que el usuario elija cuál desea actualizar
            for (int i = 0; i < bibliotecasList.Count; i++)
            {
                Console.Write($"{i + 1}) ");
                bibliotecasList[i].MostrarInformacion();
                Console.WriteLine();
            }

            // Convertir opción a entero
            Console.Write("Ingrese la opción que desea actualizar: ");
            int posicion = Convert.ToInt32(Console.ReadLine());

            // Valida la opción escogida
            if (posicion < 1 || posicion > bibliotecasList.Count)
            {
                Console.WriteLine("Opción inválida");
            }
            else
            {
                // Cambia el estado a no disponible
                bibliotecasList[posicion - 1].ActualizarInformación();
                Console.WriteLine("Elemento actualizado con éxito");

                // Devuelve la lista a hashset, sin el elemento que ya se deshabilitó
                biblioteca = new HashSet<Biblioteca>(bibliotecasList);
            }

        }

        public void MostrarElementos()
        {
            Console.WriteLine("Mostrando información");
            foreach (Biblioteca itemBiblioteca in biblioteca)
            {
                itemBiblioteca.MostrarInformacion();
            }
        }

        public IPrestable ElegirPrestable(Usuario usuario)
        {
            // Filtrar e imprimir solo los elementos que implementan IPrestable (Libros y Revistas)
            Console.WriteLine("Elementos Prestables: ");
            int opcion = 1;
            foreach (var item in biblioteca.Where(b => b is IPrestable && b.Estado != EstadoLibro.NoDisponible).Cast<IPrestable>())
            {
                Console.Write(opcion + ") ");
                item.MostrarInformacion();
                Console.WriteLine();

                opcion++;
            }

            Console.WriteLine("Ingrese la opcion deseada: ");
            int opcionDeseada = Convert.ToInt32(Console.ReadLine());

            IPrestable elementoDeseado = null;

            opcion = 1;
            foreach (var item in biblioteca.Where(b => b is IPrestable && b.Estado != EstadoLibro.NoDisponible).Cast<IPrestable>())
            {
                if (opcion == opcionDeseada)
                {
                    elementoDeseado = item;
                    break;
                }

                opcion++;
            }
            if (elementoDeseado != null)
            {
                bool prestado = elementoDeseado.Prestar();

                if (!prestado)
                {
                    // Verificar si el IPrestable ya existe en el Dictionary
                    if (!listaEspera.ContainsKey(elementoDeseado))
                    {
                        // Si no existe, crear una nueva cola y agregarla al Dictionary
                        listaEspera[elementoDeseado] = new Queue<Usuario>();
                    }
                    listaEspera[elementoDeseado].Enqueue(usuario);
                    Console.WriteLine("Elemento añadido a la lista de espera");
                } else
                {
                    prestados.Add(elementoDeseado);
                }
            } else
            {
                Console.WriteLine("Elemento no encontrado o no está disponible");
            }

            return elementoDeseado;
        }

        public IPrestable RegistrarDevolucion(Usuario usuario)
        {

            // Filtrar elementos prestados usando LINQ
            var prestadosFiltrados = usuario.historialPrestamos.prestamos
                                        .Where(pair => pair.Key == EstadoPrestamo.Prestado)
                                        .SelectMany(pair => pair.Value).ToList();

            Console.WriteLine("Elementos Prestables: ");
            int opcion = 1;
            foreach (IPrestable prestable in prestadosFiltrados)
            {
                Console.Write($"{opcion}) ");
                prestable.MostrarInformacion();

                opcion++;
            }

            Console.WriteLine("Ingrese la opcion deseada: ");
            int opcionDeseada = Convert.ToInt32(Console.ReadLine());

            IPrestable elementoDeseado = null;

            opcion = 1;
            foreach (IPrestable prestable in prestadosFiltrados)
            {
                if (opcion == opcionDeseada)
                {
                    elementoDeseado = prestable;
                    break;
                }

                opcion++;
            }
            if (elementoDeseado != null)
            {
                usuario.historialPrestamos.RegistrarDevolucion(elementoDeseado);
                bool devuelto = elementoDeseado.Devolver();
                prestados.Remove(elementoDeseado);

                // Valida si se devolvió correctamente el elemento
                if (devuelto)
                {
                    prestadosFiltrados.Remove(elementoDeseado);
                    // Valida si existe una lista de espera por ese elemento
                    if (listaEspera.ContainsKey(elementoDeseado))
                    {
                        var listaUsuariosEspera = listaEspera[elementoDeseado];

                        // Valida que haya al menos un usuario en la lista de espera
                        if (listaUsuariosEspera.Count >= 1)
                        {
                            Usuario usuarioAsignarLibro = listaUsuariosEspera.Dequeue();

                            elementoDeseado.Prestar();
                            usuarioAsignarLibro.historialPrestamos.RegistrarPrestamo(elementoDeseado);
                            prestados.Add(elementoDeseado);
                        } else
                        {
                            Console.WriteLine("Elemento devuelto. No tiene lista de espera");
                        }
                    } else
                    {
                        Console.WriteLine("Elemento devuelto. No tiene lista de espera");
                    }
                }
            }

            return elementoDeseado;
        }

        public void MostrarElementosDisponibles()
        {
            foreach (Biblioteca item in biblioteca)
            {
                if (item.Estado == EstadoLibro.Disponible)
                {
                    item.MostrarInformacion();
                }
            }
        }

        public void MostrarElementosPrestados()
        {
            foreach (IPrestable item in prestados)
            {
                item.MostrarInformacion();
            }
        }

        // --------------------------

        public void AgregarElementosQuemados(List<Biblioteca> objects)
        {
            foreach (Biblioteca obj in objects)
            {
                biblioteca.Add(obj);
            }
        }

        public void AgregarRevistasQuemadas(List<Revista> objects)
        {
            foreach (Revista obj in objects)
            {
                biblioteca.Add(obj);
            }
        }

        public void AgregarPeriodicosQuemados(List<Periodico> objects)
        {
            foreach (Periodico obj in objects)
            {
                biblioteca.Add(obj);
            }
        }

        public void AgregarUsuariosQuemados(List<Usuario> objects)
        {
            foreach (Usuario obj in objects)
            {
                usuarios.Add(obj);
            }
        }
    }
}
