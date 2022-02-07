using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MealOrders.Application.Interfaces
{
    public interface IMealService
    {
        Task<String> GetMeal(string input);
    }
}
