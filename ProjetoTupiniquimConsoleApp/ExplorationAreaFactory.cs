using System;

namespace ProjetoTupiniquim.ConsoleApp
{
    internal class ExplorationAreaFactory
    {
        private readonly ConsoleUI _defaultOutput;

        public ExplorationAreaFactory(ConsoleUI defaultOutput)
        {
            this._defaultOutput = defaultOutput;
        }

        public ExplorationArea Factory()
        {
            var showInputCoordinates = true;
            while (showInputCoordinates)
            {
                var input = GetUserInput();
                IsExit(input);

                if (ValidateInput(input))
                {
                    ShowErrorMessage("NENHUM VALOR FOI INFORMADO!!\nTENTE NOVAMENTE!!");
                    continue;
                }

                ShowInputDescription();

                var areaCoordinatesLimits = input.Split(' ');

                if (areaCoordinatesLimits.Length == 2)
                {
                    if (
                        int.TryParse(areaCoordinatesLimits[0], out int limitX) == false ||
                    int.TryParse(areaCoordinatesLimits[1], out int limitY) == false
                    )
                    {
                        ShowErrorMessage("SÓ PODEM SER INFORMADOS VALORES NUMÉRICOS MAIORES QUE ZERO!!\nTENTE NOVAMENTE!!");
                    }
                    else
                    {
                        return new ExplorationArea() { LimitX = limitX, LimitY = limitY };
                    }
                }
            }
            return null;
        }

        private string GetUserInput()
        {
            return Console.ReadLine();
        }

        private void ShowInputDescription()
        {
            _defaultOutput.ShowInfoMessage("**DIGITE S PARA SAIR;\n** INFORME AS COORDENADAS DO FIM DA ÁREA DE PESQUISA NO FORMATO X Y: \n");
        }

        private void ShowErrorMessage(string message)
        {
            _defaultOutput.ShowErrorMessage(message);
        }
        private bool ValidateInput(string input)
        {
            return string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input);
        }

        private void IsExit(string input)
        {
            if (input == "s" || input == "S")
            {
                Console.Clear();
                Environment.Exit(0);
            }
        }
    }
}
}
