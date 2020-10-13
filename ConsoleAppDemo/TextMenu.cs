using System;
using System.Collections.Immutable;


namespace ConsoleAppDemo
{
    /// <summary>
    /// Simple text menu
    /// </summary>
    static public class TextMenu
    {
        /// <summary>
        /// Runs a menu
        /// </summary>
        static public void Run(string name, ImmutableArray<(string text, Action action)> items)
        {
            bool done = false;
            while (done == false)
            {
                Console.WriteLine("");
                Console.WriteLine($"{name} options");
                Console.WriteLine("---------------------------------------------------------");

                for (int index = 0; index < items.Length; index += 1)
                {
                    if (items.Length > 9)
                    {
                        Console.WriteLine(String.Format("{0, 2}", (index + 1).ToString()) + $": {items[index].text}");
                    }
                    else
                    {
                        Console.WriteLine($"{index + 1}: {items[index].text}");
                    }
                }

                Console.Write(">");

                string userInput = Console.ReadLine();
                Console.WriteLine();
                if (userInput == "q")
                {
                    done = true;
                }
                else
                {
                    if (int.TryParse(userInput, out int selectedIndex) == true)
                    {
                        if ((selectedIndex > 0) && (selectedIndex <= items.Length))
                        {
                            var menuItem = items[selectedIndex - 1];
                            try
                            {
                                menuItem.action();
                            }
                            catch (Exception exception)
                            {
                                Console.WriteLine("\nCaught an exception...\n");
                                Console.WriteLine(exception.ToString());
                                Console.WriteLine();
                            }
                        }
                    }
                }

                Console.WriteLine("\n");
            }
        }
    }
}
