using Martian_Robots;
using NUnit.Framework;

namespace Martian_Robots_Tests.Tests
{
    public class MainGameServiceTests
    {
        private readonly MainGameService mainGameService;

        public MainGameServiceTests()
        {
            mainGameService = new MainGameService();
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
