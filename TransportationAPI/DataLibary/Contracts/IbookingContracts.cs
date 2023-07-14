using DataLibary.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibary.Contracts
{
    public interface IbookingContracts
    {
        booking GetBookingDetail(string email);
         void AddDetail(booking book);
    }
}
