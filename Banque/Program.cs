using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banque
{
    class Program
    {
        static void CreationCpt (ref Agence agence)
        {
            int choix = 1;
            double solde;
            double decouvertAutorise;
            double debitAutorise;
            int numeroCpt;
            string nom;

            while (choix == 1)
            {
                Console.WriteLine("Entrez un solde (par défaut il est a 0) : ");
				try
				{
                    solde = Convert.ToInt32(Console.ReadLine());
				}
				catch
				{
                    solde = 0;
				}
               

                Console.WriteLine("Entrez un decouvert maximal, tapez -1 si vous voulez garder celui par défaut");
                try
                {
                    decouvertAutorise = Convert.ToInt32(Console.ReadLine());
				}
				catch
				{
                    decouvertAutorise = -1;
				}

                Console.WriteLine("Entrez un debit maximal, tapez -1 si vous voulez garder celui par défaut");
                try
                {
                    debitAutorise = Convert.ToInt32(Console.ReadLine());
				}
				catch
				{
                    debitAutorise = -1;
				}

                Console.WriteLine("Entrez un numero : ");
				try
				{
                    numeroCpt = Convert.ToInt32(Console.ReadLine());
				}
				catch
				{
                    Console.WriteLine("Vous devez entrer un numéro de compte. Veuillez recommencer.");
                    return;
				}

                Console.WriteLine("Entrez un nom : ");
				try
				{
                    nom = Console.ReadLine();
				}
				catch
				{
                    Console.WriteLine("Vous devez entrer un nom pour le compte. Veuillez recommencer.");
                    return;
                }

                Compte cpt1 = new Compte(numeroCpt, nom, solde, decouvertAutorise, debitAutorise);
                
                if (agence.AjoutCtp(cpt1))
                    Console.WriteLine("Ajout réussi.");
                else
                    Console.WriteLine("Ajout non réussi, le compte existe déjà.");

                Console.WriteLine("\nSouhaitez vous créer un nouveau compte ?");
                Console.WriteLine("1 : OUI\n2 : NON");
                choix = Convert.ToInt32(Console.ReadLine());
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("*** CREATION D'UNE AGENCE ***\nEntrez le nom de l'agence : ");
            string nom = Console.ReadLine();

            Agence agt1 = new Agence();
            agt1.Init(nom);

            int choix = 0;

            while (choix != 11)
            {
                Console.WriteLine("\n*****MENU*****");
                Console.WriteLine("1 : Créer un ou plusieurs compte(s)");
                Console.WriteLine("2 : Avoir le nombre de compte de l'agence");
                Console.WriteLine("3 : Voir si un numero de compte existe deja via le numéro de compte");
                Console.WriteLine("4 : Voir le nombre de comptes débiteurs");
                Console.WriteLine("5 : Afficher les information d'un compte");
                Console.WriteLine("6 : Voir si un compte existe via le nom"); 
                Console.WriteLine("7 : Créditer");
                Console.WriteLine("8 : Débiter");
                Console.WriteLine("9 : Effectuer un virement");
                Console.WriteLine("10 : Comparer deux comptes");
                Console.WriteLine("11 : Quitter");

                choix = Convert.ToInt32(Console.ReadLine());

                switch (choix)
                {
                    case 1:
                        CreationCpt(ref agt1);
                        break;

                    case 2:
                        Console.WriteLine("\nIl y a " + agt1.GetNbCpt() + " comptes dans l'agence " + agt1.GetNom());
                        break;


                    case 3:
                        Console.WriteLine("\nQuel est le numero a vérifier ?");
                        int numero = Convert.ToInt32(Console.ReadLine());

                        if (agt1.ExisteNumero(numero))
                            Console.WriteLine("Il existe un compte avec le numero " + numero);
                        else
                            Console.WriteLine("Il n'existe pas de compte avec le numero " + numero);

                        break;

                    case 4 :
                        Console.WriteLine("\nIl y a " + agt1.NbDebiteur() + " comptes débiteurs.");
                        break;

                    case 5 :
                        Console.WriteLine("\nDe quel compte voulez vous voir les informations ? ");
                        numero = Convert.ToInt32(Console.ReadLine());

                        if (agt1.GetCtp(numero) != null)
                            agt1.GetCtp(numero).Afficher();
                        else
                            Console.WriteLine("Il n'existe aucun compte avec le numero " + numero + " .");
                        break;

                    case 6:
                        Console.WriteLine("Quel compte voulez vous vérifier ? ");
                        Console.WriteLine("Nom de la personne à qui appartient le compte : ");
                        string nomCompte = Console.ReadLine();

                        int nbComptes = agt1.ExisteCompteViaNom(nomCompte);
                        if (nbComptes > 0)
                            Console.WriteLine("Il existe " + nbComptes + " avec le nom " + nomCompte + ".");
                        else
                            Console.WriteLine("Il n'existe pas de compte avec le nom " + nomCompte + ".");

                        break;

                    case 7:
                        Console.WriteLine("\nQuel compte voulez vous créditer ?");
                        numero = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("\nSaisissez un montant à créditer :"); // crediter = donner de l'argent
                        double montantSaisi = Convert.ToInt32(Console.ReadLine());

                        if (agt1.ExisteNumero(numero))
                        {
                            agt1.GetCtp(numero).Crediter(montantSaisi);
                            Console.WriteLine("Le montant a bien été crédité.");
                        }
                        else
                            Console.WriteLine("Aucun compte avec le numéro " + numero + "n'existe.");

                        break;

                    case 8:
                        Console.WriteLine("\nQuel compte voulez vous débiter ?");
                        numero = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("\nSaisissez un montant à débiter :"); // debiter = retirer de l'argent
                        montantSaisi = Convert.ToInt32(Console.ReadLine());

                        if(agt1.ExisteNumero(numero) == false)
                            Console.WriteLine("Aucun compte avec le numéro " + numero + "n'existe.");
                        else if (agt1.GetCtp(numero).testPeutDebiter(montantSaisi))
                        {
                            agt1.GetCtp(numero).Debiter(montantSaisi);
                            Console.WriteLine("Transaction réussie.");
                        }
                        else
                            Console.WriteLine("Transaction impossible.");
                        
                        break;

                    case 9:
                        Console.WriteLine("\nQuel compte voulez vous débiter ?");
                        int nd = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Quel compte voulez vous créditer ?");
                        int nc = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("\nChoisir un montant : ");
                        montantSaisi = Convert.ToInt32(Console.ReadLine());

                        if (agt1.ExisteNumero(nd) == false || agt1.ExisteNumero(nc) == false)
                            Console.WriteLine("Aucun compte avec le numéro " + nd +" ou "+ nc + "n'existe.");
                        else if (agt1.GetCtp(nd).testPeutDebiter(montantSaisi))
                        {
                            agt1.GetCtp(nd).Debiter(montantSaisi);
                            agt1.GetCtp(nc).Crediter(montantSaisi);
                            Console.WriteLine("Transaction réussie.");
                        }
                        else
                            Console.WriteLine("Transaction impossible.");
                        
                        break;

                    case 10:
                        Console.WriteLine("\nQuels sont les 2 comptes à comparer ? ");
                        Console.WriteLine("Numero du premier compte : ");
                        numero = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Numero du second compte : ");
                        int n2 = Convert.ToInt32(Console.ReadLine());

                        if (agt1.ExisteNumero(numero) == false || agt1.ExisteNumero(n2) == false)
                            Console.WriteLine("Aucun compte avec le numéro " + numero + "n'existe.");
                        else 
                            agt1.GetCtp(numero).estSuperieur(agt1.GetCtp(n2));
                        
                        break;

                    case 11:
                        return;
                }


            }
            Console.ReadLine();
        }
    }
}
