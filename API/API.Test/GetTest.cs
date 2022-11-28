namespace API.Test
{
    [TestClass]
    public class GetTest : UnitTest
    {
        /// <summary>
        /// Get method test
        /// </summary>
        [TestMethod]
        public void TestCase()
        {
            // Arrange
            var currentUsers = GetData("User");

            // Apply
            var action = Controller.Get();
            var actionResult = action.ToString();

            // Assert
            Assert.AreEqual(MockDatabase.Users.Count(), currentUsers.Count);
            Assert.AreEqual(okResult, actionResult);
        }
    }
}
