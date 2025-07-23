using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MachineController.Objects
{
    public class LibraryEntry
    {
        private int m_Id;
        private string m_FileName;
        private string m_FilePath;
        private string m_RunTime;
        private string m_MaterialUsed;

        public LibraryEntry()
        {
            m_Id = 0;
            m_FileName = string.Empty;
            m_FilePath = string.Empty;
            m_RunTime = string.Empty;
            m_MaterialUsed = string.Empty;
        }

        public LibraryEntry(int id, string filename, string filepath, string runtime, string materialused)
        {
            m_Id = id;
            m_FileName = filename;
            m_FilePath = filepath;
            m_RunTime = runtime;
            m_MaterialUsed = materialused;
        }

        public int Id
        {
            get { return m_Id; }
            set { m_Id = value; }
        }

        public string FileName
        {
            get { return m_FileName; }
            set { m_FileName = value; }
        }

        public string FilePath
        {
            get { return m_FilePath; }
            set { m_FilePath = value; }
        }

        public string RunTime
        {
            get { return m_RunTime; }
            set { m_RunTime = value; }
        }

        public string MaterialUsed
        {
            get { return m_MaterialUsed; }
            set { m_MaterialUsed = value; }
        }
    }
}
