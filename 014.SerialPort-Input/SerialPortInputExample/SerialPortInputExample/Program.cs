using System;
using Microsoft.SPOT;
using System.Text;
using Microsoft.SPOT.Hardware;
using System.IO.Ports;
using System.Threading;

namespace SerialPortInputExample
{
    public class Program
    {
        public static void Main()
        {
            SerialPort serialport1 = new SerialPort("COM2", 9600, Parity.None, 1);
            serialport1.ReadTimeout = 0;
            serialport1.Open();
            byte[] inputbuffer = new byte[32];
            while (true)
            {
                int count = serialport1.Read(inputbuffer, 0, inputbuffer.Length);
                if (count>0)
                {
                    char[] chars = Encoding.UTF8.GetChars(inputbuffer);
                    string str = new string(chars, 0, count);
                    Debug.Print(str);
                    Thread.Sleep(25);
                }
            }
        }
    }
}
