using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.Models
{
    public class Devise
    {
        private int id;
        private string? nomDevise;
        private double taux;

        public double Taux
        {
            get { return taux; }
            set { taux = value; }
        }

        public string? NomDevise
        {
            get { return nomDevise; }
            set { nomDevise = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Devise()
        {
        }

        public Devise(int id, string? nomDevise, double taux)
        {
            Taux = taux;
            NomDevise = nomDevise;
            Id = id;
        }

        public static double ConvertEuroToDevise(double valeurD, Devise devise)
        {
            return devise.Taux * valeurD;
        }

        public static double ConvertDeviseToEuro(double valeurD, Devise devise)
        {
            return valeurD/devise.Taux;
        }

    public override bool Equals(object obj)
        {
            return obj is Devise devise &&
                   Taux == devise.Taux &&
                   NomDevise == devise.NomDevise &&
                   Id == devise.Id;
        }
    }
}
