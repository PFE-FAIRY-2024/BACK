using ConsultationBack.dto;
using timsoft.entities;

namespace timsoft.repositories
{
    public interface IUserRepository
    {
        public User AddUser(UserForm user);
        public List<User> getAllUser();
        bool DeleteUser(int id);
        public User GetUserById(int id);
        bool UpdateUser(UserForm user, int id);
    }
}
