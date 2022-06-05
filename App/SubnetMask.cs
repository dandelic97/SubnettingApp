using System;
using System.Collections.Generic;
using System.Text;

namespace App
{
    class SubnetMask
    {
        public SubnetMask(string adress)
        {
            Subnet = adress;
            Octets = adress.AdressOctets();
        }
        public int[] Octets;
        private string subnet;
        public string Subnet    
        {
            get
            {
                return subnet;
            }
            set
            {
                if (subnet.AdressOctets().AdressCheck()!)
                {
                    throw new Exception("Octets range 0-255!");
                }
                subnet = value;
            }
        }
        public override string ToString() => $"{Subnet}";
        
    }
}
