namespace Code.Services.Calculator.DurationCalculator
{
    public class DurationCalculator : IDurationCalculator
    {
        public float ConvertSpeedToDuration(float speed)
        {
            return 1 / speed;
        }
    }
}