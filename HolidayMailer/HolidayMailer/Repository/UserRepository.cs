using HolidayMailer.DataBase;
using HolidayMailer.Models;

namespace HolidayMailer.Repository
{
    public class UserRepository
    {
        private readonly HolidayDBContext _context;
        public UserRepository()
        {
            _context = new HolidayDBContext();
        }

        public User GetUserByUserName(string username) => _context.Users.Where(user => user.Email == username).FirstOrDefault();
        public User GetUserById(int id) => _context.Users.Where(user => user.Id == id).FirstOrDefault();

        public bool RegisterUser(string email, string fullName, string password)
        {
            var user = new User()
            {
                Email = email,
                Name = fullName,
                Password = password
            };
            try
            {
                var result = _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        internal List<User> GetAll()
        {
            return _context.Users.ToList();
        }
    }
}
