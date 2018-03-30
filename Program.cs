using System;
using System.Diagnostics;
/*Neka je zadano sortirano polje   s n različitih cijelih brojeva (pozitivnih ili negativnih). 
 * Nađite algoritam kojim ćete pronaći indeks i (ako postoji) takav da je  A[i]=i. 
 * (Ne treba naći sve indekse.) Algoritam bi trebao imati vrijeme izvršavanja od  logn*/

namespace IndexMatchingValue
{
    class Program
    {
        static void Main(string[] args)
        {
            var sortedArray = getRandomInts(100000000);
            Array.Sort(sortedArray);
            var sw = new Stopwatch();
            sw.Start();
            findValuesWithMatchingIndexBruteForce(sortedArray);
            sw.Stop();
            Console.WriteLine("Brute force: " + sw.Elapsed);
            sw.Restart();
            findValuesWithMathingIndex(sortedArray, 0, sortedArray.Length-1);
            sw.Stop();
            Console.WriteLine("log(N): " + sw.Elapsed);
            Console.ReadLine();
        }

        public static void findValuesWithMatchingIndexBruteForce(int[] sortedArray)
        {
            for (int i = 0; i < sortedArray.Length; i++)            
                if (sortedArray[i] == i)                
                    Console.WriteLine("n approachWe've found matching pair index-value " + i);                
            
        }
        public static void findValuesWithMathingIndex(int[] sortedArray,int a,int b)
        {
            int i = (a + b) / 2;
            if (b==a) return;
            else if(i<sortedArray[i])//prema desno sigurno nema nijedan koji se poklapa jer su sortirani prema vecemu            
                findValuesWithMathingIndex(sortedArray, a, i);            
            else if(i>sortedArray[i])//prema lijevo sigurno nema nijedan koji se poklapa jer su sortirani prema vecem a indeks je veci od trenutnog            
                findValuesWithMathingIndex(sortedArray, i+1 , b);            
            else        
                Console.WriteLine("log(n) approach: We've found matching pair index-value " + i);            
        }
        public static int[] getRandomInts(int howMuch)
        {
            int[] numbers = new int[howMuch];
            var rand = new Random();
            for (int i = 0; i < howMuch; i++)
                numbers[i] = rand.Next(0, 50);                            
            return numbers;
        }
    }
}
