using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace zad.trzecie
{
    public class Osoba : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly static Dictionary<string, string[]> relatedProperties = new Dictionary<string, string[]>()
        {
            ["Tytuł"] = new string[] { "TytułReżyser", "FormatListy" },
            ["Reżyser"] = new string[] { "TytułReżyser", "FormatListy" },
            ["Rok"] = new string[] { "Wiek", "FormatListy" },
            ["Zakończenie"] = new string[] { "Wiek", "FormatListy" }
        };
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            if(relatedProperties.ContainsKey(propertyName))
                foreach(string relatedProperty in relatedProperties[propertyName])
                    OnPropertyChanged(relatedProperty);
            //śledzenie zapobiegające stack overflow?
        }

        static uint następneID = 0;
        /*uint wiek = 0;*/
        string
            tytuł,
            reżyser
            ;
        DateTime?
            rok = null,
            zakończenie = null
            ;

        public string Tytuł
        {
            get => tytuł;
            set
            {
                tytuł = value;
                OnPropertyChanged();
            }
        }
        public string Reżyser
        {
            get => reżyser;
            set
            {
                reżyser = value;
                OnPropertyChanged();
            }
        }
        public string Wiek { 
            get
            {
                if (rok != null)
                {
                    DateTime koniec;
                    if (zakończenie != null)
                        koniec = (DateTime)zakończenie;
                    else
                        koniec = DateTime.Now;
                    return ((koniec - (DateTime)rok).Days / 365).ToString();
                }
                else
                    return "BD";
            }
        }
        public DateTime? Rok
        {
            get => rok;
            set
            {
                rok = value;
                OnPropertyChanged();
            }
        }
        public DateTime? Zakończenie
        {
            get => zakończenie;
            set
            {
                zakończenie = value;
                OnPropertyChanged();
            }
        }
        public string TytułReżyser { get => $"{tytuł}, {reżyser}"; }
        public string FormatListy { get => $"Tytuł  {tytuł}, Reżyser  {reżyser}, {Wiek} Wiek Filmu"; }
        public uint ID { get; } = następneID++;
        public string FormatID { get => "ID: " + ID; }
    }
}
