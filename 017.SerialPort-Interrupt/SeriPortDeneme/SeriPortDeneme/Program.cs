using System;
using Microsoft.SPOT;
using System.IO.Ports;
using System.Threading;
using System.Text;

namespace SeriPortDeneme
{
    public class Program
    {

        //SeriPort Nesnesi oluþturuldu
        public static SerialPort seri1 = new SerialPort("COM2", 9600, Parity.None, 8, StopBits.None);
        public static void Main()
        {
            //Seri porta data gelince oluþan interrupt
            seri1.DataReceived += seri1_DataReceived;
            //seri1.ReadTimeout = 10;
            //Seri port açýldý
            seri1.Open();
            //Gönderilecek komutu bir byte dizisine aktaralým:
            byte[] komut = Encoding.UTF8.GetBytes("$GPGGA,201308.255,4737.9922,N,12211.1734,W,1,05,2.9,30.1,M,-17.2,M,0.0,0000*78");

            byte[] komut2 = Encoding.UTF8.GetBytes("$GPGGA,123519,4807.038,N,01131.000,E,1,08,0.9,545.4,M,46.9,M,,*47");
            while (true)
            {
                //Seri porttan veri gönderiliyor.
                seri1.Write(komut, 0, komut.Length);
                //Seri port flush
                seri1.Flush();
                Thread.Sleep(10);
                seri1.Write(komut2, 0, komut2.Length);
                seri1.Flush();
                Thread.Sleep(10);
            }
            
        }

        static void seri1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //Gelen verinin kaç bit olduðu
            int bufferlength = seri1.BytesToRead;
            
            byte[] rxbuffer = new byte[bufferlength];
            //Gelen veri byteler halinde rxbuffera alýnýyor
            seri1.Read(rxbuffer, 0, bufferlength);

            //Gelen veriler rx data ya aktarýlýyor
            string rxdata = new string(System.Text.Encoding.UTF8.GetChars(rxbuffer));
            //Gelen veri , e göre parçalanýyor
            string[] Parcalar = rxdata.Split(',');

            if (Parcalar[0]=="$GPGGA")
            {
                Debug.Print("Saat=" + Parcalar[1]);
                Debug.Print("Enlem=" + Parcalar[2]);
                Debug.Print("Boylam=" + Parcalar[4]);

                Debug.Print(rxdata); 
            }
               
            
            
        }
    }
}
