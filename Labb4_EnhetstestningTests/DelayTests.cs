using Labb4_Enhetstestning;

namespace Labb4_EnhetstestningTests
{
    [TestClass]
    public class DelayTests
    {
        LibrarySystem librarySystem = new LibrarySystem();

        [TestMethod]
        public void CalculateLateFee_DelayOfSixDays_ReturnsThree()
        {
            var fee = librarySystem.CalculateLateFee("9780451524935", 6);
            var expected = 3m;

            Assert.AreEqual(fee, expected);
        }
    }
}
