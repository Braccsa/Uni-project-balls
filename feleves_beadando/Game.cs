using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feleves_beadando
{
    internal class Game
    {

        private Player[] players;
        private int dbGame;
        private DateTime gameStart;

        public Game() //constructor
        {
            players = new Player[0];
            StreamReader sr = new StreamReader("playerlist.txt", Encoding.UTF8);
            while(!sr.EndOfStream)
            {
                UjPlayerImp(sr.ReadLine());//létrehozza a playereket a txt alapján
            }
            sr.Close();
            dbGame = 0;//ide is
            gameStart = DateTime.Now;           
        }
        

        public void Exp()
        {
            StreamWriter sw = new StreamWriter("playerlist.txt", false, Encoding.UTF8);
            for(int i = 0; i < players.Length; i++)
            {
                sw.WriteLine(players[i].EgysorExp);//minden playert egy sorba kiírunk
            }
            sw.Close();
        }

        public void Sort (ref Player [] players)
        {
            for (int i = 0; i < players.Length; i++)
            {
                for (int j = i; j < players.Length; j++)
                {
                    if (players[i].Ido < players[j].Ido)
                    {
                        Player tmp = players[i];
                        players[i] = players[j];
                        players[j] = tmp;
                    }else if (players[i].Ido == players[j].Ido)
                    {
                        if(players[i].Pont > players[j].Pont)
                        {
                            Player tmp = players[i];
                            players[i] = players[j];
                            players[j] = tmp;
                        }
                    }
                }
            }
        }

        public void UjPlayer(string username, int pont, int kor)//játék végén felveszzük vele a player értékeit
        {          
            Player[] ujtomb = new Player[players.Length+1];
            for (int i = 0; i < players.Length; i++) 
            {
                ujtomb[i] = players[i];
            }
            TimeSpan ido = DateTime.Now - gameStart;
            Player ujPlayer = new Player(username, pont, ido, kor);// ehez egy konstruktor és akkor be lehet (be) pakolni az adatokat
            ujtomb[ujtomb.Length-1] = ujPlayer;//utsó helyre új jatekos
            players = ujtomb;//class tombjebe vissza
            dbGame++;
            Sort(ref players);
         
        }

        public void UjPlayerImp(string sor)
        {
            Player[] ujtomb = new Player[players.Length + 1];
            for (int i = 0; i < players.Length; i++)
            {
                ujtomb[i] = players[i];
            }
            TimeSpan ido = DateTime.Now - gameStart;
            Player ujPlayer = new Player(sor);// ehez egy konstruktor és akkor be lehet (be) pakolni az adatokat
            ujtomb[ujtomb.Length - 1] = ujPlayer;//utsó helyre új jatekos
            players = ujtomb;//class tombjebe vissza
            dbGame++;
         
        }

        public static void Leadboard(Player[] jatekosok)
        {
            for (int i = 0; i < jatekosok.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(jatekosok[i].Username + ": ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("[Pontszám: " + jatekosok[i].Pont + "]");
                Console.ResetColor();
                Console.Write("Kör: " + jatekosok[i].Kor + ", ");
                Console.WriteLine("Idő: " + jatekosok[i].Ido);
            }
        }
        public Player[] getPlayers()
        {
            return players;
        }

        

    }
}
