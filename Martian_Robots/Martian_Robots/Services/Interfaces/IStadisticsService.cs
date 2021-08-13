using Martian_Robots.Dtos;
using System.Collections.Generic;

namespace Martian_Robots.Services.Interfaces
{
    public interface IStadisticsService
    {
        List<RobotLogDto> GetRobotLogs(int maxItemPerPage, int skip);
    }
}