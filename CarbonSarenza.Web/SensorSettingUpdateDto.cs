namespace CarbonSarenza.Web
{
    public class SensorSettingUpdateDto
    {
        public double HotTemperature { get; }

        public double ColdTemperature { get; }

        public SensorSettingUpdateDto(double hotTemperature, double coldTemperature)
        {
            HotTemperature = hotTemperature;
            ColdTemperature = coldTemperature;
        }
    }
}