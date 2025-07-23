namespace MachineController.Objects
{
    public class Setting
    {
        private string m_Name;
        private string m_Value;

        public Setting()
        {
            m_Name = string.Empty;
            m_Value = string.Empty;
        }

        public Setting(string name, string value)
        {
            m_Name = name;
            m_Value = value;
        }

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public string Value
        {
            get { return m_Value; }
            set { m_Value = value; }
        }
    }
}