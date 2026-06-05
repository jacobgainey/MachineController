using System.IO.Ports;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MachineController.Functions
{

    public abstract class SerialConnection
    {
        private SerialPort? port = null;
        public bool IsConnected { get; private set; } = false;
        public string? PortName;
        public int? BaudRate;

        protected abstract void SendMessage(string text);

        public static List<string> GetComPorts()
        {
            List<string> ports = [.. SerialPort.GetPortNames()];
            return ports;
        }

        public static List<int> GetBaudRates()
        {
            List<int> rates = [9600, 19200, 38400, 57600, 115200, 230400, 250000];
            return rates;
        }

        public static List<string> GetToolheads()
        {
            List<string> tools = ["Tool1", "Tool2", "Tool3", "Tool4", "Tool5"];
            return tools;
        }

        public bool ConnectToComPort()
        {
            try
            {
                port = new SerialPort
                {
                    PortName = PortName ?? "COM1",
                    BaudRate = BaudRate ?? 115200,
                    WriteTimeout = 500,
                };
                port.DataReceived += new SerialDataReceivedEventHandler(OnDataReceived);
                port.DtrEnable = true;
                port.RtsEnable = true;
                port.Open();

                IsConnected = true;
                return true;
            }
            catch (Exception ex)
            {
                GenericFunctions.ShowErrorMessage(ex);
                return false;
            }
        }

        public void DisconnectFromComPort()
        {
            try
            {
                if (port != null && port.IsOpen)
                {
                    port.DataReceived -= OnDataReceived;
                    port.Close();
                }
                IsConnected = false;
            }
            catch (Exception ex)
            {
                GenericFunctions.ShowErrorMessage(ex);
            }
        }

        public void SendDataToMachine(string data, string append = "\r\n")
        {
            try
            {
                if (port != null) 
                {
                    port.Write($"{data.Trim()} {append}");
                }
                else
                {
                    throw new InvalidOperationException("Serial port is not initialized.");
                }
            }
            catch (Exception ex)
            {
                GenericFunctions.ShowErrorMessage(ex);
            }
        }

        public void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (port != null) 
                {
                    Thread.Sleep(5);
                    string data = port.ReadLine();
                    SendMessage(data.Trim());
                }
                else
                {
                    throw new InvalidOperationException("Serial port is not initialized.");
                }
            }
            catch (Exception ex)
            {
                GenericFunctions.ShowErrorMessage(ex);
            }
        }
    }

    public class ConnectToMachineSingleThread : SerialConnection
    {
        private readonly Action<string> write;

        public ConnectToMachineSingleThread(Action<string> write)
        {
            this.write = write;
        }

        public bool Connect()
        {
            //SendMessage("Connecting to Machine");
            return ConnectToComPort();
        }

        public void Disconnect()
        {
            //SendMessage("Disconnecting from Machine");
            DisconnectFromComPort();
        }

        public void Send(string data)
        {
            //SendMessage(data);
            SendDataToMachine(data);
        }

        protected override void SendMessage(string text)
        {
            write(text);
        }
    }
}