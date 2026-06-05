namespace MachineController.Functions
{
    public static class Globals
    {
        public static bool IsConnected { get; set; } = false;
        public static bool IsExtruderOn { get; set; } = false;
        public static bool IsHeatBedOn { get; set; } = false;
        public static int CurrentExtruderTemp { get; set; } = 0;
        public static int CurrentSeconds { get; set; } = 0;
        public static Point CurrentPosition { get; set; } = new Point(0, 0);
        //public static bool IsExtruderAtTemperature { get; set; } = false;
        //public static bool IsHeatedBedAtTemperature { get; set; } = false;
    }
}