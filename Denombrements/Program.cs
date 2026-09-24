using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Denombrements
{
    class Program
    {
        
        /// <summary>
        /// contrôle que le chiffre choisi est bien compris entre 0 et 3
        /// </summary>
        /// <param name="c"> numéro choisi </param>
        /// <returns> choix d'opération </returns>
        static int reponse()
        {
            int c;
            do
            {
                Console.WriteLine("Permutation ...................... 1");
                Console.WriteLine("Arrangement ...................... 2");
                Console.WriteLine("Combinaison ...................... 3");
                Console.WriteLine("Quitter .......................... 0");
                Console.Write("Choix :                            ");
                c = int.Parse(Console.ReadLine());
            } while (c < 0 || c > 3);
            return c;
        }
        
        /// <summary>
        /// Détermine le nombre d'éléments à gérer
        /// </summary>
        /// <param name="nb"> entre le nb d'éléments à gérer </param>
        /// <returns> nombre d'éléments à gérer </returns>
        static int tot(string message)
        {

            Console.Write(message);
            int nb = int.Parse(Console.ReadLine());
            return nb;
        }

        /// <summary>
        /// Calcul de la permutation
        /// </summary>
        /// <param name="total"> nb total d'objets </param>
        /// <param name="k"> gère le nombre de répétitions de la boucle </param>
        /// <param name="resultat"> résultat du calcul </param>
        /// <param name="a"> E/S pour afficher le total dans le prog </param>
        /// <returns> résultat de la permutation </returns>
        static long perm(int total)
        {
            long resultat = 1;
            for (int k=1; k<=total; k++)
            {
                resultat*= k;
            }
            return resultat;
        }

        /// <summary>
        /// fait le calcul de l'arrangement entre un total et un sous-ensemble
        /// </summary>
        /// <param name="a"> renvoie le total dans le main pour affichage </param>
        /// <param name="b"> renvoie le sous-ensemble dans le main pour affichage </param>
        /// <param name="total"> nombre total d'objets déterminés dans le module tot() </param>
        /// <param name="sstot"> nombre d'objets du sous-ensemble déterminé dans le module ssens() </param>
        /// <param name="k"> gère le nombre de répétitions de la boucle </param>
        /// <returns> réultat de l'arrangement </returns>
        static long arr(ref int a, ref int b)
        {
            int total = tot("nombre d'éléments à gérer : ");
            a = total;
            int sstot = tot("nombre d'éléments du sous-ensemble : ");
            b = sstot;
            long resultat = 1;
            for (int k = total - sstot + 1; k <= total; k++)
            {
                resultat *= k;
            }
            return resultat;

        }
        static void Main(string[] args)
        {
            //Choix d'opération
            int c = reponse();
            while (c!=0)
            {
                if (c == 1)
                {
                    //Choix d'un nombre et calcul de permutation
                    int total = tot("nombre d'éléments à gérer : ");
                    long resultat = perm(total);
                    Console.WriteLine(total + "! = " + resultat);
                }
                else
                {
                    //Calcul d'arrangement, à combiner ou non avec calcul de permutation si combinaison
                    int total = 0, sstotal = 0;
                    long resultat1 = arr(ref total, ref sstotal);
                    if (c == 2)
                    {
                        Console.WriteLine("A(" + total + "/" + sstotal + ") = " + resultat1);
                    }
                    else
                    {
                        long resultat2 = perm(sstotal);
                        Console.WriteLine("C(" + total + "/" + sstotal + ") = " + (resultat1 / resultat2));
                    }
                }
                c = reponse();
            }
            Console.ReadLine();
        }
    }
}
