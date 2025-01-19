using System.Collections.Generic;

namespace ProjetoTupiniquim.ConsoleApp
{
    internal class ExplorationArea
    {
        public int LimitX { get; set; }
        public int LimitY { get; set; }
        public List<Robot> Robots { get; set; }

        public ExplorationArea()
        {
            Robots = new List<Robot>();
        }

        public void AddRobots(List<Robot> robots)
        {
            for (int i = 0; i < robots.Count; i++)
            {
                AddRobot(robots[i]);
            }
        }

        public void AddRobot(Robot robot)
        {
            if (robot == null) { return; }

            if (robot.PositionX > LimitX) { return; }

            if (robot.PositionY > LimitY) { return; }

            Robots.Add(robot);
        }

         public void CheckRobotMoviment(Robot robot, Moviment moviment)
        {

        }

    }
}
