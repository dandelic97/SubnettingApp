using System;
using System.Collections.Generic;
using System.Text;

namespace App
{
    class IPAdress
    {
        public IPAdress(string adress)
        {
            ip = adress;
            Octets = adress.AdressOctets();
            
        }
        public int[] Octets { get; private set; }
        private string ip;
        public string IP
        {
            get
            {
                return ip;
            }
            set
            {
                if (ip.AdressOctets().AdressCheck()!)
                {
                    throw new Exception("Octets range 0-255!");
                }
                ip = value;
            }
        }

        public override string ToString() => $"IP:{IP}";
       

    }
}
