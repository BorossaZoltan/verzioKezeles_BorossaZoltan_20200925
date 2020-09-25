using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarcosProjekt
{
    class Harcos
    {
        private string nev;
        private int szint;
        private int tapasztalat;
        private int eletero;
        private int alapEletero;
        private int alapSebzes;

        public Harcos(string nev, int statuszSablon)
        {
            this.nev = nev;
            this.szint = 1;
            this.tapasztalat = 0;

            if (statuszSablon == 1)
            {
                this.alapEletero = 15;
                this.alapSebzes = 3;
            }
            if (statuszSablon == 2)
            {
                this.alapEletero = 12;
                this.alapSebzes = 4;
            }
            if (statuszSablon == 3)
            {
                this.alapEletero = 8;
                this.alapSebzes = 5;
            }
            this.eletero = MaxEletero;
        }

        public string Nev { get => nev; set => nev = value; }
        public int Szint { get => szint; 
            set {
                if (this.SzintLepeshez <= this.Tapasztalat)
                {
                    this.Tapasztalat -= this.SzintLepeshez;
                    this.Eletero = MaxEletero;
                }
            } 
        }
        public int Tapasztalat
        {
            get => tapasztalat;
            set
            {
                if (SzintLepeshez <= this.Tapasztalat)
                {
                    this.Szint++;
                }
            }
        }

        public int Eletero
        {
            get => eletero; 
            set{
                if (this.Eletero == 0)
                {
                    this.Tapasztalat = 0;
                }
                if (this.Eletero>MaxEletero)
                {
                    this.Eletero = MaxEletero;
                }
            } }
        public int AlapEletero { get => alapEletero;}
        public int AlapSebzes { get => alapSebzes;}
        public int Sebzes { get => (alapSebzes + szint); }
        public int SzintLepeshez { get => (10 + szint * 5); }
        public int MaxEletero { get => (alapEletero + szint * 3); }

        public void Megkuzd(Harcos masikHarcos)
        {
            if (this == masikHarcos)
            {
                Console.WriteLine("A két harcos ugyan az a személy.");
            }
            if (this.eletero == 0 || masikHarcos.eletero == 0)
            {
                Console.WriteLine("A harcos életereje 0.");
            }
            else
            {
                //harc eleje
                 masikHarcos.Eletero -= this.Sebzes;
                 if (masikHarcos.Eletero>0)
                 {
                     this.Eletero -= masikHarcos.Sebzes;
                 }
                 //harc vége
                 //tapasztalatosztás eleje
                if (masikHarcos.Eletero>0 && this.Eletero > 0)
                {
                    masikHarcos.Tapasztalat += 5;
                    this.Tapasztalat += 5;
                }
                if (masikHarcos.Eletero>0&& this.Eletero<=0)
                {
                    masikHarcos.Tapasztalat += 15;
                }
                else if (masikHarcos.Eletero <= 0 && this.Eletero > 0)
                {
                    this.Tapasztalat += 15;
                }
                //tapasztalatosztás vége

            }
        }
        public void Gyogyul()
        {

            if (this.Eletero <= 0)
            {
                this.Eletero = MaxEletero;
            }
            else
            {
                this.Eletero = 3 + Szint;
            }
            

        }
        public string ToString
        {
            get
            {
                return String.Format("{0}" +
                    " - LVL:{1}" +
                    " - EXP:{2}/{3}" +
                    " - HP:{4}/{5}" +
                    " - DMG: {6}", nev, szint, tapasztalat,SzintLepeshez, eletero,MaxEletero, Sebzes);
            }
        }
    }
}
