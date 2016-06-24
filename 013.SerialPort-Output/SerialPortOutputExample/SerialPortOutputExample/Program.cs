using System;
using Microsoft.SPOT;
using System.Text;
using System.Threading;
using Microsoft.SPOT.Hardware;
using System.IO.Ports;

namespace SerialPortOutputExample
{
    public class Program
    {
        public static void Main()
        {
            SerialPort serialport1 = new SerialPort("COM2", 9600, Parity.None, 8);
            serialport1.Open();
            Debug.Print("Serial Port Opened!");
            byte[] sendbytes =UTF8Encoding.UTF8.GetBytes("Fatih");
            string debugstring = new string(UTF8Encoding.UTF8.GetChars(sendbytes));
            while (true)
            {
                serialport1.Write(sendbytes, 0, sendbytes.Length);
                Thread.Sleep(2000);
                Debug.Print(debugstring);
            }
        }
    }
}
