using MealOrders.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MealOrders.Application.Services
{
    public class MealService: IMealService
    {
        private IMealRepository _mealRepository;

        public MealService(IMealRepository mealRepository)
        {
            _mealRepository = mealRepository;
        }

        public async Task<string> GetMeal(string input)
        {
            var data = input.Trim().Split(',');
            string response = await _mealRepository.GetMeal(data);

            return response;
        }
    }
}
