using System;

namespace ProjetoTupiniquim.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string areaCoordinatesLimitXYInputUser, robotCoordinatesXYOInputUser, printHistory = "", movimentsInput;
            bool showInputCoordinates = true, showInputCoordinatesRobot, movimentValid = false, isNumericQtdRobots;
            int contNumericPositive = 0, robotPositionX, robotPositionY, qtdRobots = 0;
            char orientationRobot;
            string[] areaCoordinatesLimits, robotPositionHistory = new string[1];
            int[] areaCoordinatesXY = new int[2];
            char[] robotPositionCoordinatesXYO = new char[5], moviments;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n============================================================================================");
            Console.WriteLine("OLÁ, SEJA BEM VINDO AO SISTEMA DE CONTROLE E " +
                "GERENCIAMENTO DA EXPLORAÇÃO DE MARTE!!");
            do
            {
                Console.Write("\nPRIMEIRAMENTE INFORME A QUANTIDADE DE ROBÔS EXPLORADORES QUE SERÃO ENVIADOS NA MISSÃO: ");
                isNumericQtdRobots = int.TryParse(Console.ReadLine(), out int value);
                if (isNumericQtdRobots == true)
                {
                    qtdRobots = value;
                    robotPositionHistory = new string[qtdRobots];
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nDADOS INFORMADOS DE FORMA INCORRETA!!");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    continue;
                }
            } while (isNumericQtdRobots == false);

            Console.WriteLine("\nOK, AGORA VOCÊ SERÁ REDIRECIONADO AO MENU INICIAL DO SISTEMA!!");

            //Montando o menu de coordenadas e definindo sua exibição
            while (showInputCoordinates)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n============================================================================================");
                Console.WriteLine(" ** DIGITE S PARA SAIR;");
                Console.Write(" ** INFORME AS COORDENADAS DO FIM DA ÁREA DE PESQUISA NO FORMATO X Y: ");
                areaCoordinatesLimitXYInputUser = Console.ReadLine();

                //Verificando se é para sair do programa
                if (areaCoordinatesLimitXYInputUser == "s" || areaCoordinatesLimitXYInputUser == "S")
                {
                    Console.Clear();
                    Environment.Exit(0);
                }

                //Verficando se a variável não é vazia
                if (areaCoordinatesLimitXYInputUser == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n=========================================================================================");
                    Console.WriteLine("NENHUM VALOR FOI INFORMADO!!\nTENTE NOVAMENTE!!");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    continue;
                }
                else
                {
                    areaCoordinatesLimits = areaCoordinatesLimitXYInputUser.Split(' ');
                    //Verificando se os valores informados são números inteiros > 0
                    bool isNumeric;
                    for (int i = 0; i < areaCoordinatesLimits.Length; i++)
                    {
                        isNumeric = int.TryParse($"{areaCoordinatesLimits[i]}", out int value);
                        if (isNumeric && value > 0)
                        {
                            areaCoordinatesXY[i] = value;
                            contNumericPositive++;
                        }
                        else
                        {
                            contNumericPositive = 0;
                            break;
                        }
                    }
                    if (contNumericPositive != 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n============================================================================================");
                        Console.WriteLine("SÓ PODEM SER INFORMADOS VALORES NUMÉRICOS MAIORES QUE ZERO!!\nTENTE NOVAMENTE!!");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        continue;
                    }
                    else
                    {
                        showInputCoordinates = false;
                    }
                }
            }

            //Habilitando a exibição do menu do robô 
            for (int j = 0; j < qtdRobots; j++)
            {
                showInputCoordinatesRobot = true;
                movimentValid = false;
                //Montando o menu de coordenadas dos robôs e definindo sua exibição
                while (showInputCoordinatesRobot)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n============================================================================================");
                    Console.Write("INFORME AS COORDENADAS DO ROBÔ {0} E SUA ORIENTAÇÃO" +
                        "\nNO FORMATO EIXO X, EIXO Y E A ORIENTAÇÃO => X Y O: ", (j + 1));
                    robotCoordinatesXYOInputUser = Console.ReadLine();

                    //Verficando se a variável não é vazia
                    if (robotCoordinatesXYOInputUser == "")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n============================================================================================");
                        Console.WriteLine("NENHUM VALOR FOI INFORMADO!! TENTE NOVAMENTE!!");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        continue;
                    }
                    else
                    {
                        robotPositionCoordinatesXYO = robotCoordinatesXYOInputUser.ToCharArray();
                        //Verificando se os valores informados são números inteiros e um char na sequência
                        bool isNumericX = int.TryParse($"{robotPositionCoordinatesXYO[0]}", out int value1);
                        bool isNumericY = int.TryParse($"{robotPositionCoordinatesXYO[2]}", out int value2);
                        bool isChar = char.TryParse($"{robotPositionCoordinatesXYO[4]}", out char value3);
                        value3 = char.ToUpper(value3);

                        if (isNumericX && isNumericY && (value1 < areaCoordinatesXY[0]) && (value2 < areaCoordinatesXY[1]))
                        {
                            if (value3 != 'L' && value3 != 'O' && value3 != 'N' && value3 != 'S')
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n============================================================================================");
                                Console.WriteLine("ORIENTAÇÃO INFORMADA DESCONHECIDA!!TENTE NOVAMENTE!!");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                continue;
                            }
                            else
                            {
                                robotPositionX = value1;
                                robotPositionY = value2;
                                orientationRobot = char.ToUpper(value3);
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n============================================================================================");
                            Console.WriteLine("SÓ PODEM SER INFORMADOS VALORES NUMÉRICOS MENORES QUE A ÁREA IFORMADA ANTERIORMENTE!!" +
                                "\nE DEVEM SER NA MESMA ORDEM APRESENTADA!! TENTE NOVAMENTE!!");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            continue;
                        }
                    }
                    while (movimentValid == false)
                    {
                        //Lendo e verificando os movimentos
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\n============================================================================================");
                        Console.WriteLine(" ** INFORME UMA SÉRIE DE MOVIMENTOS PARA O ROBÔ!!");
                        Console.Write(" ** MOVIMENTOS POSSÍVEIS E (ESQUERDA) D (DIREITA) M (MOVER UMA CASA A FRENTE): ");
                        movimentsInput = Console.ReadLine();

                        //Verficando se a variável não é vazia
                        if (movimentsInput == "")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n============================================================================================");
                            Console.WriteLine("NENHUM VALOR FOI INFORMADO!! TENTE NOVAMENTE!!");
                            Console.ForegroundColor = ConsoleColor.White;
                            continue;
                        }
                        else
                        {
                            moviments = movimentsInput.ToCharArray();
                            for (int i = 0; i < moviments.Length; i++)
                            {
                                moviments[i] = char.ToUpper(moviments[i]);
                                if (moviments[i] == 'E')
                                {
                                    if (orientationRobot == 'N')
                                    {
                                        orientationRobot = 'O';
                                    }
                                    else if (orientationRobot == 'O')
                                    {
                                        orientationRobot = 'S';
                                    }
                                    else if (orientationRobot == 'S')
                                    {
                                        orientationRobot = 'L';
                                    }
                                    else if (orientationRobot == 'L')
                                    {
                                        orientationRobot = 'N';
                                    }
                                }
                                else if (moviments[i] == 'D')
                                {
                                    if (orientationRobot == 'N')
                                    {
                                        orientationRobot = 'L';
                                    }
                                    else if (orientationRobot == 'L')
                                    {
                                        orientationRobot = 'S';
                                    }
                                    else if (orientationRobot == 'S')
                                    {
                                        orientationRobot = 'O';
                                    }
                                    else if (orientationRobot == 'O')
                                    {
                                        orientationRobot = 'N';
                                    }
                                }
                                else if (moviments[i] == 'M')
                                {
                                    if (orientationRobot == 'N')
                                    {
                                        robotPositionY++;
                                    }
                                    else if (orientationRobot == 'L')
                                    {
                                        robotPositionX++;
                                    }
                                    else if (orientationRobot == 'S')
                                    {
                                        robotPositionY--;
                                    }
                                    else if (orientationRobot == 'O')
                                    {
                                        robotPositionX--;
                                    }
                                }
                            }
                            movimentValid = true;
                        }
                        if (movimentValid)
                        {
                            printHistory = "POSIÇÃO FINAL DO ROBÔ " + (j + 1) + ": " + robotPositionX + " " + robotPositionY + " " + orientationRobot;
                            for (int i = 0; i < robotPositionHistory.Length; i++)
                            {
                                if (robotPositionHistory[i] == null)
                                {
                                    robotPositionHistory[i] = printHistory;
                                    break;
                                }
                            }
                        }
                    }
                    showInputCoordinatesRobot = false;
                }
            }
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
    }
}