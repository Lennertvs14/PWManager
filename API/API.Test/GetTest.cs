using Microsoft.AspNetCore.Http;

namespace API.Test
{
    [TestClass]
    public class GetTest : UnitTest
    {
        /// <summary>
        /// As an admin with corresponding authorisation I must be able to receive a List of all users.
        /// </summary>
        [TestMethod]
        public void GetAllUsersWithAuthorisation()
        {
            // Arrange
            var currentUsers = GetData<User>("User");

            // Apply
            var action = Controller.GetUsers();
            var actionResult = action.ToString();

            // Assert
            Assert.AreEqual(MockDatabase.Users.Count(), currentUsers.Count);
            Assert.AreEqual(okObjectResult, actionResult);
        }

        /// <summary>
        /// As a user I must be able to log in when submitting correct account credentials.
        /// </summary>
        [TestMethod]
        public void LogOnWithValidAccount()
        {
            // Arrange
            var user = GetRandomExistingUser();

            // Apply
            var action = Controller.LogOn(user);
            var actionResult = action.ToString();

            // Assert
            Assert.AreEqual(okResult, actionResult);
        }

        private User GetRandomExistingUser()
        {
            var users = MockDatabase.Users;
            var id = random.Next(1, users.Count());
            var user = users
                .Where(u => u.Id == id)
                .Select(u => u)
                .Single();
            return user;
        }

        [TestMethod]
        public void LogOnWithWrongAccount()
        {
            // Arrange
            var user = GetNewUserObject("INVALID", "INVALID");

            // Apply
            var action = Controller.LogOn(user);
            var actionResult = action.ToString();

            // Assert
            Assert.AreEqual(badRequestResult, actionResult);
        }

        private User GetNewUserObject(string username, string password)
        {
            var user = GetRandomExistingUser();
            user.Id = GetNewId(typeof(User));
            user.UserName = username;
            user.Password = password;
            return user;
        }

        [TestMethod]
        public void GetPasswordWithNoLength()
        {
            // Arrange
            int defaultLength = 12;

            // Act
            var password = UserRepository.GetGeneratedPassword();
            var action = Controller.GetPassword(0);
            var actionResult = action.ToString();
    
            // Assert
            Assert.AreEqual(okObjectResult, actionResult);
            Assert.AreEqual(defaultLength, password.Length);
        }

        [TestMethod]
        public void GetPasswordWithInvalidLength()
        {
            // Arrange
            int invalidLength = -10;
            int defaultLength = 12;

            // Act
            var password = UserRepository.GetGeneratedPassword(invalidLength);
            var action = Controller.GetPassword(invalidLength);
            var actionResult = action.ToString();

            // Assert
            Assert.AreEqual(okObjectResult, actionResult);
            Assert.AreEqual(defaultLength, password.Length);
        }
    }
}
