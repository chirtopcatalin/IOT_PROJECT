using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace garbage_collection.Models
{
    [Table("bin")]
    public class BinModel
    {
        public int Id { get; set; }
        public int CitizenId { get; set; }
        public string Location { get; set; }
    }
}
