namespace API.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAllUsers(int id);
        User LogOn(User user);
        string GetGeneratedPassword(int passwordLength);
    }
}
