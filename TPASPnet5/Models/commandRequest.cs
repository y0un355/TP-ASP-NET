namespace TPASPnet5.Models
{

    /*cette classe est similaire à ce qu'on a dans la DB 
    cad les meme attributs dans la classe commande dans la DB*/

    /*cette classe contient tous les attributs dont j'ai besoin 
    mais normalement je dois organiser des attribut sur des autres classe
    par exemple je dois avoir une classe boisson et dessert et plat et entree
    pour la gestion de stock....  et aussi client  mais pour l'instant je dois sute pratiquer le principe d'api*/

    public class commandRequest
    {
        public string IdCmd { get; set; }
        public string nomClient { get; set; }
        public string cEntree { get; set; }
        public string cPlat { get; set; }
        public string cDessert { get; set; }
        public string cBoisson { get; set; }
        public string cSituation { get; set; }

    }
}
