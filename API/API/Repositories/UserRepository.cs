namespace API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _database;
        public UserRepository(DatabaseContext database)
        {
            _database = database;
        }

        /// <summary>
        /// Get all users when authorised.
        /// </summary>
        public List<User> GetAllUsers(int id)
        { 
            var adminRoleId = _database.Roles
                .Where(r => r.Code == "ADMIN")
                .Select(r => r.Id)
                .Single();
            var user = GetUserById(id);
            bool userHasAdminRole = user.Role == adminRoleId;
            bool userHasPrivilege = _database.Privileges
                .Where(p => p.Code == "USER_SEARCH" && p.Role == adminRoleId)
                .Select(p => p)
                .Any();
            if (userHasAdminRole && userHasPrivilege) 
            {
                return _database!.Users.ToList();
            }
            else
            {
                throw new Exception();
            }
        }
        private User GetUserById(int id)
        {
            return _database.Users
                .Where(u => u.Id == id)
                .Select(u => u)
                .Single();
        }

        /// <summary>
        /// Get user by username and password.
        /// </summary>
        public User LogOn(User user)
        {
            return _database!
                .Users
                .Where(u => u.UserName == user.UserName && u.Password == user.Password)
                .Select(u => u)
                .Single();
        }

        /// <summary>
        /// Get a generated password of the given length.
        /// </summary>
        public string GetGeneratedPassword(int passwordLength = 12)
        {
            Random random = new Random();
            if (passwordLength < 1)
            {
                passwordLength = 12;
            }
            string data = GetDataToGeneratePasswordFrom();
            string password = "";
            for (int i = 0; i<passwordLength; i++)
            {
                password += data[random.Next(0, data.Length)];
            }
            return password;
        }

        private string GetDataToGeneratePasswordFrom()
        {
            string data = "abcdefghijklmnopqrstuwvxzy";
                   data += data.ToUpper();
                   data += "0123456789";
                   data += "!@#$%^&*<>_-+~:;.";
            return data;
        }

    }
}
