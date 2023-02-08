using System.ComponentModel.DataAnnotations.Schema;

namespace Otus.Teaching.Concurrency.Import.Handler.Entities
{
    public class ThreadCustomer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}