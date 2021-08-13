using Martian_Robots.Services.Interfaces;
using Moq;

namespace Martian_Robots_Tests.Factorys
{
    public static class FactorySQLiteService
    {
        private static Mock<ISQLiteService> sQLiteServiceMock;

        public static Mock<ISQLiteService> Create()
        {
            sQLiteServiceMock = new Mock<ISQLiteService>();

            configureSetups();

            return sQLiteServiceMock;
        }

        private static void configureSetups()
        {
            //Setups for the mock should be done here
        }
    }
}