using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace API.Test
{
    public class UnitTest
    {
        private DbContextOptions<DatabaseContext> options;
        protected DatabaseContext MockDatabase;
        protected UserRepository UserRepository;
        protected UserController Controller;

        public UnitTest()
        {
            options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "MockDB")
                .Options;
            MockDatabase = new DatabaseContext(options);
            FillTheMockDatabase();
            UserRepository = new UserRepository(MockDatabase);
            Controller = new UserController(UserRepository);
        }

        protected static readonly string okObjectResult = typeof(OkObjectResult).FullName!;
        protected static readonly string okResult = typeof(OkResult).FullName!;
        protected static readonly string badRequestResult = typeof(BadRequestObjectResult).FullName!;
        public readonly Random random = new Random();

        protected void FillTheMockDatabase()
        {
            bool databaseIsFilled = MockDatabase.Users.Any();
            if (!databaseIsFilled)
            {
                var users = GetData<User>("User");
                foreach (var user in users)
                {
                    MockDatabase.Users.Add(user);
                }
                var roles = GetData<Role>("Role");
                foreach(var role in roles)
                {
                    MockDatabase.Roles.Add(role);
                }
                var privileges = GetData<Privilege>("Privilege");
                foreach (var privilege in privileges)
                {
                    MockDatabase.Privileges.Add(privilege);
                }
                MockDatabase.SaveChanges();
            }
        }

        protected List<T> GetData<T>(string fileName)
        {
            string path = @"MockData\" + fileName + ".json";
            return JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(path));
        }

        protected int GetNewId(Type type)
        {
            var objects = GetData<User>(type.Name.ToString());
            var identities = objects.Select(o => o.Id);
            var id = identities.Last();
            while (identities.Contains(id))
            {
                id++;
            }
            return id;
        }
    }
}