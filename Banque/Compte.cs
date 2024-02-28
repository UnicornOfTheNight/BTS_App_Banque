using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banque
{
    class Compte
    {
        private int numero;
        private string nom;
        private double solde;
        private double decouvertAutorise;
        private double debitAutorise;
        static private int nbCompte = 0;
        
        public Compte(int numero, string nom, double solde, double decouvertAutorise, double debitAutorise)
        {
            this.numero = numero;
            this.solde = solde;
            this.nom = nom;
            this.decouvertAutorise = decouvertAutorise;
            this.debitAutorise = debitAutorise;

            if (decouvertAutorise == -1)
                this.decouvertAutorise = solde * 0.25;

            if (debitAutorise == -1)
                this.debitAutorise = Math.Abs( solde * 0.10 );

            nbCompte++;
        }

        public void Crediter(double montantSaisi)
        {
            solde = solde + montantSaisi;
        }

        public void Debiter(double montantSaisi)
        {
            double tmp = solde;
            solde = solde - montantSaisi;

            if ((solde < decouvertAutorise) || (montantSaisi > debitAutorise))
            {
                Console.WriteLine("\nTRANSACTION IMPOSSIBLE.");
                solde = tmp;
            }

        }

        public bool Debiteur()
        {
            if (solde < 0)
                return true;
            else
                return false;
        }

        public void Afficher()
        {
            Console.WriteLine("\nNumero de compte : " + numero);
            Console.WriteLine("\nNom du titulaire : " + nom);
            Console.WriteLine("\nSolde : " + solde);
            Console.WriteLine("\nDécouvert autorisé : " + decouvertAutorise);
            Console.WriteLine("\nDebit maximal autorisé : " + debitAutorise);

            if (Debiteur())
                Console.WriteLine("\n\n Votre compte est à découvert de "+Math.Abs(solde)+"!");

        }

        public bool testPeutDebiter(double montantSaisi)
        {
            if (((solde - montantSaisi) >= decouvertAutorise) && ((solde - montantSaisi) >= debitAutorise))
                return true;
            else
                return false;
        }

        public void estSuperieur(Compte cpt)
        {
            
            if (this.GetSolde() > cpt.GetSolde())
                Console.WriteLine("Le compte numero "+ this.numero +" a plus d'argent.");
            else if (this.GetSolde() < cpt.GetSolde())
                Console.WriteLine("Le compte numero " + cpt.numero + "a plus d'argent.");
            else
                Console.WriteLine("Les deux comptes sont égaux.");
        }

        public double GetSolde()
        {
            return solde;
        }

        public void SetSolde(double solde)
        {
            this.solde = solde;
        }

        public int GetNumero()
        {
            return numero;
        }

        public void SetNumero(int numero)
        {
            this.numero = numero;
        }

        public string GetNom()
        {
            return nom;
        }
        public void SetNom(string nom)
        {
            this.nom = nom;
        }

        static public int GetNbCompte()
        {
            return nbCompte;
        }

        static public void SetNbCompte(int nbCompte)
        {
            Compte.nbCompte = nbCompte;
        }
    }
}
