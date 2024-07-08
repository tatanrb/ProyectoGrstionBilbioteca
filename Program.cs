using Gestion_de_Biblioteca.Entidades;
using Gestion_de_Biblioteca.Interfaces;
using Gestion_de_Biblioteca.LogicaNegocios;
using System.Runtime.CompilerServices;

namespace Gestion_de_Biblioteca
{
    internal class Program
    {
        public static GestionBiblioteca gestionBiblioteca = new GestionBiblioteca();
        static void Main(string[] args)
        {
            // Inicialización de libros
            Biblioteca libro1 = new Libro("El Principito", "Antoine de Saint-Exupéry", 1943, "9780156013925");
            Biblioteca libro2 = new Libro("Cien años de soledad", "Gabriel García Márquez", 1967, "9780307350434");
            Biblioteca libro3 = new Libro("1984", "George Orwell", 1949, "9780451524935");
            Biblioteca libro4 = new Libro("El Hobbit", "J.R.R. Tolkien", 1937, "9780547928227");
            Biblioteca libro5 = new Libro("Don Quijote de la Mancha", "Miguel de Cervantes", 1605, "9788420412146");
            List<Biblioteca> libros = new List<Biblioteca> { libro1, libro2, libro3, libro4, libro5 };
            gestionBiblioteca.AgregarElementosQuemados(libros);

            // Inicialización de revistas
            Revista revista1 = new Revista("National Geographic", "National Geographic Society", 1888, 1);
            Revista revista2 = new Revista("Time", "Time USA, LLC", 1923, 1);
            Revista revista3 = new Revista("Scientific American", "Springer Nature", 1845, 1);
            Revista revista4 = new Revista("The New Yorker", "Condé Nast", 1925, 1);
            Revista revista5 = new Revista("Nature", "Nature Publishing Group", 1869, 1);
            List<Revista> revistas = new List<Revista> { revista1, revista2, revista3, revista4, revista5 };
            gestionBiblioteca.AgregarRevistasQuemadas(revistas);

            // Inicializacion de periodicos
            Periodico periodico1 = new Periodico("The New York Times", "The New York Times Company", 1851, new DateTime(2024, 7, 1));
            Periodico periodico2 = new Periodico("The Guardian", "Guardian Media Group", 1821, new DateTime(2024, 7, 2));
            Periodico periodico3 = new Periodico("Le Monde", "Groupe Le Monde", 1944, new DateTime(2024, 7, 3));
            Periodico periodico4 = new Periodico("El País", "PRISA", 1976, new DateTime(2024, 7, 4));
            Periodico periodico5 = new Periodico("The Wall Street Journal", "Dow Jones & Company", 1889, new DateTime(2024, 7, 5));
            List<Periodico> periodicos = new List<Periodico> { periodico1, periodico2, periodico3, periodico4, periodico5 };
            gestionBiblioteca.AgregarPeriodicosQuemados(periodicos);

            // Inicialización de usuarios
            Usuario usuario1 = new Usuario("Jonnathan", 1);
            Usuario usuario2 = new Usuario("Kenneth", 2);
            Usuario usuario3 = new Usuario("Pablo", 3);
            List<Usuario> usuarios = new List<Usuario> { usuario1, usuario2, usuario3 };
            gestionBiblioteca.AgregarUsuariosQuemados(usuarios);



            // Inicia el sistema
            MostrarMenu();
        }

        public static void MostrarMenu()
        {
            bool salir = false;
            do
            {
                try
                {
                    Console.WriteLine("\n------------ BIENVENIDO AL SISTEMA DE GESTION DE BIBLIOTECA ------------");
                    Console.Write($"Opciones: \n\t1) Gestionar biblioteca (Libros, revistas y periódicos)" +
                        $"\n\t2) Gestionar usuarios/préstamos " +
                        $"\n\t3) Salir del programa..." +
                        $"\nOpción: ");
                    string opcion = Console.ReadLine();

                    // Validar que el valor no sea nulo ni esté vacío
                    while (string.IsNullOrEmpty(opcion))
                    {
                        Console.Write("El valor ingresado no puede ser nulo o vacío. Intente nuevamente: ");
                        opcion = Console.ReadLine();
                    }

                    switch (opcion)
                    {
                        case "1":
                            {
                                GestionarBiblioteca();
                                break;
                            }

                        case "2":
                            {
                                GestionarUsuarios();
                                break;
                            }

                        case "3":
                            {
                                Console.WriteLine("Saliendo, vuelva pronto!...");
                                salir = true;
                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hubo un fallo, vuelve a intentarlo");
                }
            } while (!salir);
            
            
        }

        public static void GestionarBiblioteca()
        {
            bool salir = false;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Gestión de biblioteca: ");
                Console.WriteLine($"\t1) Agregar elemento " +
                    $"\n\t2) Editar elemento " +
                    $"\n\t3) Deshabilitar elemento" +
                    $"\n\t4) Mostrar elementos" +
                    $"\n\t5) Volver al menú principal");

                string opcion = Console.ReadLine();

                // Validar que el valor no sea nulo ni esté vacío
                while (string.IsNullOrEmpty(opcion))
                {
                    Console.Write("El valor ingresado no puede ser nulo o vacío. Intente nuevamente: ");
                    opcion = Console.ReadLine();
                }

                switch (opcion)
                {
                    case "1":
                        {
                            Console.Write("Elija: 1) Libro, 2) Revista o 3) Periodico: ");
                            int subOpcion = Convert.ToInt32(Console.ReadLine());
                            gestionBiblioteca.AgregarElemento(subOpcion);
                            break;
                        }

                    case "2":
                        {
                            gestionBiblioteca.ActualizarElemento();
                            break;
                        }

                    case "3":
                        {
                            gestionBiblioteca.DeshabilitarElemento();
                            break;
                        }

                    case "4":
                        {
                            gestionBiblioteca.MostrarElementos();
                            break;
                        }
                    case "5":
                        {
                            Console.WriteLine("Volviendo al menú principal");
                            salir = true;
                            break;
                        }
                }
            } while (!salir);
        }

        public static void GestionarUsuarios()
        {
            bool salir = false;
            do
            {
                Console.WriteLine();
                Console.WriteLine("\nGestión de usuarios: ");
                Console.WriteLine($"\n\t1) Registrar préstamo" +
                    $"\n\t2) Registrar devolucion" +
                    $"\n\t3) Consultar libros prestados de un usuario" +
                    $"\n\t4) Consultar historial de préstamos de un usuario " +
                    $"\n\t5) Mostrar elementos disponibles" +
                    $"\n\t6) Mostrar elementos prestados" +
                    $"\n\t7) Volver al menú principal" +
                    $"\nOpción: ");

                string opcion = Console.ReadLine();

                // Validar que el valor no sea nulo ni esté vacío
                while (string.IsNullOrEmpty(opcion))
                {
                    Console.Write("El valor ingresado no puede ser nulo o vacío. Intente nuevamente: ");
                    opcion = Console.ReadLine();
                }

                switch (opcion)
                {
                    case "1":
                        {
                            RegistrarPrestamo();
                            break;
                        }
                    case "2":
                        {
                            RegistrarDevolucion();
                            break;
                        }
                    case "3":
                        {
                            MostrarPrestamosUsuario();
                            break;
                        }

                    case "4":
                        {
                            Console.Write("Ingrese el id del usuario: ");
                            int idUsuario = Convert.ToInt32(Console.ReadLine());
                            Usuario usuarioEncontrado = null;

                            // Buscar usuario
                            foreach (Usuario usuario in gestionBiblioteca.usuarios)
                            {
                                if (usuario.IDUsuario == idUsuario)
                                {
                                    usuarioEncontrado = usuario;
                                    break;
                                }
                            }

                            if (usuarioEncontrado != null)
                            {
                                usuarioEncontrado.historialPrestamos.ImprimirHistorial();
                            }
                            break;
                        }

                    case "5":
                        {
                            gestionBiblioteca.MostrarElementosDisponibles();
                            break;
                        }
                    case "6":
                        {
                            gestionBiblioteca.MostrarElementosPrestados();
                            break;
                        }
                    case "7":
                        {
                            Console.WriteLine("Volviendo al menú principal");
                            salir = true;
                            break;
                        }
                }
            } while (!salir);
        }

        public static void RegistrarPrestamo()
        {
            Console.Write("Ingrese el id del usuario: ");
            int idUsuario = Convert.ToInt32(Console.ReadLine());
            Usuario usuarioEncontrado = null;

            // Buscar usuario
            foreach (Usuario usuario in gestionBiblioteca.usuarios)
            {
                if (usuario.IDUsuario == idUsuario)
                {
                    usuarioEncontrado = usuario;
                    break;
                }
            }

            // Buscar elemento que se desea prestar


            if (usuarioEncontrado != null)
            {
                IPrestable prestable = gestionBiblioteca.ElegirPrestable(usuarioEncontrado);

                if (prestable != null)
                {
                    usuarioEncontrado.historialPrestamos.RegistrarPrestamo(prestable);
                }
                
            } else
            {
                Console.WriteLine("Usuario no encontrado!");
            }
        }

        public static void RegistrarDevolucion()
        {
            Console.Write("Ingrese el id del usuario: ");
            int idUsuario = Convert.ToInt32(Console.ReadLine());
            Usuario usuarioEncontrado = null;

            // Buscar usuario
            foreach (Usuario usuario in gestionBiblioteca.usuarios)
            {
                if (usuario.IDUsuario == idUsuario)
                {
                    usuarioEncontrado = usuario;
                    break;
                }
            }

            // Buscar elemento que se desea prestar


            if (usuarioEncontrado != null)
            {
                gestionBiblioteca.RegistrarDevolucion(usuarioEncontrado);

            }
            else
            {
                Console.WriteLine("Usuario no encontrado!");
            }
        }

        public static void MostrarPrestamosUsuario()
        {
            Console.Write("Ingrese el id del usuario: ");
            int idUsuario = Convert.ToInt32(Console.ReadLine());
            Usuario usuarioEncontrado = null;

            // Buscar usuario
            foreach (Usuario usuario in gestionBiblioteca.usuarios)
            {
                if (usuario.IDUsuario == idUsuario)
                {
                    usuarioEncontrado = usuario;
                    break;
                }
            }

            // Buscar elemento que se desea prestar


            if (usuarioEncontrado != null)
            {
                usuarioEncontrado.historialPrestamos.ImprimirPrestados();

            }
            else
            {
                Console.WriteLine("Usuario no encontrado!");
            }
        }
    }
}
