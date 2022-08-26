using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EcommerceCore.Models;
using EcommerceCore.ViewModel;

namespace EcommerceCore.Interfaces
{
    public interface ICar
    {
        Task<List<CarViewModel>> GetAllCars();
        Task<Car> GetACars(string Id);
    }
}
