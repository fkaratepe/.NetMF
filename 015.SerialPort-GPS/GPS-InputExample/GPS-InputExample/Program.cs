using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using System.IO.Ports;
using System.Text;
using System.Threading;

namespace GPS_InputExample
{
    public class Program
    {
        static SerialPort sr1 = new SerialPort("COM2", 9600, Parity.None, 8, StopBits.One);
        public static void Main()
        {
            sr1.Open();
            Thread GpsSampleSend = new Thread(GpsSampleSendFunc);
            Thread GpsReceive = new Thread(GpsReceiveFunc);
            GpsSampleSend.Start();
            GpsReceive.Start();
            Thread.Sleep(-1);
        }
        public static void GpsSampleSendFunc()
        {

            byte[] GpsSampleData = UTF8Encoding.UTF8.GetBytes("$GPGGA,092725.00,4717.11399,N,00833.91590,E,1,8,1.01,499.6,M,48.0,M,,0*5B");
            while (true)
            {
                sr1.Write(GpsSampleData, 0, GpsSampleData.Length);
                sr1.Flush();
                Thread.Sleep(1000);
            }
        }

        public static void GpsReceiveFunc()
        {
            while (true)
            {
                int length = sr1.BytesToRead;
                if (length > 0)
                {
                    byte[] inputbuffer = new byte[length];
                    sr1.Read(inputbuffer, 0, length);
                
                    char[] GPSData = Encoding.UTF8.GetChars(inputbuffer);
                    string str = new string(GPSData, 0, length);
                    Debug.Print(str);
                }
                Thread.Sleep(25);
            }

        }
    }
}
