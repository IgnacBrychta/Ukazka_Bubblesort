using System;

namespace Ukazka_Bubblesort
{
    static class Program
    {
        /// <summary>
        /// Počet čísel ukázky
        /// </summary>
        static int pocetCisel = 10;
        public static void Main(string[] args)
        {
            int[] array = new int[pocetCisel];
            ZaplnitArrayNahodnymiCisly(ref array, horniLimit: 5000);
            VytisknoutArray(ref array);
            Console.WriteLine("Stisknete libovolne tlacitko pro pokracovani.\n");
            Console.ReadKey();
            array = TridiciAlgoritmy.Bubblesort(array);
            VytisknoutArray(ref array, "Prvky pole po setrideni:\n");
            Console.WriteLine("Stisknete libovolne tlacitko pro pokracovani.");
            Console.ReadKey();
        }
        /// <summary>
        /// Zaplní array náhodnými čísly, přímo array upravuje
        /// </summary>
        /// <param name="array">array čísel</param>
        /// <param name="dolniLimit">Nejmenší číslo, které se může v array 
        /// objevit (včetně)</param>
        /// <param name="horniLimit">Největší číslo, které se může v array 
        /// objevit (kromě)</param>
        private static void ZaplnitArrayNahodnymiCisly(ref int[] array, 
            int dolniLimit = 0, int horniLimit = 100)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(dolniLimit, horniLimit);
            }
        }
        /// <summary>
        /// Vytiskne parametr array do konzole
        /// </summary>
        /// <param name="array"></param>
        /// <param name="informace">Zpráva do konzole před tiskem pole. 
        /// Při nepřiřazení se vytiskne "Prvky pole:"</param>
        private static void VytisknoutArray(ref int[] array, string informace = null)
        {
            Console.WriteLine(informace ?? "Prvky pole:\n");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{i + 1}. cislo: {array[i]};\t");
            }
            Console.WriteLine("\n");
        }
    }
    /// <summary>
    /// Třída obsahující různé třídicí algoritmy
    /// </summary>
    public static class TridiciAlgoritmy
    {
        /// <summary>
        /// Seřadí array čísel pomocí algoritmu Bubblesort
        /// </summary>
        /// <param name="array">array čísel</param>
        /// <returns>Seřazený array</returns>
        public static int[] Bubblesort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] < array[j + 1])
                    {
                        Operace.ProhoditOdkazy(ref array[j], ref array[j + 1]);
                    }
                }
            }
            return array;
        }
    }
    /// <summary>
    /// Třída užitečných metod
    /// </summary>
    public static class Operace
    {
        /// <summary>
        /// Vzájemně prohodí odkazy na dva objekty stejného libovolného datového typu
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="odkazA"></param>
        /// <param name="odkazB"></param>
        public static void ProhoditOdkazy<T>(ref T odkazA, ref T odkazB)
        {
            (odkazA, odkazB) = (odkazB, odkazA);
        }
    }
}