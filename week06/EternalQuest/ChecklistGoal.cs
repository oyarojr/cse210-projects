namespace EternalQuestApp
{
    class ChecklistGoal : Goal
    {
        private int _amountCompleted;
        private int _target;
        private int _bonus;

        public ChecklistGoal(string name, string description, string points, int target, int bonus)
            : base(name, description, points)
        {
            _amountCompleted = 0;
            _target = target;
            _bonus = bonus;
        }

        public override void RecordEvent()
        {
            if (!IsComplete())
            {
                _amountCompleted++;
            }
        }

        public override bool IsComplete()
        {
            return _amountCompleted >= _target;
        }

        public string GetDetailsString()
        {
            string box = IsComplete() ? "[X]" : "[ ]";
            return $"{box} {_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
        }

        public override string GetDetails()
        {
            return GetDetailsString();
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal|{_shortName}|{_description}|{_points}|{_amountCompleted}|{_target}|{_bonus}";
        }

        public int AmountCompleted => _amountCompleted;
        public int Target => _target;
        public int Bonus => _bonus;
    }
}
