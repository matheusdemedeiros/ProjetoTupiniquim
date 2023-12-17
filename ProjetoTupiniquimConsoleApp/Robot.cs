using System;

namespace ProjetoTupiniquim.ConsoleApp
{
    public class Robot
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Orientation { get; set; }
        public string[] PositionHistory { get; set; }

        public void MovimentRobot()
        {
            var movimentValid = false;
            while (movimentValid == false)
            {
                //Lendo e verificando os movimentos
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n============================================================================================");
                Console.WriteLine(" ** INFORME UMA SÉRIE DE MOVIMENTOS PARA O ROBÔ!!");
                Console.Write(" ** MOVIMENTOS POSSÍVEIS E (ESQUERDA) D (DIREITA) M (MOVER UMA CASA A FRENTE): ");
                var movimentsInput = Console.ReadLine();

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
                    var moviments = movimentsInput.ToCharArray();
                    for (int i = 0; i < moviments.Length; i++)
                    {
                        moviments[i] = char.ToUpper(moviments[i]);
                        if (moviments[i] == 'E')
                        {
                            if (Orientation == 'N')
                            {
                                Orientation = 'O';
                            }
                            else if (Orientation == 'O')
                            {
                                Orientation = 'S';
                            }
                            else if (Orientation == 'S')
                            {
                                Orientation = 'L';
                            }
                            else if (Orientation == 'L')
                            {
                                Orientation = 'N';
                            }
                        }
                        else if (moviments[i] == 'D')
                        {
                            if (Orientation == 'N')
                            {
                                Orientation = 'L';
                            }
                            else if (Orientation == 'L')
                            {
                                Orientation = 'S';
                            }
                            else if (Orientation == 'S')
                            {
                                Orientation = 'O';
                            }
                            else if (Orientation == 'O')
                            {
                                Orientation = 'N';
                            }
                        }
                        else if (moviments[i] == 'M')
                        {
                            if (Orientation == 'N')
                            {
                                PositionY++;
                            }
                            else if (Orientation == 'L')
                            {
                                PositionX++;
                            }
                            else if (Orientation == 'S')
                            {
                                PositionY--;
                            }
                            else if (Orientation == 'O')
                            {
                                PositionX--;
                            }
                        }
                    }
                    movimentValid = true;
                }
                if (movimentValid)
                {
                    // todo j + 1
                    var printHistory = "POSIÇÃO FINAL DO ROBÔ " + ( 1) + ": " + PositionX + " " + PositionY + " " + Orientation;
                    for (int i = 0; i < PositionHistory.Length; i++)
                    {
                        if (PositionHistory[i] == null)
                        {
                            PositionHistory[i] = printHistory;
                            break;
                        }
                    }
                }
            }
        }
    }
}
