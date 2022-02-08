using System;
using System.Collections.Generic;

namespace MealOrders.Domain
{
    public class Meal
    {
        public string name { get; set; }
        public List<string> options { get; set; }

        public Meal(string name, List<string> options)
        {
            this.name = name;
            this.options = options;
        }
    }
}
