using System;

class Program
{
    static void Main(string[] args)
    {
        const int TAILLE_MAX = 5;
        string[] panier = new string[TAILLE_MAX];
        int nbFruits = 0;

        bool quitter = false;

        while (!quitter)
        {
            Console.WriteLine("\n=== Bienvenue dans mon panier de fruit ===");
            Console.WriteLine("1. Ajouter un fruit dans mon panier");
            Console.WriteLine("2. Retirer un fruit de mon panier");
            Console.WriteLine("3. Afficher mon panier");
            Console.WriteLine("4. Rechercher un fruit dans mon panier");
            Console.WriteLine("5. Quitter mon panier");
            Console.Write("Votre choix : ");

            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1": // Ajouter un fruit dans le panier
                    if (nbFruits >= TAILLE_MAX)
                    {
                        Console.WriteLine(" Panier plein, impossible d'ajouter.");
                    }
                    else
                    {
                        Console.Write("Entrez le nom du fruit à ajouter : ");
                        string fruit = Console.ReadLine();

                        // Vérification de doublon dans le panier
                        bool existe = false;
                        for (int i = 0; i < nbFruits; i++)
                        {
                            if (panier[i].Equals(fruit, StringComparison.OrdinalIgnoreCase))
                            {
                                existe = true;
                                break;
                            }
                        }

                        if (existe)
                        {
                            Console.WriteLine(" Ce fruit est déjà dans le panier.");
                        }
                        else
                        {
                            panier[nbFruits] = fruit;
                            nbFruits++;
                            Console.WriteLine($" {fruit} ajouté au panier !");
                        }
                    }
                    break;

                case "2": // Retirer un fruit
                    Console.Write("Entrez le fruit à retirer : ");
                    string fruitARetirer = Console.ReadLine();
                    bool retire = false;

                    for (int i = 0; i < nbFruits; i++)
                    {
                        if (panier[i].Equals(fruitARetirer, StringComparison.OrdinalIgnoreCase))
                        {
                            // Décalage des éléments quand un fruit est retiré
                            for (int j = i; j < nbFruits - 1; j++)
                            {
                                panier[j] = panier[j + 1];
                            }
                            panier[nbFruits - 1] = null;
                            nbFruits--;
                            retire = true;
                            Console.WriteLine($"✅ {fruitARetirer} retiré du panier !");
                            break;
                        }
                    }

                    if (!retire)
                    {
                        Console.WriteLine(" Fruit introuvable dans le panier.");
                    }
                    break;

                case "3": // Afficher le contenue du panier
                    Console.WriteLine(" Contenu du panier :");
                    if (nbFruits == 0)
                        Console.WriteLine("   (vide)");
                    else
                        for (int i = 0; i < nbFruits; i++)
                            Console.WriteLine($"- {panier[i]}");
                    break;

                case "4": // Rechercher de fruit ou legume dans le panier
                    Console.Write("Entrez le fruit à rechercher : ");
                    string fruitRecherche = Console.ReadLine();
                    bool trouve = false;

                    for (int i = 0; i < nbFruits; i++)
                    {
                        if (panier[i].Equals(fruitRecherche, StringComparison.OrdinalIgnoreCase))
                        {
                            trouve = true;
                            break;
                        }
                    }

                    if (trouve)
                        Console.WriteLine($" {fruitRecherche} est bien dans le panier !");
                    else
                        Console.WriteLine($" {fruitRecherche} n'est pas dans le panier.");
                    break;

                case "5": // choix 5 pour Quitter l'application
                    quitter = true;
                    Console.WriteLine(" Merci d'avoir joué !");
                    break;

                default:
                    Console.WriteLine(" Choix invalide, veuillez réessayer.");
                    break;
            }
        }
    }
}
