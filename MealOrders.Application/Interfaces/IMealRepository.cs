using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MealOrders.Application.Interfaces
{
    public interface IMealRepository
    {
        Task<String> GetMeal(string[] data);
    }
}
