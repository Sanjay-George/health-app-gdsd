using HealthApp.Components;

namespace HealthAppTests;

public class GoalTrackerTests{

    // Author: Navvya Bikesh
    [Fact]
    public void AddGoal_InValidGoal_ReturnsException(){
        var goalTracker = new GoalTracker();
        Assert.Throws<ArgumentNullException>(()=>goalTracker.AddGoal(GoalType.Not_Valid, 1));

    }
    // Author: Navvya Bikesh
    [Fact]
    public void AddGoal_NegativeTarget_ReturnsException(){
        var goalTracker = new GoalTracker();
        Assert.Throws<ArgumentOutOfRangeException>(()=>goalTracker.AddGoal(GoalType.Calorie, -1));

    }
    // Author: Navvya Bikesh
    [Theory]
    [InlineData(GoalType.Calorie, 1000)]
    public void AddGoal_ValidGoal_ReturnsTrue(GoalType type, int target){
        var goalTracker = new GoalTracker();
        Assert.Equal(goalTracker.AddGoal(type, target), true);
    }

    // Author: Sanjay George
    [Fact]
    public void GetGoalCompletionPercentage_GoalTypeCalorie_ReturnsPercentage()
    {   
        var goalTracker = new GoalTracker();
        var goalType = GoalType.Calorie;
        var goalValue = 1;

        goalTracker.AddGoal(goalType, goalValue);

        var ct = new CalorieTracker();
        SetupCaloriesMock(ct);
        Func<int> getTotalDelegate = () => ct.GetTotalCalories(); 

        var percentage = goalTracker.GetGoalCompletionPercentage(goalType, getTotalDelegate);
        var expectedCompletionPercentage = 100;
        Assert.Equal(percentage, expectedCompletionPercentage);
    }


    private void SetupCaloriesMock(CalorieTracker ct)
    {
        ct.AddCalorieValues(Food.Cookie, 1);
        ct.AddCalorie(Food.Cookie, 1);
    }
}