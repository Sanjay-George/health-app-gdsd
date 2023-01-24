namespace HealthApp.Components;

public enum GoalType{

    Not_Valid = 0,
    Calorie = 1,
    Water = 2,
    Step=3

}


public class GoalTracker{

    private  IDictionary<GoalType , int> _goals = new Dictionary<GoalType, int>();

    public bool AddGoal(GoalType type, int target){
        if(type == GoalType.Not_Valid){
            throw new ArgumentNullException();
        }

        if(target <0){
            throw new ArgumentOutOfRangeException();
        }
        return _goals.TryAdd(type, target);
    }

    private int GetGoalTarget(GoalType type) {
        _goals.TryGetValue(type, out int target);
        return target;
    }

    public float GetGoalCompletionPercentage(GoalType type, Func<int> getTotalDelegate)
    {
        var target = GetGoalTarget(type);

        if(target == 0) {
            return 0;
        }

        var currentValue = getTotalDelegate();
        return (float)currentValue  / target * 100;
    }

}