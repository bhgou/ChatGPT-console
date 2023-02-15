using System.Diagnostics;
using System.Text;

namespace ConsoleApp2;

public class MainMenu
{
    private static void Main()
    {
        int index = 5;
        const int  countButtons = 3;
        const int Start = 6;
        const int About = 6;
        const int Update = 8;
        Json json = new Json();

        
        int maxButtons = index + countButtons;
        string[] _menu =
        {
            "░█████╗░██╗░░██╗░█████╗░████████╗░██████╗░██████╗░████████╗░█████╗░░█████╗░███╗░░██╗░██████╗░█████╗░██╗░░░░░███████╗",
            "██╔══██╗██║░░██║██╔══██╗╚══██╔══╝██╔════╝░██╔══██╗╚══██╔══╝██╔══██╗██╔══██╗████╗░██║██╔════╝██╔══██╗██║░░░░░██╔════",
            "██║░░╚═╝███████║███████║░░░██║░░░██║░░██╗░██████╔╝░░░██║░░░██║░░╚═╝██║░░██║██╔██╗██║╚█████╗░██║░░██║██║░░░░░█████╗░",
            "██║░░██╗██╔══██║██╔══██║░░░██║░░░██║░░╚██╗██╔═══╝░░░░██║░░░██║░░██╗██║░░██║██║╚████║░╚═══██╗██║░░██║██║░░░░░██╔══╝░░",
            "╚█████╔╝██║░░██║██║░░██║░░░██║░░░╚██████╔╝██║░░░░░░░░██║░░░╚█████╔╝╚█████╔╝██║░╚███║██████╔╝╚█████╔╝███████╗███████╗",

            "\n",
            "Start",
            "About",
            "Update",
            "\n",
            $"Version {json.Get().Version}",
            "\n",
            "Controls: UpArrow,DownArrow,Enter"
        };
        
        while (true)
        {
            
            foreach (var type in _menu)
            {
                Console.WriteLine(type);
            }

            if (index <= maxButtons)
            {
                if (Console.ReadKey().Key == ConsoleKey.DownArrow)
                {
                    index++;
                    _menu[index] += "<";
                    StringBuilder sb = new StringBuilder(_menu[index - 1]);
                    sb[_menu[index - 1].Length-1] = ' ';
                    _menu[index - 1] = sb.ToString();
                }
                
            }
            else
            {
                index = 5;
            }

            if (index >= 5)
            {
                if (Console.ReadKey().Key == ConsoleKey.UpArrow)
                {
                    index--;
                    _menu[index] += "<";
                    StringBuilder sb = new StringBuilder(_menu[index + 1]);
                    sb[_menu[index + 1].Length-1] = ' ';
                    _menu[index + 1] = sb.ToString();
                }
            }

            if (index == Start)
            {
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    ChatGPT chat = new();
                    chat.Start();
                }
            }
            Console.ReadKey();
            Console.Clear();
        }
        
    }
}