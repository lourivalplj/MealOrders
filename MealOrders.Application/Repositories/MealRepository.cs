using MealOrders.Application.Interfaces;
using MealOrders.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MealOrders.Application.Repositories
{
    public class MealRepository : IMealRepository
    {
        List<Meal> meals = new List<Meal>();

        public MealRepository()
        {           
            string name;
            List<string> options = new List<string>();

            name = "morning";
            options.Add("eggs");
            options.Add("toast");
            options.Add("coffee");

            meals.Add(new Meal(name, options));

            name = "night";
            options = new List<string>();
            options.Add("steak");
            options.Add("potato");
            options.Add("wine");
            options.Add("cake");

            meals.Add(new Meal(name, options));
        }
        public Task<string> GetMeal(string[] data)
        {
            string response = null;
            Meal meal = meals.Find(x => x.name == data[0]);

            for (int i = 1; i < data.Length; i++)
            {
                int numItem = Convert.ToInt16(data[i]);
                if (numItem <= meal.options.Count)
                {
                    response += meal.options[numItem - 1].ToString();
                    response += ", "; 
                }
                else
                {
                    response += "item unavailable";
                    response += ",";
                }
            }

            response = response.Remove(response.Length - 1);

            return Task.FromResult(response);
        }
    }
}
