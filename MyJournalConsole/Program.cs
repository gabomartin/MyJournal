using MyJournalConsole;
using MyJournalLogic;
int userInput = -1;

PresentationLogic.PrintWelcome();

LogicLayer logic = new LogicLayer();

while (userInput != 0)
{
    PresentationLogic.PrintMenu();
    try
    {
        userInput = Convert.ToInt32(Console.ReadLine().Trim());

    }
    catch (FormatException)
    {
        Console.WriteLine("Debe ingresar un número");
        userInput = -1;
    }
    catch (Exception)
    {
        Console.WriteLine("Error no controlado. Por favor intente nuevamente");
        userInput = -1;
    }
    

    switch (userInput)
    {
        case 0:
            break;
        case 1:
            PresentationLogic.ListEntries(logic);
            break;
        case 2:
            PresentationLogic.AddEntryNow(logic);
            break;
        case 3:
            PresentationLogic.ModifyEntry(logic);
            break;
        case 4:
            PresentationLogic.DeleteEntry(logic);
            break;
        case 5:
            PresentationLogic.LoadFile(logic);
            break;
        case 6:
            PresentationLogic.SaveFile(logic);
            break;
        case 7:
            PresentationLogic.DeleteFile(logic);
            break;
        default:
            Console.WriteLine("Opción invalida. Intente nuevamente.");
            userInput = -1;
            break;

    }

}

PresentationLogic.PrintQuit();
Thread.Sleep(1000);



