using System;
using System.IO;

namespace ConsoleApp1
{   
    internal class Program
    {

        static double MostFar(double xa, double ya, double xb, double yb)
        {
            double wynik =  Math.Sqrt(Math.Pow(xb - xa, 2) + Math.Pow(yb - ya, 2));

            return wynik;

        }

        static int[] IntToArray(int n)
        {
            int[] array = new int[100];
            int licznik = 0;
            while (n != 0)
            {
                array[licznik] = n % 10;
                licznik++;
                n = n / 10;
            }
            return array;

        }

        static bool cyfropodobne(int a, int b)
        {
            int[] arrayA = IntToArray(a);
            int[] arrayB = IntToArray(b);
            bool bul;
            for(int i = 0; i < arrayA.Length; i++)
            {
                bul = false;
                for(int j = 0; j < arrayB.Length; j++)
                {
                    if (arrayA[i] == arrayB[j])
                    {
                        bul = true;
                        break;
                    }
                }
                if (bul == false)
                {
                    return false;
                }
                
            }
            
            for(int k = 0; k < arrayB.Length; k++)
            {
                bul = false;
                for(int l = 0; l < arrayA.Length; l++)
                {
                    if (arrayB[k] == arrayA[l])
                    {
                        bul = true;
                        break;
                    }
                }
                if(bul == false)
                {
                    return false;
                }
            }
            return true;
        }
        static bool Prime(int n)
        {
            int a = 0;
            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0)
                {
                    a++;
                }
            }
            if (a > 2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static void Main(string[] args)
        {
            try
            {
                StreamReader reader = new StreamReader("C:\\Users\\nyger\\Documents\\punkty.txt");
                StreamWriter writer = new StreamWriter("C:\\Users\\nyger\\Documents\\wynik.txt");
                
                double pojebanaxa = 0, pojebanaya = 0, pojebanaxb = 0, pojebanayb = 0, wtf = 0;

                string line = reader.ReadLine();
                int licznik = 0;
                while (line != null)
                {
                    string[] liczby = line.Split(' ');
                    int liczba1 = int.Parse(liczby[0]);
                    int liczba2 = int.Parse(liczby[1]);

                    if (cyfropodobne(liczba1, liczba2))
                    {
                        writer.WriteLine("Liczby: " + liczba1+" i "+liczba2+" są liczbami cyfropodobnymi");
                    }

                    if(Prime(liczba1) && Prime(liczba2))
                    {
                        licznik++;
                        writer.WriteLine(liczba1 + " " + liczba2+" = "+licznik);
                    }
                    


                    line = reader.ReadLine();
                    

                }

                reader.Close();
                writer.Close();

                StreamReader reader2 = new StreamReader("C:\\Users\\nyger\\Documents\\punkty.txt");
                StreamWriter writer2 = new StreamWriter("C:\\Users\\nyger\\Documents\\wynik.txt");
                
                for (int i = 0; i < 1000; i++)
                {
                    StreamReader reader3 = new StreamReader("C:\\Users\\nyger\\Documents\\punkty.txt");
                    StreamWriter writer3 = new StreamWriter("C:\\Users\\nyger\\Documents\\wynik.txt");

                    string line1 = reader2.ReadLine();
                    string[] liczby1 = line.Split(' ');

                    double xa = double.Parse(liczby1[0]);
                    double ya = double.Parse(liczby1[0]);

                    
                    int max = 0;
                    for (int  j = 0; j < 1000; j++)
                    {
                        if(i == j)
                        {
                            continue;
                        }
                        string line2 = reader3.ReadLine();
                        string[] liczby2 = line.Split(' ');
                        double xb = double.Parse(liczby2[0]);
                        double yb = double.Parse(liczby2[1]);

                        if (MostFar(xb, xa, yb, ya)>max)
                        {
                            pojebanaxb = xb;
                            pojebanaxa = xa;
                            pojebanayb = yb;
                            pojebanaya = ya;
                            wtf = MostFar(xb, xa, yb, ya);


                        }
                    }



                    reader3.Close();
                    writer3.Close();
                    
                }

                reader2.Close();
                writer2.Close();

                

                StreamWriter writerkys = new StreamWriter("C:\\Users\\nyger\\Documents\\wynik.txt");

                writerkys.WriteLine($"pojebane liczby:{pojebanaxb},{pojebanaxa} i {pojebanayb},{pojebanaya}    pozdro");

                writerkys.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("wystapil blad: "+e.Message);
            }

            
            

        }
    }
}
