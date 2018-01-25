using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashtables
{
    struct CoinInfo
    {
        public double coinPrice;
        public string coinName;
        public CoinInfo(double price, string name)
        {
            coinPrice = price;
            coinName = name;
        }
    }
    class Program
    {
        static Hashtable myHashTable;
        private static List<CoinInfo> coinDataList;
        static Stopwatch sw;


        static void Main(string[] args)
        {
            myHashTable = new Hashtable();
            coinDataList = new List<CoinInfo>();
            for (int i = 0; i < 4000000; i++)
            {
                myHashTable.Add(i, "coin" + i);
                coinDataList.Add(new CoinInfo(i, "coin" + i));
                sw = new Stopwatch();
            }

            if(myHashTable.Contains(0))
            {
                myHashTable.Remove(0);
            }

            if(myHashTable.ContainsKey(1))
            {
                myHashTable[1] = "HTMLCOIN";
            }

            /*
            foreach (DictionaryEntry entry in myHashTable)
            {
                Console.WriteLine("Key " + entry.Key + " / Value: " + entry.Value);
            }
            */

            Random randomCoinGen = new Random();
            int randomCoin = -1;

            sw.Start();
            float startTime = 0;
            float endTime = 0;
            float deltaTime = 0;

            int cycles = 5;
            int cycle = 0;
            string coinName = string.Empty;

            while (cycle < cycles)
            {
                randomCoin = randomCoinGen.Next(3000000, 4000000);

                //List time
             
                startTime = sw.ElapsedMilliseconds;
                coinName = getCoinfromList(randomCoin);
                endTime = sw.ElapsedMilliseconds;
                deltaTime = endTime - startTime;
                Console.WriteLine("Time taken to retrieve " + coinName +" From portfolio list: "+string.Format("{0:0.##}",deltaTime) + "ms");

                //Hashtable
                
                startTime = sw.ElapsedMilliseconds;
                coinName = (string)myHashTable[randomCoin];
                endTime = sw.ElapsedMilliseconds;
                deltaTime = endTime - startTime;
                Console.WriteLine("Time take to retrieve " + coinName + " From Hash portfolio list: " + string.Format("{0:0.##}", deltaTime) + "ms\n");

                cycle++;
            }
        }

        static string getCoinfromList(int price)
        {
            for(int i = 0; i < coinDataList.Count; i ++)
            {
                if(coinDataList[i].coinPrice == price)
                {
                    return coinDataList[i].coinName;
                }
            }
            return string.Empty;
        }
    }
}
