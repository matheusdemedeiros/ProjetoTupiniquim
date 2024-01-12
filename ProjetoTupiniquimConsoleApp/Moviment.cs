using System.Collections.Generic;

namespace ProjetoTupiniquim.ConsoleApp
{
    public class Moviment
    {
        public Queue<MovimentTypes> Steps { get; }

        public void AddSteps(List<MovimentTypes> steps)
        {
            foreach (var step in steps)
            {
                AddStep(step);
            }
        }

        public void AddStep(MovimentTypes step)
        {
            Steps.Enqueue(step);
        }
    }
}