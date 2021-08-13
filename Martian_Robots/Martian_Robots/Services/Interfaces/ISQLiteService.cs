using Martian_Robots.Dtos;
using System.Collections.Generic;

namespace Martian_Robots.Services.Interfaces
{
    public interface ISQLiteService
    {
        void CreateRobotLog(RobotLogJsonDto robotLogDto);

        List<RobotLogDto> GetRobotLogs(int maxItemsPerPage, int skipPage);
    }
}