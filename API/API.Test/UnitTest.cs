namespace API.Test
{
    public class UnitTest
    {
        private DbContextOptions<DatabaseContext> options;
        protected DatabaseContext MockDatabase;
        protected UserController Controller;

        public UnitTest()
        {
            options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "MockDB")
                .Options;
            MockDatabase = new DatabaseContext(options);
            FillTheMockDatabase();
            Controller = new UserController(MockDatabase);
        }

        protected static readonly string okResult = typeof(OkObjectResult).FullName!;
        protected static readonly string badResult = typeof(BadRequestObjectResult).FullName!;

        protected void FillTheMockDatabase()
        {
            bool databaseIsFilled = MockDatabase.Users.Any();
            if (!databaseIsFilled)
            {
                var users = GetData("User");
                foreach (var user in users)
                {
                    MockDatabase.Users.Add((User)user);
                }
            }
            MockDatabase.SaveChanges();
        }

        protected List<User> GetData(string fileName)
        {
            string path = @"MockData\" + fileName + ".json";
            return JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(path));
        }
    }
}