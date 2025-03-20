# Ruleta de Selección Aleatoria 🎡🎲

Este proyecto consiste en una ruleta de selección aleatoria para asignar roles a los participantes de una actividad o proyecto. Los roles incluyen "Desarrollador en Vivo" y "Facilitador de Ejercicio a Desarrollar", y se seleccionan aleatoriamente de una lista de participantes. También permite agregar, eliminar y editar participantes, así como ver un historial de las selecciones anteriores.

## Descripción

La aplicación está desarrollada en C# y permite:

- **Selección aleatoria** de roles para los participantes.
- **Agregar nuevos participantes** a la lista.
- **Eliminar participantes** de la lista.
- **Ver el historial** de selecciones previas.
- **Editar roles** asignados a los participantes.

## Requisitos

- .NET Core o .NET Framework.
- Un sistema operativo Windows (probado en Windows 10).

## Instalación

1. Clona este repositorio:

    ```bash
    git clone https://github.com/MarielyRoa/ruleta-seleccion.git
    ```

2. Navega al directorio del proyecto:

    ```bash
    cd ruleta-seleccion
    ```

3. Abre el proyecto en Visual Studio o en cualquier editor de tu preferencia que soporte C#.

4. Compila y ejecuta el proyecto.

## USO

Al ejecutar el programa, verás un menú con las siguientes opciones:

- **Iniciar la Ruleta**: Selecciona aleatoriamente un "Desarrollador en Vivo" y un "Facilitador de Ejercicio a Desarrollar".
- **Ver Participantes**: Muestra una lista de todos los participantes.
- **Roles ya asignados**: Muestra los roles asignados a los participantes.
- **Reiniciar la Ruleta**: Reinicia la selección de roles.
- **Ver Historial de Selección**: Muestra el historial de las selecciones anteriores.
- **Eliminar Historial de Selección**: Elimina el historial de selecciones previas.
- 

### 1. Selección aleatoria de roles
Utiliza la clase `Random` para seleccionar aleatoriamente dos roles: un "Desarrollador" y un "Facilitador". Se garantiza que la misma persona no pueda tener ambos roles.

### 2. Guardado de historial
Cada vez que se asignan los roles, se guardan en un archivo de texto con la fecha y el participante asignado. Esto permite tener un historial de las selecciones realizadas.

### 3. Menú interactivo
El programa cuenta con un menú interactivo que permite a los usuarios:
- Iniciar la ruleta para asignar los roles.
- Ver la lista completa de participantes.
  
## Estructura del Proyecto

### 1. Lista de Participantes

```csharp
// Lista de participantes
static List<string> alumno = new List<string> {
    "Abigail Rosario", "Branniel Peña", "Cristopher De Los Santos", "Diego Estrella",
    // ... otros participantes
};

```
### 2. Estructura del menú principal

```csharp
static void MenuPrincipal()
{
    while (true)
    {
        Console.WriteLine("\n🎡🎡🎡Bienvenidos a la ruleta de seleccion aleatoria🎡🎡🎡");
        Console.WriteLine("1. Iniciar la Ruleta 🎡🟢");
        Console.WriteLine("2. Participantes 🤸‍♀️🤸‍♂️");
        // ... otras opciones
        string input = Console.ReadLine();
        switch (input)
        {
            case "1":
                IniciarRuleta();
                break;
            case "2":
                VerParticipantes();
                break;
            // ... otras opciones
        }
    }
};

```
### 2. Función para iniciar la ruleta y asignar roles aleatoriamente

```
csharp
static void IniciarRuleta()
{
    Random random = new Random();
    int desarrollador = random.Next(alumno.Count);
    int facilitador = random.Next(alumno.Count);

    // Evitar que el desarrollador y facilitador sean la misma persona
    while (desarrollador == facilitador)
    {
        facilitador = random.Next(alumno.Count);
    }

    Console.WriteLine($"🎉 El desarrollador es: {alumno[desarrollador]}");
    Console.WriteLine($"🎉 El facilitador es: {alumno[facilitador]}");

    // Guardar en el historial
    GuardarHistorial(alumno[desarrollador], "Desarrollador");
    GuardarHistorial(alumno[facilitador], "Facilitador");
};

```
  Desarrollado por **Mariely Roa**
