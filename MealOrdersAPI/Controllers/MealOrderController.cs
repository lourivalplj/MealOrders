using MealOrders.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealOrdersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealOrderController : Controller
    {
        private readonly IMealService _mealService;
        

        public MealOrderController(IMealService mealService)
        {
            _mealService = mealService ?? throw new ArgumentNullException(nameof(IMealService));
        }


        [HttpGet("meal/{input}")]
        public async Task<string> GetMealAsync(string input)
        {
            return await _mealService.GetMeal(input);
        }
    }
}
