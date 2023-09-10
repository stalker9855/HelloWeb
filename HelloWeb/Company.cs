
namespace HelloWeb
{
    public class Company
    {
        public string cName {  get; set; }
        public string cDescription { get; set; }
        public string cPhone { get; set; }
        public string cEmail { get; set; }
        public int cWorkerks { get; set; }

        public int RandomNumber()
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(0, 101);
            return randomNumber;
        }

        public override string ToString()
        {
            return $"Name: {this.cName}\nDescription: {this.cDescription}\nPhone: {cPhone}\nEmail: {cEmail}\nAmount of workerks: {cWorkerks}";
        }
    }
}
