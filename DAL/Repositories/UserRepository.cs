using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
        {
            private readonly AppDB _context;

            public UserRepository(AppDB context)
            {
                _context = context;
            }

            public Users AddUser(Users user)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return user;
            }

            public Users? GetUserById(int id)
            {
                return _context.Users.FirstOrDefault(u => u.Id == id);
            }

            public List<Users> GetUsersList()
            {
                return _context.Users.ToList();
            }

        }
    }
