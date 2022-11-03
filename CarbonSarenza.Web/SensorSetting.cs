namespace CarbonSarenza.Web
{
    public class SensorSetting
    {

        public double HotTemperature { get; }

        public double ColdTemperature { get; }

        public SensorSetting(double hotTemperature, double coldTemperature)
        {
            HotTemperature = hotTemperature;
            ColdTemperature = coldTemperature;
        }
    }
}
