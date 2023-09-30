namespace HelloWeb
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} Name: {Name} Author: {Author} Year: {Year}\n";
        }
    }
}