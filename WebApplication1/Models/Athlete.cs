namespace WebApplication1.Models
{
    public class Athlete
    {
        public string Medal { get; set; }
        public string Name { get; set; }
        public string Sport { get; set; }
        public int PrizeMoney { get; set; }
    }

    public class Athelete02
    {
        public string Name { get; set; }
        public string Sport { get; set; }
        
    }

    public class Medal
    {
        public string Name { get; set; }
        public string Rank { get; set; }
        public int Money { get; set; }
        
    }
}
