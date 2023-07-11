using DataLibary.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibary.Contracts
{
    public interface ICarContracts
    {
        void AddCar (Car car);
        void DeleteCar(string CarNumber);
        void EditCar(Car car);
        Car GetCar(string CarNumber);
        List<Car> GetAllCars();

    }
}
