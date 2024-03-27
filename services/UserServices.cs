using timsoft.entities;
using timsoft.repositories;
using timsoft.Utils;
using ConsultationBack.dto;

namespace timsoft.services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUtil _util;

        public UserService(IUserRepository userRepository, IUtil util)
        {
            _userRepository = userRepository;
            _util = util;
        }


        public List<User> getAllUser()
        {
            return _userRepository.getAllUser();
        }

        public User AddUser(UserForm user)
        {
            return _userRepository.AddUser(user);
        }

        public string SignIn(SignIn signIn)
        {
            if (_util.verifyUserName(signIn) == false)
            {
                return "wrong userName";
            }

            if (_util.verifyPassword(signIn) == false)
            {
                return "wrong password";
            }

            var token = _util.GenerateToken(signIn);
            return token;

        }

        public bool DeleteUser(int id)
        {
            return _userRepository.DeleteUser(id);
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public bool UpdateUser(UserForm user, int id)
        {
            return _userRepository.UpdateUser(user, id);
        }
    }
}
