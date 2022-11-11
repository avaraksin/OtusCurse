
namespace Lesson4
{
    public class Clients
    {
        public int id { get; set; }
        public string firstName { get; set; } = String.Empty;

        public Clients(int id, string firstName)
        {
            this.id = id;
            this.firstName = firstName;
        }
    }
}
