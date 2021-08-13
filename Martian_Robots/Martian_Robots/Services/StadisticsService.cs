using Martian_Robots.Dtos;
using Martian_Robots.Services.Interfaces;
using System.Collections.Generic;

namespace Martian_Robots.Services
{
    public class StadisticsService : IStadisticsService
    {
        private readonly ISQLiteService sQLiteService;

        public StadisticsService(ISQLiteService sQLiteService)
        {
            this.sQLiteService = sQLiteService;
        }

        public List<RobotLogDto> GetRobotLogs(int maxItemPerPage, int skip)
        {
            return sQLiteService.GetRobotLogs(maxItemPerPage, skip);
        }
    }
}