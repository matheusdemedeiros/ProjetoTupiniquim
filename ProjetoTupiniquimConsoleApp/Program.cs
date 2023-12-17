using System;
using System.Collections.Generic;

namespace ProjetoTupiniquim.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Declarations


            string areaCoordinatesLimitXYInputUser, robotCoordinatesXYOInputUser, printHistory = "", movimentsInput;
            bool showInputCoordinates = true, showInputCoordinatesRobot, movimentValid = false, isNumericQtdRobots;
            int contNumericPositive = 0, robotPositionX, robotPositionY, qtdRobots = 0;
            char orientationRobot;
            string[] areaCoordinatesLimits, robotPositionHistory = new string[1];
            int[] areaCoordinatesXY = new int[2];
            char[] robotPositionCoordinatesXYO = new char[5], moviments;
            var consoleUI = new ConsoleUI();
            #endregion

            ShowPresentation();

            var robotsAmmount = GetRobotsAmmount();
            robotPositionHistory = new string[qtdRobots];

            Console.WriteLine("\nOK, AGORA VOCÊ SERÁ REDIRECIONADO AO MENU INICIAL DO SISTEMA!!");

            //Montando o menu de coordenadas e definindo sua exibição
            var areaFactory = new ExplorationAreaFactory(consoleUI);
            var area = areaFactory.Factory();
            
            
            
            if (robotPositionHistory.Length > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n============================================================================================");
                Console.WriteLine("************************************ POSIÇÕES DOS ROBÔS ************************************");
                for (int i = 0; i < robotPositionHistory.Length; i++)
                {
                    Console.WriteLine(robotPositionHistory[i]);
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
        }

        private static void ShowPresentation()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n============================================================================================");
            Console.WriteLine("OLÁ, SEJA BEM VINDO AO SISTEMA DE CONTROLE E " +
                "GERENCIAMENTO DA EXPLORAÇÃO DE MARTE!!");
        }

        private static int GetRobotsAmmount()
        {
            Console.Write("\nPRIMEIRAMENTE INFORME A QUANTIDADE DE ROBÔS EXPLORADORES QUE SERÃO ENVIADOS NA MISSÃO: ");
            var ammountRobots = 0;
            do
            {
                if (!int.TryParse(Console.ReadLine(), out ammountRobots))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nDADOS INFORMADOS DE FORMA INCORRETA!!");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    continue;
                }

            } while (ammountRobots == 0);

            return ammountRobots;
        }

        private static string GetUserInput()
        {
            return Console.ReadLine();
        }
        private static void ShowInputDescription()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n============================================================================================");
            Console.WriteLine(" ** DIGITE S PARA SAIR;");
            Console.Write(" ** INFORME AS COORDENADAS DO FIM DA ÁREA DE PESQUISA NO FORMATO X Y: ");
            SetConsoleToDefaultColor();
        }

        private static void ShowErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n============================================================================================");
            Console.WriteLine(message);
            SetConsoleToDefaultColor();
        }
        private static void SetConsoleToDefaultColor()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        private static bool ValidateInput(string input)
        {
            return string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input);
        }

        private static void IsExit(string input)
        {
            if (input == "s" || input == "S")
            {
                Console.Clear();
                Environment.Exit(0);
            }
        }
    }
}