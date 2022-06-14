using MyJournalLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyJournalConsole
{
    public static class PresentationLogic
    {
        public static void PrintMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Seleccione una opción.");
            Console.WriteLine("1. Listar entradas");
            Console.WriteLine("2. Agregar entrada");
            Console.WriteLine("3. Modificar entrada");
            Console.WriteLine("4. Eliminar entrada");
            Console.WriteLine("5. Cargar desde archivo");
            Console.WriteLine("6. Guardar a archivo");
            Console.WriteLine("7. Eliminar archivo");
            Console.WriteLine("0. Salir");
            Console.Write("Su elección: ");
        }
        public static void PrintWelcome()
        {
            Console.WriteLine("\n");
            Console.WriteLine("------------------------");
            Console.WriteLine("|Bienvenido a MyJournal|");
            Console.WriteLine("------------------------");
            Console.WriteLine("\n");
        }
        public static void PrintQuit()
        {
            Console.WriteLine("\n");
            Console.WriteLine("------------------------");
            Console.WriteLine("|Gracias por usar la app|");
            Console.WriteLine("------------------------");
            Console.WriteLine("\n");
        }
        public static void AddEntry(LogicLayer logic)
        {
            string content;
            DateTime date;
            Console.WriteLine();
            Console.Write("Agregue su información: ");
            content = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Agregue la fecha: ");
            date = Convert.ToDateTime(Console.ReadLine());

            logic.AddEntry(content, date);

        }
        public static void AddEntryNow(LogicLayer logic)
        {
            string content;
            DateTime date;
            Console.WriteLine();
            Console.Write("Agregue su información: ");
            content = Console.ReadLine();
            date = DateTime.Now;

            logic.AddEntry(content, date);

        }
        public static void ListEntries(LogicLayer logic)
        {
            Console.WriteLine();
            if (logic.Entries.Count < 1)
            {
                Console.WriteLine("La lista esta vacía");
                return;
            }
            Console.WriteLine("\nListado de entradas: ");
            int i = 0;
            foreach(var item in logic.Entries)
            {
                Console.WriteLine(i.ToString()+". Contenido: "+ item.Content + " Fecha: " + item.Date);
                i++;    
            }

            Console.WriteLine("\nFin del listado");

        }

        public static void ModifyEntry(LogicLayer logic)
        {
            Console.WriteLine();
            int index;
            string content,date;
            DateTime dtDate;
            if (logic.Entries.Count < 1)
            {
                Console.WriteLine("La lista esta vacía");
                return;
            }
            Console.WriteLine("\nListado de entradas: ");
            int i = 0;
            foreach (var item in logic.Entries)
            {
                Console.WriteLine(i.ToString() + ". Contenido: " + item.Content + " Fecha: " + item.Date);
                i++;
            }
            Console.WriteLine("\nFin del listado");
            Console.WriteLine("Si no desea modificar el valor, solo aprete enter.");
            Console.Write("Seleccione el indice de la entrada a modificar: ");
            index = Convert.ToInt32(Console.ReadLine().Trim());
            if(index < 0 || index >= logic.Entries.Count)
            {
                Console.WriteLine("\nEl indice esta fuera de rango!");
                return;
            }
            Console.Write("Nuevo contenido: ");
            content = Console.ReadLine().Trim();
            Console.Write("Nueva fecha: ");
            date = Console.ReadLine().Trim();

            if (string.IsNullOrEmpty(content))
            {
                content = logic.Entries[index].Content;
            }
            if (string.IsNullOrEmpty(date))
            {
                dtDate = logic.Entries[index].Date;
            }
            else
            {
                dtDate = Convert.ToDateTime(date);
            }
            logic.ModifyEntry(index, content, dtDate);
            Console.WriteLine();

        }

        public static void DeleteEntry(LogicLayer logic)
        {
            Console.WriteLine();
            int index;
            if (logic.Entries.Count < 1)
            {
                Console.WriteLine("La lista esta vacía");
                return;
            }
            Console.WriteLine("\nListado de entradas: ");
            int i = 0;
            foreach (var item in logic.Entries)
            {
                Console.WriteLine(i.ToString() + ". Contenido: " + item.Content + " Fecha: " + item.Date);
                i++;
            }
            Console.WriteLine("\nFin del listado");
            Console.Write("Seleccione el indice de la entrada a eliminar: ");
            index = Convert.ToInt32(Console.ReadLine().Trim());
            if (index < 0 || index >= logic.Entries.Count)
            {
                Console.WriteLine("\nEl indice esta fuera de rango!");
                return;
            }

            logic.DeleteEntry(index);
            Console.WriteLine();
        }

        public static void SaveFile(LogicLayer logic)
        {
            Console.WriteLine();
            if(logic.Entries.Count == 0)
            {
                Console.WriteLine("La lista está vacía!!!");
                return;
            }
            
            try
            {
                string result = logic.SaveAsJSON();             
                Console.WriteLine($"Se ha guardado el archivo bajo la ruta: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Se ha producido un error al intentar guardar el archivo.");
            }
        }
        public static void LoadFile(LogicLayer logic)
        {
            Console.WriteLine();
            try
            {
                string result = logic.LoadJSON();  
                Console.WriteLine($"Se ha cargado el archivo de la ruta: {result}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("No se encontró el archivo a cargar.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Se ha producido un error al intentar cargar el archivo.");
                Console.WriteLine(ex);
            }
        }
        public static void DeleteFile(LogicLayer logic) 
        {
            Console.WriteLine();
            try
            {
                string result = logic.DeleteJSON();
                Console.WriteLine($"Se eliminó el archivo de la ruta: {result}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("No se encontró el archivo a eliminar.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Se ha producido un error al intentar eliminar el archivo.");
            }
        }

    }
}
