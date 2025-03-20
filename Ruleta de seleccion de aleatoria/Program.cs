using System;
using System.IO;
using System.Security.AccessControl;
using System.Threading;

class Program {
    static List<string> alumno = new List<string>{
        "Abigail Rosario", "Branniel Peña", "Cristopher De Los Santos", "Diego Estrella", "Eddy Yail De Oleo", "Emilio Antonio Abreu",
        "Enrique Emmanuel De La Cruz", "Erick Gabriel Valenzuela", "Euddy Alberto Martínez", "Gabriel Rodriguez", "Joan Made", "Kenley De Los Santos",
        "Mariely Roa Baez", "Maryam Mateo", "Mathew Hereford", "Miguel Angel De Jesús", "Miguel José Mateo Díaz", "Noel Felipe Estrella",
        "Pablo Joel Hernandez", "Reynolds Rosario Asencio"
    };

    static string Historial = @"C:\Users\Public\Competencia\HISTORIAL.txt";
    static string ArchivoNuevosParticipantes = @"C:\Users\Public\Competencia\ArchivoNuevosParticipantes.txt";
    static string archivoUltimaSeleccion = @"C:\Users\Public\Competencia\UltimaSeleccion.txt";
    static string[] rol = new string[alumno.Count];  
    static bool[] asignadoDesarrollador = new bool[alumno.Count]; 
    static bool[] asignadoFacilitador = new bool[alumno.Count];
    static bool continuar = true;
    static void Main(string[] args){
        
        CargarArhivoParticipantes();

        MostrarBienvenida();

        MenuPrincipal();
    }

    static void MenuPrincipal(){

        while(continuar){

        Console.WriteLine("\n                       🎡🎡🎡Bienvenidos a la ruleta de seleccion aleatoria🎡🎡🎡");
        Console.WriteLine("  🔁══════════════════════════════════════🔁 ");
        Console.WriteLine(" ‖                                           ‖");
        Console.WriteLine(" ‖    🎡⭕OPCIONES⭕🎡                     ‖"); 
        Console.WriteLine(" ‖ 1. Iniciar la Ruleta 🎡🟢                ‖"); 
        Console.WriteLine(" ‖ 2. Participantes 🤸‍♀️🤸‍♂️                    ‖");
        Console.WriteLine(" ‖ 3. Roles ya asignados 👩‍💻👨‍💻               ‖"); 
        Console.WriteLine(" ‖ 4. Reiniciar la ruleta 🎡♻               ‖"); 
        Console.WriteLine(" ‖ 10. Ver Historial Seleccion 📑            ‖"); 
        Console.WriteLine(" ‖ 6. Eliminar Historial de Seleccion ❌📑  ‖"); 
        Console.WriteLine(" ‖ 7. Salir 🔚                              ‖");  
        Console.WriteLine("  🔁══════════════════════════════════════🔁 ");

        
        
        Console.Write("🔠 Seleccione una opción: ");
        string input = Console.ReadLine()?.Trim() ?? ""; // Captura la entrada y elimina espacios en blanco

        if (!int.TryParse(input, out int opcion)) // Intenta convertir a número
        {
            Console.WriteLine("❌ Opción inválida. Debe ingresar un número entre 1 y 7.");
            continue; // Vuelve a mostrar el menú si la conversión falla
        }

            switch(opcion){

                case 1:
                    AnimarTexto("🎡 Iniciando la ruleta... 🎲", 10);
                    IniciarRuleta();
                break;

                case 2:
                
                    AnimarTexto("🤸‍♀️🤸‍♂️ Cargando participantes... 🤸‍♀️🤸‍♂️", 10);
                    Participantes();
                break;

                case 3:
                    AnimarTexto("👩‍💻 Cargando roles asignados... 👨‍💻", 10);
                    RolesAsignados();
                break;

                case 4:
                    AnimarTexto("♻️ Reiniciando la ruleta... 🔄", 10);
                    ReiniciarRuleta();
                break;

                case 10:
                    AnimarTexto("📋 Cargando historial de selección... 📑", 10);
                    HistorialDeSeleccion();
                break;

                case 6:
                    AnimarTexto("🗑️ Eliminando historial... ❌", 10);
                    EliminarHistorialUltimaSeleccion();
                break;

                case 7:
                    AnimarTexto("😊 Gracias por usar la Ruleta de Selección. ¡Te espero pronto! 🚪", 10);
                    continuar = false;
                break;

                default:
                    Console.WriteLine("❌ Opcion invalida, numero fuera de rango de (1 y 7)");
                continue;
                }
        }
    }

    static void AnimarTexto(string texto, int velocidad) {
            foreach (char c in texto) {
                Console.Write(c);
                Thread.Sleep(velocidad);
            }
            Console.WriteLine();
            Thread.Sleep(10);
    }

    static void MostrarBienvenida(){
    
        Console.Write(@"
                    🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲
                    🎲           ____    _    _   _     _____ _____  ___                    🎲
                    🎲          |  _ \  | |  | | | |   | ____|_   _|/ \ \                   🎲
                    🎲          | |_) | | |  | | | |   |   |   | | / _ \ \                  🎲
                    🎲          |  _ <  | |  | | | |___| |___  | |/ ___ \ \                 🎲
                    🎲          |_| \_\ \_\__/ / | |___|_____| |_/_/   \_\ \                🎲
                    🎲          ============================================                🎲
                    🎲          _    _     _____    _  _____ ___  ____  ___    _            🎲
                    🎲         / \  | |   | ____|  / \|_   _/ _ \|  _ \|_ _|  / \\          🎲
                    🎲        / _ \ | |   |  _|   / _ \ | || | | | |_) || |  / _ \\         🎲
                    🎲       / ___ \| |___| |___ / ___ \| || |_| |  _ < | | / ___ \\        🎲
                    🎲      /_/   \_\_____|_____/_/   \_\_| \___/|_| \_\___/_/   \_\\       🎲
                    🎲                                                                      🎲
                    🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲🎲 ");
        

        }


    static void IniciarRuleta() {

        
        AnimarTexto("\n                     ⌛⌛⌛  INICIANDO LA RULETA ⌛⌛⌛                   ", 10);
        Console.WriteLine("  🔁═══════════════════════════════════════════════════════════════════🔁 ");
        

        bool Asignados = true;

    // Revisar que no hayan roles asignados
        for (int i = 0; i < alumno.Count; i++) {
            if (!asignadoDesarrollador[i] || !asignadoFacilitador[i]) 
            {
                Asignados = false;
                break;
            }
        }

        if (Asignados || alumno.Count < 2) {
            Console.WriteLine("❌ No hay suficientes participantes.");
            Console.WriteLine("⭕ Presiona 'R' para reiniciar o cualquier otra tecla para regresar al menú principal.");
            AnimarTexto("🎡Recordatorio: Tambien puedes agregar mas participantes si te quedaste sin giros 🎡", 10);

            string input = Console.ReadLine() ?? "";

                if (!string.IsNullOrEmpty(input) && input.ToUpper() == "R") 
                {
                    ReiniciarRuleta();
                }
            return;
        }

        Random aleatorio = new Random();
        int Desarrollador, Facilitador;

        do {
            Desarrollador = aleatorio.Next(alumno.Count);
        } while (asignadoDesarrollador[Desarrollador]);

        do {
            Facilitador = aleatorio.Next(alumno.Count);
        } while (asignadoFacilitador[Facilitador] || Desarrollador == Facilitador);

        if (Desarrollador >= alumno.Count || Facilitador >= alumno.Count) 
        {
            Console.WriteLine("❌ Índice fuera de rango.");
            return;
        }

        rol[Desarrollador] = "Desarrollador en Vivo";
        rol[Facilitador] = "Facilitador de Ejercicio a Desarrollar";
        asignadoDesarrollador[Desarrollador] = true;
        asignadoFacilitador[Facilitador] = true;

        AnimarTexto("🤸‍♂️Seleccionando Estudiantes🤸‍♀️", 10);

        Console.WriteLine($"👨‍💻 Estudiante 1: {alumno[Desarrollador]}, Rol: Desarrollador en Vivo");
        Console.WriteLine($"👩‍🏫 Estudiante 2: {alumno[Facilitador]}, Rol: Facilitador de Ejercicio a Desarrollar");


        GuardarHistorial(alumno[Desarrollador], rol[Desarrollador]);
        GuardarHistorial(alumno[Facilitador], rol[Facilitador]);

        // Guardar ambas selecciones en el archivo de "ÚltimaSeleccion.txt"
        GuardarUltimaSeleccion(alumno[Desarrollador], rol[Desarrollador]);
        GuardarUltimaSeleccion(alumno[Facilitador], rol[Facilitador]);

        Console.WriteLine("\nPresiona cualquier tecla para continuar...");    
        return;
    }

     static void GuardarHistorial(string estudiante, string rol){
       
        try
        {

            using (StreamWriter writer = new StreamWriter(Historial, true))
            {
                writer.WriteLine($"{DateTime.Now} - {estudiante} - {rol}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("❌ Error al guardar el historial: " + ex.Message);
        }
    }

    static void GuardarUltimaSeleccion(string estudiante, string rol) {
        try {
            using (StreamWriter writer = new StreamWriter(@"C:\Users\Public\Competencia\UltimaSeleccion.txt", true)) 
            {
                writer.WriteLine($"{DateTime.Now} - {estudiante} - {rol}");
            }
        } catch (Exception ex) 
        {
            Console.WriteLine("❌ Error al guardar la última selección: " + ex.Message);
        }
    }

    static void Participantes(){

        while(continuar){
        Console.WriteLine("\n                       🎡🎡🎡Bienvenido a la seccion de participantes🎡🎡🎡");
        
        Console.WriteLine("  🔁══════════════════════════════════🔁 ");
        Console.WriteLine(" ‖    🎡⭕OPCIONES⭕🎡                  ‖");
        Console.WriteLine(" ‖ 1. Ver lista de participantes 📃      ‖");
        Console.WriteLine(" ‖ 2. Agregar participante 📖🖋          ‖");
        Console.WriteLine(" ‖ 3. Eliminar Participante ❌📃         ‖");
        Console.WriteLine(" ‖ 4. Editar Rol  📝                     ‖");
        Console.WriteLine(" ‖ 10. Volver al menu principal 🏠        ‖");
        Console.WriteLine(" ‖ 6. Salir 🔚                           ‖");
        Console.WriteLine("  🔁══════════════════════════════════🔁 ");


        Console.WriteLine("🔠 Seleccione una opción: ");
        string input2 = Console.ReadLine()?.Trim() ?? ""; // Captura la entrada y elimina espacios en blanco

        if (!int.TryParse(input2, out int opcion2)) // Intenta convertir a número
        {
            Console.WriteLine("❌ Opción inválida. Debe ingresar un número entre 1 y 7.");
            continue; // Vuelve a mostrar el menú si la conversión falla
        }

            switch(opcion2){

                case 1:
                    AnimarTexto("📋 Cargando lista de participantes... 📃", 10);
                    Verparticipantes(); 
                break;
                    
                case 2:
                    AnimarTexto("➕ Agregando nuevo participante... 📝", 10);
                    AgregarParticipante();
                break;

                case 3:
                    AnimarTexto("❌ Eliminando participante... 🗑️", 10);
                    EliminarParticipante();
                break;

                case 4:
                    AnimarTexto("🔄 Editando rol de participante... 📝", 10);
                    EditarRol();
                break;

                case 10:
                    MostrarBienvenida();
                    MenuPrincipal();
                break;

                case 6:
                    AnimarTexto("😊 Gracias por usar la Ruleta de Selección. ¡Te espero pronto! 🚪", 10);
                    continuar = false;
                break;

                default:
                    Console.WriteLine("❌ Opcion invalida");
                break;
            }
        }

    }

     static void Verparticipantes(){
        
        Console.WriteLine("\n                     📋📋📋 LISTA DE PARTICIPANTES 📋📋📋               ");
        Console.WriteLine("  🔁═══════════════════════════════════════════════════════════════════🔁 ");

        
        for (int i = 0; i < alumno.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {alumno[i]}");
        }
        
        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
        return;
    }

    static void AgregarParticipante(){

        Console.WriteLine("\n                     ➕➕➕  AGREGAR PARTICIPANTES ➕➕➕                ");
        Console.WriteLine("  🔁═══════════════════════════════════════════════════════════════════🔁 ");

        
        string nuevoParticipante = "";
        bool nombreValido = false;

        while (!nombreValido){
            
            Console.WriteLine("Ingrese el nombre del nuevo participante:");
            nuevoParticipante = Console.ReadLine()?.ToLower().Trim() ?? "";

            if (string.IsNullOrWhiteSpace(nuevoParticipante))
            {
                Console.WriteLine("❌ Nombre inválido. No puede estar vacío.");
            }
            else if (!nuevoParticipante.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                Console.WriteLine("❌ Nombre inválido. Solo se permiten letras y espacios.");
            }
            else if (alumno.Any(p => p.Equals(nuevoParticipante, StringComparison.OrdinalIgnoreCase)))
            {
                AnimarTexto("👩‍💻Validando la informacion👨‍💻",10);
                Console.WriteLine($"⚠️ El participante '{nuevoParticipante}' ya está en la lista.");
            }
            else
            {
                nombreValido = true; // El nombre es válido, salimos del bucle
            }
        }

        // Agregar el nuevo participante
        alumno.Add(nuevoParticipante);

        // Redimensionar los arrays
        Array.Resize(ref rol, alumno.Count);
        Array.Resize(ref asignadoDesarrollador, alumno.Count);
        Array.Resize(ref asignadoFacilitador, alumno.Count);

        // Guardar en el archivo
        try
        {
            using (StreamWriter writer = File.AppendText(ArchivoNuevosParticipantes))
            {
                writer.WriteLine(nuevoParticipante);
            }
            AnimarTexto("👩‍💻Validando la informacion👨‍💻",10);
            Console.WriteLine($"✅ {nuevoParticipante} ha sido agregado correctamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error al guardar en el archivo: {ex.Message}");
        }

        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
    }

    static void EliminarParticipante(){

        
        Console.WriteLine("\n                     ❌❌❌  ELIMINAR PARTICIPANTES ❌❌❌            ");
        Console.WriteLine("  🔁═══════════════════════════════════════════════════════════════════🔁 ");

        

        Console.WriteLine("Escriba el nombre del participante para eliminar: ");
        string nombre = Console.ReadLine()?.ToLower() ?? "";

        bool encontrar = false;

        for (int i = 0; i < alumno.Count; i++) 
        {
            if (alumno[i].Equals(nombre, StringComparison.OrdinalIgnoreCase))
            {
                encontrar = true;
                alumno.RemoveAt(i);

                // Redimensionar los arrays después de la eliminación
                Array.Resize(ref rol, alumno.Count);
                Array.Resize(ref asignadoDesarrollador, alumno.Count);
                Array.Resize(ref asignadoFacilitador, alumno.Count);

                break;
            } 
        }

        if (encontrar)
        {
            // Eliminar del archivo de ArchivoNuevosParticipantes
            var participantes = File.ReadAllLines(ArchivoNuevosParticipantes);
            var updatedParticipants = new List<string>(participantes);
            updatedParticipants.Remove(nombre);
            File.WriteAllLines(ArchivoNuevosParticipantes, updatedParticipants);

            AnimarTexto("👩‍💻Validando la informacion👨‍💻",10);
            Console.WriteLine($"✅ {nombre} ha sido eliminado correctamente.");

        }else{
            AnimarTexto("👩‍💻Validando la informacion👨‍💻",10);
            Console.WriteLine("❌ No se encontró el participante.");
        }
    }

    static void EditarRol(){

        Console.WriteLine("\n                     📝📝📝  EDITAR ROLES 📝📝📝                      ");
        Console.WriteLine("  🔁═══════════════════════════════════════════════════════════════════🔁 ");

        

        Console.WriteLine("Escriba el nombre del participante para editar su rol: ");
        string nombre = Console.ReadLine() ?? "";

        for (int i = 0; i < alumno.Count; i++)
        {
            if (alumno[i].Equals(nombre, StringComparison.OrdinalIgnoreCase)){

                if (string.IsNullOrEmpty(rol[i])) {
                    Console.WriteLine($"El participante {nombre} no tiene rol asignado aún.");
                }else{
                    Console.WriteLine($"El rol actual de {nombre} es: {rol[i]}");
                }

        Console.WriteLine("Ingrese el nuevo rol: (Desarrollador en vivo) o (Facilitador de ejercicio) ");

        AnimarTexto("OJO, 👩‍🏫 Tambien puede ser un Rol personalizado 👨‍🎓",10);
        
        string nuevoRol = Console.ReadLine() ?? "";

        if (!string.IsNullOrEmpty(nuevoRol)) {
                    // Asignar el nuevo rol
            rol[i] = nuevoRol;
            GuardarHistorial(alumno[i], nuevoRol);
            GuardarUltimaSeleccion(alumno[i], nuevoRol);

            AnimarTexto("👩‍💻Validando la informacion👨‍💻",10);
            Console.WriteLine($"{nombre} ha sido actualizado con el nuevo rol: {nuevoRol}");
        } else {
            Console.WriteLine("Rol inválido. No se realizó ningún cambio.");
            }
            break;
            }
        }

        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
   
    }
   
    static void RolesAsignados(){
    

        Console.WriteLine("\n                     📝📝📝  ROLES ASIGNADOS 📝📝📝                   ");
        Console.WriteLine("  🔁═══════════════════════════════════════════════════════════════════🔁 ");

        


        // Verificar si el archivo existe y tiene contenido
        if (File.Exists(Historial) && new FileInfo(Historial).Length > 0)
        {
            Console.WriteLine("\n 📑Historial de Roles Asignados: 📘");
            Console.WriteLine("═════════════════════════════════════");
            string[] historial = File.ReadAllLines(Historial);

            Array.Sort(historial);
                for (int i = 0; i < historial.Length; i++){
                string linea_por_linea = historial[i];

                Console.WriteLine($"{i + 1}: {linea_por_linea}");
            }
            Console.WriteLine("═════════════════════════════════════");
        }
        else
        {
            AnimarTexto("❌ No hay historial registrado o el archivo está vacío.",10);
        }
        
        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
        return;
    }


    static void ReiniciarRuleta() {
        // Asegurarnos de que los arrays tienen el mismo tamaño que la lista 'alumno'
        Array.Resize(ref rol, alumno.Count);
        Array.Resize(ref asignadoDesarrollador, alumno.Count);
        Array.Resize(ref asignadoFacilitador, alumno.Count);

        for (int i = 0; i < alumno.Count; i++) {
            rol[i] = null ?? "";  // Limpiar los roles asignados
            asignadoDesarrollador[i] = false; 
            asignadoFacilitador[i] = false;  // Marcar que el estudiante no ha sido asignado
        }

        if (File.Exists(Historial)) 
        {
            File.Delete(Historial);  // Para limpiar el historial
        }

        //Para Crear un nuevo historial vacío
        try {
            using (StreamWriter writer = new StreamWriter(Historial, false)) {
                
            }
        } catch (Exception ex) {
            Console.WriteLine("❌ Error al crear el nuevo historial: " + ex.Message);
        }

        AnimarTexto(" 🎡La ruleta ha sido reiniciada. Los roles ahora están disponibles para asignar nuevamente. 🎡", 10);
    }


    static void CargarArhivoParticipantes(){

        if(File.Exists(ArchivoNuevosParticipantes))
        {
            var nuevoParticipante = File.ReadAllLines(ArchivoNuevosParticipantes);

            foreach (var participante in nuevoParticipante){
                if(!string.IsNullOrEmpty(participante) && !alumno.Contains(participante))
                {
                    alumno.Add(participante);
                }
            }
        }

    }

    static void HistorialDeSeleccion(){
        if (File.Exists(archivoUltimaSeleccion) && new FileInfo(archivoUltimaSeleccion).Length > 0)
        {
            Console.WriteLine("\n 📖 Historial de selecciones: 📖");
            Console.WriteLine("═════════════════════════════════════");
            string[] UltimaSeleccion = File.ReadAllLines(archivoUltimaSeleccion);

            Array.Sort(UltimaSeleccion);
                for (int i = 0; i < UltimaSeleccion.Length; i++){
                string linea_por_linea = UltimaSeleccion[i];

                Console.WriteLine($"{i + 1}: {linea_por_linea}");
            }
            Console.WriteLine("═════════════════════════════════════");
        }
        else
        {
            AnimarTexto("👩‍💻Validando la informacion👨‍💻", 10);
            Console.WriteLine("❌ No hay historial registrado o el archivo está vacío.");
        }
        
        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
        return;
    }

     static void EliminarHistorialUltimaSeleccion(){

        if (File.Exists(archivoUltimaSeleccion))
        {
            // Eliminar el archivo completo
            File.Delete(archivoUltimaSeleccion);

            AnimarTexto("👩‍💻Validando la informacion👨‍💻",10);
            Console.WriteLine("✅ Historial de la última selección eliminado.");
        }else{
            Console.WriteLine("❌ El archivo 'UltimaSeleccion.txt' no existe.");
        }

        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
    }
    

}
