using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad.trzecie
{
    class Model
    {
        
        public LinkedList<Osoba> Lista { get; set; } = new LinkedList<Osoba>(new Osoba[] {
            new Osoba() {
                Tytuł = "Top Gun",
                Reżyser = "Tony Scott",
                Rok = DateTime.Parse("12.05.1986")
            },
            new Osoba() {
                Tytuł = "FANTASTYCZNE ZWIERZĘTA",
                Reżyser = "David Yates",
                Rok = DateTime.Parse("7.04.2022")
            },
            new Osoba() {
                Tytuł = "DOKTOR STRANGE W MULTIWERSUM OBŁĘDU",
                Reżyser = "Sam Raimi",
                Rok = DateTime.Parse("06.05.2010")
            },
            new Osoba() {
                Tytuł = "BATMAN",
                Reżyser = "Matt Reeves",
                Rok = DateTime.Parse("2.03.2021")
            },
        });

        internal void OtwórzSzczegóły(Osoba wybrany)
        {
            Szczegóły szczegóły = new Szczegóły(wybrany);
            szczegóły.Show();
        }
        internal void DodajNowy()
        {
            Osoba nowa = new Osoba();
            Lista.AddLast(nowa);
            Szczegóły szczegóły = new Szczegóły(nowa);
            szczegóły.Show();
            
        }
    }
}
