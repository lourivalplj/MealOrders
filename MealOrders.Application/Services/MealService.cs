using MealOrders.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

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
            var data = input.Replace(" ", "").ToLower().Split(',');

            if (ValidateInput(data))
            {
                string response = await _mealRepository.GetMeal(data);

                response = FormatResponse(response);

                return response;
            }
            else
                return "Input in incorrect format";
        }

        private bool ValidateInput(string[] data)
        {
            bool isNumeric = int.TryParse(data[0], out int n);
            if (!isNumeric)
            {
                if(data[0] == "morning")
                {
                    int occurrencesEggs = data.Count(e => e == "1");
                    int ocurrencesToast = data.Count(t => t == "2");

                    if (occurrencesEggs < 2 && ocurrencesToast < 2)
                        return true;
                    else
                        return false;
                }
                else if (data[0] == "night")
                {
                    int occurrencesSteak = data.Count(e => e == "1");
                    int ocurrencesWine = data.Count(t => t == "3");
                    int ocurrencesDessert = data.Count(t => t == "4");

                    if (occurrencesSteak < 2 && ocurrencesWine < 2 && ocurrencesDessert < 2)
                        return true;
                    else
                        return false;
                }
                else
                    return false;

            }
            else 
                return false;
        }

        private string FormatResponse(string response)
        {
            var arrayResponse = response.Split(",");
            string result = "";

            for(int i = 0; i < arrayResponse.Length; i++)
            {
                if (!result.Contains(arrayResponse[i]))
                {
                    int ocurrences = arrayResponse.Count(x => x == arrayResponse[i]);
                    result += arrayResponse[i];

                    if (ocurrences > 1)
                    {
                        result += "(" + ocurrences + "x)";
                    }

                    result += ",";
                }
            }

            result = result.Remove(result.Length - 1);

            return result;
        }
    }
}
