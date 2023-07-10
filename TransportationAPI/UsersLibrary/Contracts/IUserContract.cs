using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersLibrary.Entities;

namespace UsersLibrary.Contracts
{
    public interface IUserContract
    {
        void Register(Users user);
        bool Login(Users User);
    }
}
