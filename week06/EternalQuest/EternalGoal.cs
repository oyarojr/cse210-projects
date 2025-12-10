namespace EternalQuestApp
{
    class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, string points)
            : base(name, description, points)
        {
        }

        public override void RecordEvent()
        {
            // Never completes; points awarded each record handled by manager
        }

        public override bool IsComplete()
        {
            // Eternal goals never complete
            return false;
        }

        public override string GetStringRepresentation()
        {
            // Format: EternalGoal|name|description|points
            return $"EternalGoal|{_shortName}|{_description}|{_points}";
        }

        public override string GetDetails()
        {
            // Indicate it's eternal
            return $"[∞] {_shortName} ({_description})";
        }
    }
}
