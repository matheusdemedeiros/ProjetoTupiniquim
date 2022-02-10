using System;

namespace ProjetoTupiniquim.ConsoleApp
{

    /*
   1 - Receber a string de área;
   2 - Verificar se os valores para a área são inteiros > 0;
   3 - Receber a posição/orientação inicial do robô e verificar se ela pertence a área;
   4 - Receber as strings de Comandos para o robô;
   5 - Separá-las pelos espaços e colocar em array de caracteres;
   6 - Verificar se todos os caracteres são válidos como ações do robô;
   7 - Determinar a posição final do robô;    
   
     */
    internal class Program
    {
        static void Main(string[] args)
        {

            //Declaração de variáveis de escopo global
            string areaCoordinatesLimitXYInputUser;
            string robotCoordinatesXYOInputUser1;
            string[] areaCoordinatesLimits;
            bool showInputCoordinates = true;
            bool showInputCoordinatesRobot1;
            int[] areaCoordinatesXY = new int[2];
            int contNumericPositive = 0;
            char[] robotInitialCoordinatesXYO1 = new char[5];
            char initialOrientationRobot1;
            int robotInitialX1, robotInitialY1;

            //Montando o menu de coordenadas e definindo sua exibição
            while (showInputCoordinates)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=========================================");
                Console.WriteLine("Digite S para SAIR;");
                Console.Write("Informe as cordenadas do fim da área pesquisa\nno formato X Y: ");
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
                    Console.WriteLine("NENHUM VALOR FOI INFORMADO!!\nTENTE NOVAMENTE!!");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    continue;
                }
                else
                {
                    //char[] movimentos = areaCoordinatesLimitXYInputUser.ToCharArray();
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
            showInputCoordinatesRobot1 = true;
            //Montando o menu de coordenadas do robô 1 e definindo sua exibição
            while (showInputCoordinatesRobot1)
            {
                Console.WriteLine("===================================================");
                Console.Write("Informe as cordenadas iniciais do robô I e sua orientação\nno formato X Y O (orientação): ");
                robotCoordinatesXYOInputUser1 = Console.ReadLine();

                //Verficando se a variável não é vazia
                if (robotCoordinatesXYOInputUser1 == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("NENHUM VALOR FOI INFORMADO!!\nTENTE NOVAMENTE!!");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    continue;
                }
                else
                {
                    //char[] movimentos = areaCoordinatesLimitXYInputUser.ToCharArray();
                    robotInitialCoordinatesXYO1 = robotCoordinatesXYOInputUser1.ToCharArray();

                    //Verificando se os valores informados são números inteiros 
                    bool isNumericX = int.TryParse($"{robotInitialCoordinatesXYO1[0]}", out int value1);
                    bool isNumericY = int.TryParse($"{robotInitialCoordinatesXYO1[2]}", out int value2);
                    bool isCharO = char.TryParse($"{robotInitialCoordinatesXYO1[4]}", out char value3);

                    if (isNumericX && isNumericY && (value1 < areaCoordinatesXY[0]) && (value2 < areaCoordinatesXY[1]))
                    {
                        if (value3 != 'l' && value3 != 'o' && value3 != 'n' && value3 != 's')
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("ORIENTAÇÃO INFORMADA DESCONHECIDA!!\nTENTE NOVAMENTE!!");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            continue;
                        }
                        else
                        {
                            showInputCoordinatesRobot1 = false;
                            robotInitialX1 = value1;
                            robotInitialY1 = value2;
                            initialOrientationRobot1 = value3;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("SÓ PODEM SER INFORMADOS VALORES NUMÉRICOS MENORES QUE A" +
                            "\nÁREA IFORMADA ANTERIORMENTE!!\nTENTE NOVAMENTE!!");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        continue;
                    }

                }
                //Montando um campo
                int[] campoX = new int[areaCoordinatesXY[0]];
                int[] campoY = new int[areaCoordinatesXY[1]];
                int positionRobotX;
                int positionRobotY;
                bool movimentsValid = false;
                while (movimentsValid == false)
                {
                    //Lendo e verificando os movimentos
                    Console.WriteLine("===================================================");
                    Console.WriteLine("Informe uma série de movimentos para o robô 1");
                    Console.Write("MOVIMENTOS POSSÍVEIS E D M: ");
                    string movimentsInput = Console.ReadLine();
                    char[] moviments;
                    //Verficando se a variável não é vazia
                    if (movimentsInput == "")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("NENHUM VALOR FOI INFORMADO!!\nTENTE NOVAMENTE!!");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        continue;
                    }
                    else
                    {
                        moviments = movimentsInput.ToCharArray();
                        for (int i = 0; i < moviments.Length; i++)
                        {
                            if (moviments[i] != 'e' && moviments[i] != 'd' && moviments[i] != 'm')
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("FOI INFORMADO ALGUM VALOR DESCONHECIDO!!\nTENTE NOVAMENTE!!");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                break;
                            }
                            else
                            {
                                movimentsValid = true;
                                //continuar
                            }
                        }
                        if(movimentsValid == false)
                        {
                            continue;
                        }
                    }
                }
            }
        }
    }
}

