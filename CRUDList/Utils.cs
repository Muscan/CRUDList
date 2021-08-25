using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CRUDList
{
    class Utils
    {
        public static void ReadFromFile(string filePath, List<Produs> produse)
        {
            string[] lines = File.ReadAllLines(filePath);
            for(int i=0; i<lines.Length;i++)
            {
                string[] word = lines[i].Split(" ");//desparte cu spatii fiecare linie(id, produs, pret)
                int ID = int.Parse(word[0]);//conversie la int a primului cuvant 
                string numeProdus = word[1];//al doilea cuvant e numele
                double pretProdus = double.Parse(word[2]);//conversie la double a stringului pret ca input
                Produs produs = new Produs(ID, numeProdus, pretProdus);//Declarare obiect nou produs
                produse.Add(produs);
            }
        }

        public static void WriteInFile(string filePath, List<Produs> produse)
        {
            StreamWriter sw = new StreamWriter(filePath);
            foreach(Produs produs in produse)
            {
                sw.WriteLine($"{produs.IdProdus} {produs.NumeProdus} {produs.PretProdus}");
            }
            sw.Flush();
            sw.Close();
        }

        public static void AddToFile(string filePath, Produs produs)
        {
            StreamWriter sw = new StreamWriter(filePath, true);//true la final pentru append
            sw.WriteLine($"{produs.IdProdus} {produs.NumeProdus} {produs.PretProdus}");
            sw.Flush();
            sw.Close();
        }

        public static bool IsNumber(string input)
        {
            if (char.IsDigit(input[input.Length - 1]) == true)
            {
                return true;
            }
            return false;
        }

      

        /* public static bool IdUnique(List<Produs> produs, int id)
        {
            //TBD
        }*/
        

    }
}
