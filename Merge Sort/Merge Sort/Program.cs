using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge_Sort
{
    class Program
    {
        private static void Merge(int[] girdi, int sol, int orta, int sag)
        {
            int[] solkisim = new int[orta - sol + 1];          // Aslında girdiyi 2 ye bölüyor ve bu bölünenleri bir dizide tutuyoruz
            int[] sagkisim = new int[sag - orta];

            Array.Copy(girdi, sol, solkisim, 0, orta - sol + 1);
            Array.Copy(girdi, orta + 1, sagkisim, 0, sag - orta);

            int i = 0;
            int j = 0;
            for (int k = sol; k < sag + 1; k++)
            {
                if (i == solkisim.Length)
                {
                    girdi[k] = sagkisim[j];
                    j++;
                }
                else if (j == sagkisim.Length)
                {
                    girdi[k] = solkisim[i];
                    i++;
                }
                else if (solkisim[i] <= sagkisim[j])
                {
                    girdi[k] = solkisim[i];
                    i++;
                }
                else
                {
                    girdi[k] = sagkisim[j];
                    j++;
                }
            }
        }

        private static void  MergeSort(int[] girdi, int sol, int sag)
        {
            if (sol < sag)
            {
                int orta = (sol + sag) / 2;

                MergeSort(girdi, sol, orta);
                MergeSort(girdi, orta + 1, sag);

                Merge(girdi, sol, orta, sag);
            }
        }


        static void Main(string[] args)
        {
            int[] dizi = {1, 5, 4, 11, 20, 8, 2, 98, 90, 16};

            MergeSort(dizi, 0, dizi.Length - 1);
            Console.WriteLine("Sıralanmış Dizi:");
            for (int i = 0; i < dizi.Length; i++)
            {
                Console.WriteLine(dizi[i]);
            }
            Console.ReadLine();
        }
    }
}
