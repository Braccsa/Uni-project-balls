using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace feleves_beadando
{
    public class Player 
    {
        private string username;
        private int pont;
        private int kor;
        private TimeSpan ido;

        public string Username 
        {
            get { return username; }
            set 
            {
                if (value == null) 
                { username = "Vendég"; }
                else { username = value; }
            }
        }
        public int Pont
        {
            get { return pont; }
            set { pont = value; }
        }
        public TimeSpan Ido
        {
            get { return ido; }
            set { ido = value; }
        }
        public int Kor
        {
            get { return kor; }
            set { kor = value; }
        }


        public string EgysorExp//elválasztva, egysorba írja egy player adatait
        {
            get
            {
                return $"{Username};{Pont};{Kor};{Ido}";
            }
        }

        public Player(string sor) //konstruktor txt-ből beolvasáshoz
        {
            //uname;kor;time
            string[] adatok = sor.Split(';');
            this.Username = adatok[0];
            this.Pont= int.Parse(adatok[1]);
            this.Kor = int.Parse(adatok[2]);
            this.Ido = TimeSpan.Parse(adatok[3]);
            
        }
        public Player(string username, int pont, TimeSpan ido, int kor) //konstruktor
        { 
            this.Username = username;
            this.Pont = pont;
            this.Ido = ido;
            this.Kor = kor;
        }

        
       

    }
}
