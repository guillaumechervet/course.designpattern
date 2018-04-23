namespace Start.OrientedObject.Domain
{
    public class LignePanier
    {
        public LignePanier(Article article, int number)
        {
            Article = article;
            Number = number;
        }

        public Article Article { get; set; }
        public int Number { get; set; }
    }
}