using MealOrders.Application.Interfaces;
using MealOrders.Application.Services;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MealOrders.Test
{
    public class MealServiceTest
    {
        protected readonly MealService _mealService;
        private readonly Mock<IMealRepository> _mealRepositoryMock;

        public MealServiceTest()
        {
            _mealRepositoryMock = new Mock<IMealRepository>();
            _mealService = new MealService(_mealRepositoryMock.Object);

            
        }

        [Fact]
        public async Task ValidResult()
        {
            //arrange
            string input = "morning, 1, 2, 3, 3, 3";

            //act          
            var resultado = await _mealService.GetMeal(input);
            
            //assert 
            Assert.NotEqual("Input in incorrect format", resultado);
        }

        [Fact]
        public async Task InvalidResult()
        {
            //arrange
            string input = "5, 1, 2, 3, 3, 3";

            //act
            var resultado = await _mealService.GetMeal(input);

            //assert 
            Assert.Equal("Input in incorrect format", resultado);
        }
    }
}
