using ConsultationBack.dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;
using timsoft.DataBase;
using timsoft.entities;
using timsoft.Utils;

namespace timsoft.repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataBaseContext _conetxt;

        public UserRepository(DataBaseContext dataBase)
        {
            _conetxt = dataBase;
        }
        public User AddUser(UserForm user)
        {

            User dbuser = new User();
            dbuser.Nom = user.Nom;
            dbuser.Prenom = user.Prénom;
            dbuser.Username = user.Username;
            dbuser.Password = HashPassword.HashPass(user.Password);

            _conetxt.Users.Add(dbuser);
            _conetxt.SaveChanges();
            return dbuser;
        }



        public List<User> getAllUser()
        {
            return _conetxt.Users.ToList();    
        }

        public bool DeleteUser(int id)
        {
            User u = _conetxt.Users.Where(u => u.Id == id).FirstOrDefault();

            if (u == null)
                return false;

            _conetxt.Users.Remove(u);
            _conetxt.SaveChanges();
            return true;
        }

        public User GetUserById(int id)
        {
            User user = new User();
            if (user == null)
                throw new NullReferenceException();
            user = _conetxt.Users.Where(u => u.Id == id).FirstOrDefault();
            return user;
        }

        public bool UpdateUser(UserForm user, int id)
        {
            var itemToUpdate = _conetxt.Users.Where(i => i.Id == id).FirstOrDefault();
            if (itemToUpdate == null)
                return false;

            itemToUpdate.Username = user.Username;
            itemToUpdate.Nom = user.Nom;
            itemToUpdate.Prenom = user.Prénom;
            itemToUpdate.Password = HashPassword.HashPass(user.Password);
            itemToUpdate.role = user.role;
            _conetxt.SaveChanges();
            return true;
        }
        
    }
}
