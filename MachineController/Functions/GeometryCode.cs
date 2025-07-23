using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineController.Functions
{
    public static class GeometryCode
    {
        public static string G0(double? x, double? y, double? z, double? e, double? f)
        {
            string code = "G0 ";

            if (x != null) { code += $"X{x} "; }
            if (y != null) { code += $"Y{y} "; }
            if (z != null) { code += $"Z{z} "; }
            if (e != null) { code += $"E{e} "; }
            if (f != null) { code += $"F{f} "; }

            return code;
        }
        public static string G1(double? x, double? y, double? z, double? e, double? f)
        {
            string code = "G1 ";

            if (x != null) { code += $"X{x} "; }
            if (y != null) { code += $"Y{y} "; }
            if (z != null) { code += $"Z{z} "; }
            if (e != null) { code += $"E{e} "; }
            if (f != null) { code += $"F{f} "; }

            return code;
        }

        public static string G4(int? ms, int? sec)
        {
            // TODO
            string code = "G2 ";
            return code;
        }

        public static string G10()
        {
            // TODO
            string code = "G10 ";
            return code;
        }

        public static string G12()
        {
            // TODO
            string code = "G12 ";
            return code;
        }

        public static string G28(Axis axis)
        {
            // TODO
            string code = "G18 ";
            return code;
        }

        public class Axis
        {
            public string X { get; set; }
            public string Y { get; set; }
            public string Z { get; set; }

        }
    }
}
