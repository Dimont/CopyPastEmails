using System;
using System.Collections.Generic;
using System.Threading;

namespace EmailAutomation
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> textOptions = new Dictionary<int, string>()
            {
                { 1, "To Remove - User Exists" },
                { 2, "To Remove - User Does Not Exist" },
                { 3, "To Add Permissions/Role - User Added Successfully" },
                { 4, "Title 4" }
            };

            Dictionary<int, string> copiedTexts = new Dictionary<int, string>()
            {
                { 1, "O usuário foi eliminado dos nossos sistemas." },
                { 2, "O usuário em questão não se encontra nos nossos sistemas." },
                { 3, "O usuário em questão encontra-se agora nos nossos sistemas." },
                { 4, "Text 4" }
            };

            string greeting = GetGreetingBasedOnTime();
            bool exitRequested = false;
            string copiedText = string.Empty;

            while (!exitRequested)
            {
                Console.WriteLine("Select an option:");
                foreach (KeyValuePair<int, string> option in textOptions)
                {
                    Console.WriteLine($"{option.Key} - {option.Value}");
                }
                Console.WriteLine("0 - Exit");

                if (int.TryParse(Console.ReadLine(), out int selectedOption))
                {
                    if (selectedOption == 0)
                    {
                        exitRequested = true;
                        continue;
                    }
                    else if (textOptions.ContainsKey(selectedOption))
                    {
                        if (copiedTexts.TryGetValue(selectedOption, out string selectedCopiedText))
                        {
                            copiedText = greeting + selectedCopiedText;
                            CopyTextToClipboard(copiedText);
                            Console.WriteLine("Text copied to clipboard.");
                            Console.WriteLine("Text: " + copiedText);
                            break; // Exit the loop
                        }
                        else
                        {
                            Console.WriteLine("Selected option does not have corresponding copied text.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid option. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void CopyTextToClipboard(string text)
        {
            ClipboardHelper.SetText(text);
        }

        static string GetGreetingBasedOnTime()
        {
            TimeSpan morningTime = new TimeSpan(12, 1, 0); // 12:01 PM

            if (DateTime.Now.TimeOfDay < morningTime)
            {
                return "Bom dia, \n\n"; // Good morning
            }
            else
            {
                return "Boa tarde, \n\n"; // Good afternoon
            }
        }
    }
}
