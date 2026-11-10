using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IUserRepository
        {
            Users AddUser(Users user);
            Users? GetUserById(int id);
            List<Users> GetUsersList();
        }
    }

