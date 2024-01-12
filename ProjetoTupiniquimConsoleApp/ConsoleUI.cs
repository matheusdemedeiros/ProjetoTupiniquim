using System;

namespace ProjetoTupiniquim.ConsoleApp
{
    internal class ConsoleUI
    {
        private static string _separator = "============================================================================================";
        private static ConsoleColor _defaultColor = ConsoleColor.Yellow;

        public void ShowInfoMessage(string message)
        {
            ShowMessage(message, ConsoleColor.Blue);
        }

        public void ShowDescriptionMessage(string message, bool keepCurrentColor = false)
        {
            var currentColor = keepCurrentColor ? Console.ForegroundColor : ConsoleColor.Cyan;
            ShowMessage(message, currentColor);
        }

        public void ShowErrorMessage(string message)
        {
            ShowMessage(message, ConsoleColor.Red);
        }

        public void Clear()
        {
            Console.Clear();
        }

        public string ReadInput()
        {
            return Console.ReadLine();
        }

        private void WriteSeparator()
        {
            Console.WriteLine($"\n {_separator}");
        }

        private void ShowMessage(string message, ConsoleColor messageColor)
        {
            SetConsoleColor(messageColor);
            WriteSeparator();
            Console.WriteLine(message);
            SetConsoleToDefaultColor();
        }

        private static void SetConsoleToDefaultColor(bool keepPreviousColor = false)
        {
            SetConsoleColor(_defaultColor);
        }

        private static void SetConsoleColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        private static ConsoleColor GetCurrentColor()
        {
            return Console.ForegroundColor;
        }
    }
}
