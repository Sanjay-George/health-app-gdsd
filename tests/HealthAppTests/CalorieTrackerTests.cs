using HealthApp.Components;

namespace HealthAppTests;

public class CalorieTrackerTests
{
    private CalorieTracker _calorieTracker;
    public CalorieTrackerTests(){
         _calorieTracker = new CalorieTracker();
         _calorieTracker.AddCalorieValues(Food.ExoticFruits, 120);
         _calorieTracker.AddCalorieValues(Food.Pizza, 300);
         _calorieTracker.AddCalorieValues(Food.Burger, 800);
    }

    // Author: Sanjay George
    [Fact]
    public void AddCalorie_FoodIsInvalid_ThrowsException()
    {
        var food = Food.Not_Valid; 
        var serving = 1;

        Assert.Throws<ArgumentNullException>(() => _calorieTracker.AddCalorie(food, serving));    
    }

    // Author: Sanjay George
    [Fact]
    public void AddCalorie_ServingIsZeroOrNegative_ThrowsException(){
        var food = Food.Burger;
        var serving = 0;

        Assert.Throws<ArgumentOutOfRangeException>(()=> _calorieTracker.AddCalorie(food, serving));
    }

    // Author: Navvya Bikesh
    [Theory]
    [InlineData(Food.Cookie,2)]
    [InlineData(Food.Pizza,3)]
    [InlineData(Food.Dosa,4)]
    public void AddCalorie_ValidParameters_ReturnsCalorieGreaterThanZero(Food food, int serving){
        var actualCalories = _calorieTracker.AddCalorie(food, serving);
        Assert.True(actualCalories >= 0);
    }

    // Author: Navvya Bikesh
    [Fact]
    public void AddCalorieValues_FoodIsInvalid_ThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() => _calorieTracker.AddCalorieValues(Food.Not_Valid, 1));
    }
    
    // Author: Navvya Bikesh
    [Fact]
    public void AddCalorieValues_CalorieEqualOrLessThanZero_ThrowsException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _calorieTracker.AddCalorieValues(Food.Dosa, 0));
    }

     // Author: Sanjay George
    [Theory]
    [InlineData(Food.Burger, 1)]
    public void AddCalorieValues_ValueAlreadyExists_ReturnsFalse(Food food, int calories)
    {
        Assert.Equal(_calorieTracker.AddCalorieValues(food, calories), false);
    }

    // Author: Sanjay George
    [Theory]
    [InlineData(Food.Dosa, 1)]
    public void AddCalorieValues_ValueDoesNotExists_ReturnsTrue(Food food, int calories)
    {
        Assert.Equal<bool>(_calorieTracker.AddCalorieValues(food, calories), true);
    }


    
}