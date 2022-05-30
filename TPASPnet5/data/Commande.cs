using System.ComponentModel.DataAnnotations;

namespace TPASPnet5.data
{
    public class Commande
    {
        [Key]
        public string IdCmd { get; set; }
        public string nomClient { get; set; }
        public string cEntree { get; set; }
        public string cPlat { get; set; }
        public string cDessert { get; set; }
        public string cBoisson { get; set; }
        public string cSituation { get; set; }
    }
}
