using ConsultationBack.dto;
using timsoft.entities;

namespace timsoft.services
{
    public interface IUserService
    {
        public string SignIn(SignIn signIn);
        public User AddUser(UserForm user);
        public List<User> getAllUser();
        bool DeleteUser(int id);
        public User GetUserById(int id);
        bool UpdateUser(UserForm user, int id);
    }
}
