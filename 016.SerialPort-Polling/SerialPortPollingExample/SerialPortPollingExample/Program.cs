using System.IO.Ports;
using System;
using Microsoft.SPOT;
using System.Text;
using Microsoft.SPOT.Hardware;
using System.Threading;

namespace SerialPortPollingExample
{
    public class Program
    {
        public static void Main()
        {
            SerialPort myserialport = new SerialPort("COM2", 9600, Parity.None, 8, StopBits.One);
            myserialport.ReadTimeout = 5000;
            myserialport.Open();
            byte[] writebuffer = UTF8Encoding.UTF8.GetBytes("OK");
            byte[] inputbuffer = new byte[2];
            while (true)
            {
                myserialport.Write(writebuffer, 0, writebuffer.Length);
                myserialport.Read(inputbuffer, 0, inputbuffer.Length);
                if ((inputbuffer[0]==79)&&(inputbuffer[1]==75))
                {
                    Debug.Print("OK");
                }
                else
                {
                    Debug.Print("FALSE");
                }
                Thread.Sleep(1000);
            }
        }
    }
}
