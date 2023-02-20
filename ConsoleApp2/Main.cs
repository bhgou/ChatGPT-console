using System.Diagnostics;
using System.Text;

namespace ConsoleApp2;

public class MainMenu
{
    private static void Main()
    {
        Console.Clear();
        ChatGPT chat = new();
        chat.Start();
        Console.ReadKey();

        
        
    }
}