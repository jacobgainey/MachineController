using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineController.Objects
{
    public class Macro
    {
        private int m_Id;
        private string m_Name;
        private string m_Gcode;

        public Macro()
        {
            m_Id = 0;
            m_Name = string.Empty;
            m_Gcode = string.Empty;
        }

        public Macro(int id,string name, string gcode)
        {
            m_Id = id;
            m_Name = name;
            m_Gcode = gcode;
        }

        public int Id
        {
            get { return m_Id; }
            set { m_Id = value; }
        }

        public string Gcode
        {
            get { return m_Gcode; }
            set { m_Gcode = value; }
        }

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
    }
}
