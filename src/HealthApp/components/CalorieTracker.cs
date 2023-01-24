namespace HealthApp.Components;


public enum Food
{
    Not_Valid = 0,
    Pizza = 1,
    Cookie = 2,
    Dosa = 3,
    Burger = 4,
    ExoticFruits = 5,
    
}

public class CalorieTracker
{
    
    private  IDictionary<Food, int> _calorieValues = new Dictionary<Food, int>(); 

    private int _totalCalories = 0;

    public int GetTotalCalories() => _totalCalories;

    private int GetCalorieByFood(Food food){
        _calorieValues.TryGetValue(food, out int calories);
        return calories;
    }

    public int AddCalorie(Food food, int serving)
    {
        if(food == Food.Not_Valid) {
            throw new ArgumentNullException("Food must be specified!");
        }

        if(serving <= 0){
            throw new ArgumentOutOfRangeException("Atleast one serving should be selected");
        }
        var calorie = GetCalorieByFood(food);
        _totalCalories += calorie * serving;
        return calorie * serving;

        // throw new NotImplementedException();
    }

    public bool AddCalorieValues(Food food, int calorie) 
    {
        if(food == Food.Not_Valid) {
            throw new ArgumentNullException();
        }
        if(calorie <= 0) {
            throw new ArgumentOutOfRangeException();
        }

        return _calorieValues.TryAdd<Food, int>(food, calorie);
    }


}