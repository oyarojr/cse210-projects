using System;
using System.Globalization;

namespace EternalQuestApp
{
    abstract class Goal
    {
        protected string _shortName;
        protected string _description;
        protected string _points;

        public Goal(string name, string description, string points)
        {
            _shortName = name;
            _description = description;
            _points = points;
        }


        public abstract void RecordEvent();


        public abstract bool IsComplete();


        public virtual string GetDetails()
        {
            string box = IsComplete() ? "[X]" : "[ ]";
            return $"{box} {_shortName} ({_description})";
        }


        public abstract string GetStringRepresentation();


        protected int GetPointsAsInt()
        {
            if (int.TryParse(_points, NumberStyles.Integer, CultureInfo.InvariantCulture, out var val))
                return val;
            return 0;
        }


        public string ShortName => _shortName;
        public string Description => _description;
        public string PointsString => _points;
    }
}
