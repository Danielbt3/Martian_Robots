using Martian_Robots.Dtos;
using Martian_Robots.Services.Auxiliary;
using Martian_Robots.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Martian_Robots.Services
{
    public class MainService : IMainService
    {
        private readonly ISQLiteService sQLiteService;

        public MainService(ISQLiteService sQLiteService)
        {
            this.sQLiteService = sQLiteService;
        }

        public string inputMethod(string input)
        {
            List<string> orders = SplitCommands(ref input);

            Map map = GenerateMap(orders);

            string res = string.Empty;
            for (int i = 0; i < orders.Count() / 4; i++)
            {
                try
                {
                    var action = orders.Skip(i * 4).Take(4).ToList();
                    Robot robot = GenerateRobot(map, action);

                    res += ExecuteCommands(action[3], robot, map) + " \n ";

                    RobotLogJsonDto robotLogJsonDto = new RobotLogJsonDto()
                    {
                        actions = string.Join(" ", action),
                        result = res,
                        mapSize = map.MapDimensions
                    };
                    sQLiteService.CreateRobotLog(robotLogJsonDto);
                }
                catch (Exception e)
                {
                    res += e.Message + " \n ";
                }
            }

            return res;
        }

        private static List<string> SplitCommands(ref string input)
        {
            input = Regex.Replace(input, @"\s+", " ");
            List<string> orders = input.Trim().Split(' ').ToList();

            if (orders.Count < 6 || (orders.Count() - 2) % 4 != 0)
                throw new Exception("Number of orders is incorrect , complete orders must be composed of an X cord , an Y cord, a orientation and a command, please check the input and try again");
            return orders;
        }

        private Robot GenerateRobot(Map map, List<string> action)
        {
            var cords = Utilities.ParseCords(action[0], action[1]);

            if (map.MapDimensions.X < cords.Item1 || map.MapDimensions.Y < cords.Item2)
                throw new Exception($"Position X: {cords.Item1} Y: {cords.Item2} out of the map");

            if (!Enum.IsDefined(typeof(Orientations), action[2]))
                throw new Exception($"Orientation {action[2]} not recognized , please use one of the following : N E S W");
            var orientation = (Orientations)Enum.Parse(typeof(Orientations), action[2], true);

            return new Robot(new Point(cords.Item1, cords.Item2), orientation);
        }

        private Map GenerateMap(List<string> orders)
        {
            var cords = Utilities.ParseCords(orders[0], orders[1]);

            orders.RemoveRange(0, 2);//Remove the 2 first orders that are used to generate the map

            return new Map(cords.Item1, cords.Item2);
        }

        private string ExecuteCommands(string commands, Robot robot, Map map)
        {
            if (commands.Length > 100)
                throw new Exception("Commands strings must have 100 characters maximum");
            Point newPosition;
            foreach (char command in commands)
            {
                var oldPosition = new Point(robot.position);
                robot.Instruction(command);
                newPosition = robot.position;
                if (newPosition.X > map.MapDimensions.X || newPosition.Y > map.MapDimensions.Y)
                {
                    var cellNumber = map.grid.IndexOf(map.grid.First(x => x.cords.X == oldPosition.X && x.cords.Y == oldPosition.Y));
                    if (map.grid[cellNumber].HasFallen)
                    {
                        robot.position = oldPosition;
                    }
                    else
                    {
                        map.grid[cellNumber].HasFallen = true;
                        return (oldPosition.X + " " + oldPosition.Y + " " + robot.GetOrientation() + " LOST");
                    }
                }
            }
            return (robot.position.X + " " + robot.position.Y + " " + robot.GetOrientation());
        }
    }
}