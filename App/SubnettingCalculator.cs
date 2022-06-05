using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace App
{
    class SubnettingCalculator
    {
      
        public SubnettingCalculator(IPAdress ip,SubnetMask subnet)
        {
            IP = ip;
            SubnetMask = subnet;
            IPClass = ip.Octets.IPAdressClass();
        }
        public IPAdress IP { get; private set; }
        public SubnetMask SubnetMask { get; private set; }

        public string Network { get; private set; }
        public string First { get; private set; }
        public string Last { get; private set; }
        public string Broadcast { get; private set; }
        public char IPClass { get; private set; }



        public void Calculate(IPAdress ip, SubnetMask subnet)
        {
            int[] subnet_array = subnet.Octets;
            int[] ip_array = ip.Octets;
            

            int net1, net2, net3, net4;
            net1 = subnet_array[0] & ip_array[0];
            net2 = subnet_array[1] & ip_array[1];
            net3 = subnet_array[2] & ip_array[2];
            net4 = subnet_array[3] & ip_array[3];


            Network = $"{net1}.{net2}.{net3}.{net4}";
            First = $"{net1}.{net2}.{net3}.{net4+1}";
            Last = $"{net1+(255-subnet_array[0])}.{net2+(255-subnet_array[1])}.{net3 + (255 - subnet_array[2])}.{net4 + (255 - subnet_array[3])-1}";
            Broadcast = $"{net1 + (255 - subnet_array[0])}.{net2 + (255 - subnet_array[1])}.{net3 + (255 - subnet_array[2])}.{net4 + (255 - subnet_array[3])}";
        }
        public int NumberOfHosts(IPAdress ip,SubnetMask subnet)
        {
            return 0;
        }
        public int NumberOfSubnets(IPAdress ip, SubnetMask subnet)
        {
            return 0;
        }
        public override string ToString()
        {
           return $"IP:{IP} \nClass:{IPClass} \nSubnetMask:{SubnetMask} \nNetwork:{Network} \nFirst:{First} \nLast{Last} \n{Broadcast}";
        }


        
    }
}
