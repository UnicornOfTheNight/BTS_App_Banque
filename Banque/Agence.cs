using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banque
{
    class Agence
    {
        private string nom;
        private int nbComptes;
        private Compte[] lesComptes;

        public void Init (string nom)
        {
            this.nom = nom;
            nbComptes = 0;
            lesComptes = new Compte[100];

        }

        public string GetNom()
        {
            return nom;
        }

        public int GetNbCpt()
        {
            return nbComptes;
        }

        public bool ExisteNumero(int num)
        {
            int i = 0;
            bool trouve = false;

            while (i < GetNbCpt() && trouve == false)
            {
                if (lesComptes[i].GetNumero() == num)
                    trouve = true;

                i++;
            }

            return trouve;
        }

        public void DebiteFrais(double montant)
        {
            for(int i = 0; i<GetNbCpt(); i++)
            {
                lesComptes[i].Debiter(montant);
            }
        }

        public bool ExisteCpt (Compte cpt)
        {
            for(int i = 0; i < GetNbCpt(); i++)
			{
                if (lesComptes[i] == cpt) return true;
			}
            return false;
        }

        public bool AjoutCtp(Compte cpt)
        {
            if (ExisteCpt(cpt) || ExisteNumero(cpt.GetNumero()) || GetNbCpt() == lesComptes.Length)
                return false;
            else
            {
                lesComptes[nbComptes] = cpt;
                nbComptes++;
                return true;
            }
        }

        public Compte GetCtp(int numCpt)
        {
            int i = 0;
            bool trouve = false;
            
            while(i < nbComptes && trouve == false)
            {
                if (lesComptes[i].GetNumero() == numCpt)
                    trouve = true;
                else
                    i++;
            }

            if (trouve == true)
                return lesComptes[i];
            else
                return null;
        }

        public int NbDebiteur()
        {
            int nb = 0;
            for(int i = 0; i < GetNbCpt(); i++)
            {
                if(lesComptes[i].Debiteur())
                    nb++;
            }

            return nb;

        }

        public int ExisteCompteViaNom(string name)
		{
            int nbComptes = 0;
            for(int i = 0; i < GetNbCpt(); i++)
			{
                if (lesComptes[i].GetNom() == name) nbComptes++;
			}

            return nbComptes;
        }

    }
}
