using System;

namespace ProjetoTupiniquim.ConsoleApp
{
    internal class RobotFactory
    {
        private readonly ConsoleUI _defaultOutput;

        public RobotFactory(ConsoleUI defaultOutput)
        {
            this._defaultOutput = defaultOutput;
        }


        public Robot Factory(int ammountRobots) {

            for (int j = 0; j < ammountRobots; j++)
            {
                showInputCoordinatesRobot = true;
                movimentValid = false;
                //Montando o menu de coordenadas dos robôs e definindo sua exibição
                while (showInputCoordinatesRobot)
                {
                    ShowInputDescription(j);
                    robotCoordinatesXYOInputUser = Console.ReadLine();

                    //Verficando se a variável não é vazia
                    if (robotCoordinatesXYOInputUser == "")
                    {
                        ShowErrorMessage();
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
                                area.Robots.Add(new Robot { PositionX = value1, PositionY = value2, Orientation = char.ToUpper(value3) });
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
                    // movimentar robo

                    showInputCoordinatesRobot = false;

                }
            }


        }

        private void ShowErrorMessage()
        {
            _defaultOutput.ShowDescriptionMessage("NENHUM VALOR FOI INFORMADO!! TENTE NOVAMENTE!!", true);
        }

        private void ShowInputDescription()
        {
            _defaultOutput.ShowDescriptionMessage("INFORME AS COORDENADAS DO ROBÔ {0} E SUA ORIENTAÇÃO" +
                "\nNO FORMATO EIXO X, EIXO Y E A ORIENTAÇÃO => X Y O:");
        }
    }
}
