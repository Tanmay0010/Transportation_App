using DataLibary.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibary.Contracts
{
    public interface IDriverContracts
    {
        List<Driver> GetAllDrivers();
        Driver GetDriver(string CarNumber);
    }
}
