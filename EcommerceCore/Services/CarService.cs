using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceCore.Interfaces;
using EcommerceCore.Models;
using EcommerceCore.ViewModel;

namespace EcommerceCore.Services
{
    public class CarService : ICar
    {
        private readonly IReadWriteToJson _readWriteToJson;

        public CarService(IReadWriteToJson readWriteToJson)
        {
            _readWriteToJson = readWriteToJson;
        }

        public async Task<Car> GetACars(string Id)
        {
            var cars = await _readWriteToJson.ReadJson<Car>("Cars.json");

            var car = cars.Where(x => x.Id == Id).SingleOrDefault();

            return car;
        }

        public async Task<List<CarViewModel>> GetAllCars()
        {
            var cars = await _readWriteToJson.ReadJson<Car>("Cars.json");

            List<CarViewModel> result = new List<CarViewModel>();

            foreach (var item in cars)
            {
                CarViewModel carView = new CarViewModel()
                {
                    Id = item.Id,
                    Model = item.Model,
                    YearOfMan = item.YearOfMan,
                    Price = item.Price,
                    UnitOfPrice = item.UnitOfPrice,
                    Image = item.Images.Where(x => x.IsFeature == true).FirstOrDefault().ImageUrl,
                    Rating = (item.Ratings.Sum(x => x.Ratings) / item.Ratings.Count)
                };

                result.Add(carView);
            }

            return result;
        }
    }
}
