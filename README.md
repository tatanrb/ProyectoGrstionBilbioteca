# Gestión de Biblioteca

## Presentación
Link: https://youtu.be/8gy9oY7iP7o

## Descripción
Este proyecto es una aplicación de consola en C# diseñada para gestionar una biblioteca. Permite la administración de libros, revistas y periódicos, así como la gestión de usuarios y préstamos.

## Funcionalidades Principales

### 1. Gestión de Biblioteca

#### 1.1 Agregar Elemento
- Permite añadir nuevos libros, revistas o periódicos a la biblioteca.
- Opción: 1 > 1

#### 1.2 Editar Elemento
- Permite modificar la información de los elementos existentes.
- Opción: 1 > 2

#### 1.3 Deshabilitar Elemento
- Marca un elemento como no disponible.
- Opción: 1 > 3

#### 1.4 Mostrar Elementos
- Lista todos los elementos de la biblioteca.
- Opción: 1 > 4

### 2. Gestión de Usuarios y Préstamos

#### 2.1 Registrar Préstamo
- Permite prestar un elemento a un usuario.
- Opción: 2 > 1

#### 2.2 Registrar Devolución
- Registra la devolución de un elemento prestado.
- Opción: 2 > 2

#### 2.3 Consultar Libros Prestados de un Usuario
- Muestra los elementos actualmente prestados a un usuario específico.
- Opción: 2 > 3

#### 2.4 Consultar Historial de Préstamos de un Usuario
- Muestra todo el historial de préstamos de un usuario.
- Opción: 2 > 4

#### 2.5 Mostrar Elementos Disponibles
- Lista los elementos que pueden ser prestados.
- Opción: 2 > 5

#### 2.6 Mostrar Elementos Prestados
- Lista los elementos que están actualmente prestados.
- Opción: 2 > 6

## Características Adicionales

- **Inicialización Automática**: El sistema inicializa automáticamente una serie de libros, revistas, periódicos y usuarios para facilitar las pruebas.
- **Validaciones**: Incluye validaciones para evitar entradas nulas o vacías.
- **Manejo de Excepciones**: Proporciona una experiencia de usuario más robusta al manejar posibles errores.

## Cómo Usar

1. Ejecute el programa.
2. Se mostrará el menú principal con las siguientes opciones:
   - 1: Gestionar biblioteca
   - 2: Gestionar usuarios/préstamos
   - 3: Salir del programa
3. Seleccione una opción ingresando el número correspondiente.
4. Siga las instrucciones en pantalla para realizar la operación deseada.
5. Use la opción de "Volver al menú principal" para cambiar entre los menús de gestión.
6. Seleccione la opción "Salir del programa" en el menú principal para cerrar la aplicación.

## Estructura del Proyecto

El proyecto está organizado en varias clases y interfaces:

- `Program.cs`: Contiene el punto de entrada y la lógica principal del menú.
- `GestionBiblioteca`: Maneja la lógica de negocio para la gestión de la biblioteca.
- `Biblioteca`, `Libro`, `Revista`, `Periodico`: Representan los diferentes tipos de elementos en la biblioteca.
- `Usuario`: Representa a los usuarios de la biblioteca.
- `IPrestable`: Interfaz para los elementos que pueden ser prestados.

## Conclusión

Este proyecto proporciona una base sólida para un sistema de gestión de biblioteca, permitiendo un control eficiente de los elementos de la biblioteca y los préstamos a los usuarios.
