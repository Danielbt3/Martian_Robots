using Martian_Robots.Services.Auxiliary;

namespace Martian_Robots.Dtos
{
    public class RobotLogDto
    {
        public long id { get; set; }
        public RobotLogJsonDto log { get; set; }

        public RobotLogDto(long id, RobotLogJsonDto log)
        {
            this.id = id;
            this.log = log;
        }
    }

    public class RobotLogJsonDto
    {
        public Point mapSize { get; set; }
        public string actions { get; set; }
        public string result { get; set; }
    }
}