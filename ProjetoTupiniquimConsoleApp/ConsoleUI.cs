using System;

namespace ProjetoTupiniquim.ConsoleApp
{
    internal class ConsoleUI
    {
        private string _separator = "============================================================================================";
        private ConsoleColor _defaultColor = ConsoleColor.Yellow;        
        public void ShowInfoMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            WriteSeparator();
            Console.WriteLine(message);
            SetConsoleToDefaultColor();
        }

        public void ShowDescriptionMessage(string message, bool keepCurrentColor = false)
        {
            var currentColor = keepCurrentColor ?  Console.ForegroundColor : ;

            if (keepCurrentColor)
            Console.ForegroundColor = ConsoleColor.Cyan;
            WriteSeparator();
            Console.WriteLine(message);
            {

            }
            SetConsoleToDefaultColor();
        }

        public void ShowErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            WriteSeparator();
            Console.WriteLine(message);
            SetConsoleToDefaultColor();
        }
        
        private void WriteSeparator()
        {
            Console.WriteLine($"\n {_separator}");
        }

        private void ShowMessage(string message, ConsoleColor messageColor)
        {
            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = messageColor;
            Console.WriteLine(message);

        }
        private static void SetConsoleToDefaultColor(bool keepPreviousColor = false)
        {
            if (keepPreviousColor)
            {

            }

            Console.ForegroundColor = ConsoleColor.Yellow;
        }
    }
}
