using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace feleves_beadando
{
    
    internal class Program
    {
        static void Kiirat(int[,] tomb)
        {
            for (int i = 0; i < tomb.GetLength(0); i++)
            {
                for (int j = 0; j < tomb.GetLength(1); j++)
                {
                    Console.Write(tomb[i, j]);
                }
                Console.WriteLine();
            }

        }

        static void Megjelenit(int[,] tomb)
        {
            Console.Write("   ");
            for (int j = 0; j < tomb.GetLength(1); j++)//teteje
            {
                if (j + 1 < 10)
                {
                    
                    if ((j + 1) % 2 == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(j + 1 + "  ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(j + 1 + "  ");
                        Console.ResetColor();
                    }
                }
                else
                {
                    if ((j + 1)%2==0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(j + 1 + " ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(j + 1 + " ");
                        Console.ResetColor();
                    }


                }

            }
            Console.WriteLine();


            for (int i = 0; i < tomb.GetLength(0); i++)
            {
                if (i + 1<10)//oldal
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(i + 1 + "  ");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(i + 1 + " ");
                    Console.ResetColor();
                }

                for (int j = 0; j < tomb.GetLength(1); j++)//labdak
                {
                    
                    if (tomb[i, j] == 1)//piros
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(0+"  ");
                        Console.ResetColor();
                    } 
                    else if (tomb[i, j] == 2)//kék
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(0+"  ");
                        Console.ResetColor();
                    } 
                    else if (tomb[i, j] == 3)//sárga
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(0 + "  ");
                        Console.ResetColor();
                    }
                    else if (tomb[i, j] == 4) //zöld
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(0 + "  ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("X" + "  ");//0
                    }
                }
                Console.WriteLine();
                Console.WriteLine(); //valmaiért bugos
            }

        }

        static void Feltolt(int[,] tomb)
        {
            Random rnd = new Random();
            for (int i = 0; i < tomb.GetLength(0); i++)
            {
                for (int j = 0; j < tomb.GetLength(1); j++)
                {
                    tomb[i, j]= rnd.Next(1,5);
                }
            }

        }

        static int BekerJ(int[,]tomb) 
        {
            int j = 80;
            while (j > tomb.GetLength(1) - 1 || j < 0)
            {
                try
                {
                    Console.Write($"Adja meg az oszlop sorszámát (max {tomb.GetLength(1)}): ");
                    j = Convert.ToInt32(Console.ReadLine()) - 1;
                }
                catch
                {
                    Console.WriteLine("nem megfelelő formátumú karakter");
                }

            }
            return j;
        }

        static int BekerI(int[,]tomb)
        {
            int i = 25;

            while (i > tomb.GetLength(0)-1 || i < 0)//még kell, hogy csak int legyen
            {
                try
                {
                    Console.Write($"Adja meg a sor sorszámát (max{tomb.GetLength(0)}): ");
                    i = Convert.ToInt32(Console.ReadLine()) - 1;
                }
                catch
                {
                    Console.WriteLine("nem megfelelő formátumú karakter");
                }

            }
            return i;
        }

        static void Szomszedurit(ref int[,] tomb, int i, int j) 
        {
            if (tomb[i, j] != 0) 
            {           
                int szin = tomb[i,j];
                tomb[i, j] = 0;

                if (i < tomb.GetLength(0)-1 && tomb[i+1, j] == szin)//alatta
                {
                    Szomszedurit(ref tomb, i + 1, j);
                    tomb[i + 1, j] = 0;                
                }
                if (i > 0 && (tomb[i-1, j] == szin))//felette
                {
                    Szomszedurit(ref tomb, i - 1, j);
                    tomb[i - 1, j] = 0;
                }
                if (j < tomb.GetLength(1)-1 && tomb[i, j + 1] == szin)//jobb
                {
                    Szomszedurit(ref tomb, i, j + 1);
                    tomb[i, j + 1] = 0;
                }
                if (j > 0 && tomb[i, j - 1] == szin)//bal
                {
                    Szomszedurit(ref tomb, i, j - 1);
                    tomb[i, j - 1] = 0;
                }
                if (i > 0 && j < tomb.GetLength(1) - 1 && tomb[i - 1, j + 1] == szin)//jobb felett
                {
                    Szomszedurit(ref tomb, i - 1, j + 1);
                    tomb[i - 1, j + 1] = 0;
                }
                if (i < tomb.GetLength(0) - 1 && j < tomb.GetLength(1) - 1 && tomb[i + 1, j + 1] == szin)//jobb alatt
                {
                    Szomszedurit(ref tomb, i + 1, j + 1);
                    tomb[i + 1, j + 1] = 0;
                }
                if (i > 0 && j > 0 && tomb[i - 1, j - 1] == szin)//bal felett
                {
                    Szomszedurit(ref tomb, i - 1, j - 1);
                    tomb[i - 1, j - 1] = 0;
                }
                if (i < tomb.GetLength(0) - 1 && j > 0 && tomb[i + 1, j - 1] == szin)//bal alatt
                {
                    Szomszedurit(ref tomb, i + 1, j - 1);
                    tomb[i + 1, j - 1] = 0;
                }  
            }
        }

        static void Csusztat2(ref int[,] tomb) 
        {

            for (int j = 0; j < tomb.GetLength(1); j++)
            {
                for (int i = 1; i < tomb.GetLength(0); i++)
                {
                    if (tomb[i, j] == 0)
                    {
                        int k = i;
                        
                        while (k>0)
                        {
                            tomb[k, j] = tomb[k - 1, j];
                            k--; 
                        }
                        tomb[0, j] = 0;
                    }
                }
            }
            
            
        }



        public static void Oszlopcsusztat2(ref int[,] tomb)
        {
            int y = 0;
            int j = 0;
            while (y < tomb.GetLength(1) - 1)
            {
                j = y;
                while (j < tomb.GetLength(1) && tomb[tomb.GetLength(0) - 1, j] != 0)//megkeressük az első nullát, ha van j-edik 0-sor
                {
                    j++;
                }
                if (j < tomb.GetLength(1)) //ha van nulla
                {
                    //Console.WriteLine("van nulla");
                    for (int i = 0; i < tomb.GetLength(0); i++)
                    {
                        for (int k = j; k < tomb.GetLength(1) - 1; k++)
                        {
                            tomb[i, k] = tomb[i, k + 1];
                        }
                        tomb[i, tomb.GetLength(1) - 1] = -1;
                    }
                    y = j;
                }
                else 
                { 
                    //Console.WriteLine("nincs nulla"); 
                    y++; 
                }            
            }
        }

        static bool VegeCheck(int[,] tomb) //ha van olyan aminek a szomszédságában van azonos szín, akkor false, else true
        {
            bool vege = true;
            int i = 0;         
            while (i < tomb.GetLength(0) && vege) 
            {
                int j = 0;
                while ( j < tomb.GetLength(1) && tomb[i, j]!=-1 && vege) 
                {
                    if (tomb[i, j] != 0)//nullára ("x") nincs értelme vizsgálni, mert az nem golyó
                    {
                        int szin = tomb[i, j];
                        if (i < tomb.GetLength(0) - 1 && tomb[i + 1, j] == szin)//alatta
                        { vege = false; }
                        else if (i > 0 && (tomb[i - 1, j] == szin))//felett
                        { vege = false; }
                        else if (j < tomb.GetLength(1) - 1 && tomb[i, j + 1] == szin)//jobb
                        {  vege = false; }
                        else if (j > 0 && tomb[i, j - 1] == szin)
                        { vege = false; }
                        else if (i > 0 && j < tomb.GetLength(1) - 1 && tomb[i - 1, j + 1] == szin)//jobb felett
                        { vege = false; }
                        else if (i < tomb.GetLength(0) - 1 && j < tomb.GetLength(1) - 1 && tomb[i + 1, j + 1] == szin)//jobb alatt
                        { vege = false; }
                        else if (i > 0 && j > 0 && tomb[i - 1, j - 1] == szin)//bal felett
                        { vege = false; }
                        else if (i < tomb.GetLength(0) - 1 && j > 0 && tomb[i + 1, j - 1] == szin)//bal alatt
                        { vege = false; }
                    }
                    j++;
                }
                i++;
            }        
            return vege;
        }

        static int Pont(int[,] tomb)
        {
            int pont = 0;
            int i = tomb.GetLength(0)-1;
            while (i > 0 && tomb[i,0]!=0)
            {
                int j = 0;
                while (j < tomb.GetLength(1) && tomb[i, j] != -1)
                {
                    if (tomb[i, j] != 0) {  pont++; }
                    j++;
                }
                i--;
            }
                    return pont;
        }
      

        static void Main(string[] args)
        {
            Game game = new Game();

            Console.WriteLine("Adja meg a Felhasználónevet: ");
            string username = Console.ReadLine();

            int[,] jatekter = new int [5,5];
            Feltolt (jatekter);
            bool vege = false;
            int kor = 0;
            //kezdes = kezdesido
            Megjelenit(jatekter);
            
            while (vege==false)
            {              
                int i = BekerI(jatekter);
                int j = BekerJ(jatekter);
                Szomszedurit(ref jatekter,  i,  j);
                Csusztat2(ref jatekter);
                Oszlopcsusztat2(ref jatekter);
                Console.WriteLine();
                vege = VegeCheck(jatekter);
                kor++;
                Console.Clear();                   
                Megjelenit(jatekter);
            }
            
            Console.WriteLine($"Vége a játéknak! Kör: {kor}");
            game.UjPlayer(username, Pont(jatekter), kor);
            Player[] jatekosok = game.getPlayers();
            Game.Leadboard(jatekosok);
            game.Exp();
            
            Console.ReadKey();
        }
    }
}
