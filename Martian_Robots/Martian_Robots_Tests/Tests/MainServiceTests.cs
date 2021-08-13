using Martian_Robots.Services;
using Martian_Robots.Services.Interfaces;
using Martian_Robots_Tests.Factorys;
using Moq;
using NUnit.Framework;

namespace Martian_Robots_Tests.Tests
{
    public class MainServiceTests
    {
        private readonly MainService mainGameService;
        private readonly Mock<ISQLiteService> sQLiteServiceMock;

        public MainServiceTests()
        {
            sQLiteServiceMock = FactorySQLiteService.Create();

            mainGameService = new MainService(sQLiteServiceMock.Object);
        }

        [Test]
        public void case1OK()
        {
            var res = mainGameService.inputMethod(TestConstants.case1);
            Assert.AreEqual("1 1 E \n ", res);
        }

        [Test]
        public void case2OK()
        {
            var res = mainGameService.inputMethod(TestConstants.case2);
            Assert.AreEqual("3 3 N LOST \n ", res);
        }

        [Test]
        public void case3OK()
        {
            var res = mainGameService.inputMethod(TestConstants.case3);
            Assert.AreEqual("3 3 N LOST \n ", res);
        }

        [Test]
        public void caseAllOK()
        {
            var res = mainGameService.inputMethod(TestConstants.caseAll);
            Assert.AreEqual("1 1 E \n 3 3 N LOST \n 2 3 S \n ", res);
        }
    }
}