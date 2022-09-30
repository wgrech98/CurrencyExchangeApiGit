//using CurrencyExchangeApi.Data;
//using CurrencyExchangeApi.Models;
//using CurrencyExchangeApi.Services.Interfaces;

//namespace CurrencyExchangeApi.Services
//{
//    public class UserService : IUserService
//    {
//        private AppDbContext _context;

//        public UserService(AppDbContext dbContext)
//        {
//            _context = dbContext;
//        }

//        public ApplicationUserModel Create(ApplicationUserModel user)
//        {
//            if (_context.Users.Any(x => x.Email == user.Email)) throw new ApplicationException("An account already exists with this email");

//            _context.Users.Add(user);
//            _context.SaveChanges();

//            return user;
//        }

//        public IEnumerable<ApplicationUserModel> GetAllUsers()
//        {
//            return _context.Users.ToList();
//        }



//        //public ApplicationUserModel GetById(int id)
//        //{
//        //    var user = _context.Users.Where(x => x.Id == id).FirstOrDefault();
//        //    if (user == null) return null;

//        //    return user;
//        //}

//        public ApplicationUserModel GetByUserName(string username)
//        {
//            var user = _context.Users.Where(x => x.UserName == username).FirstOrDefault();
//            if (user == null) return null;

//            return user;
//        }
//    }
//}

