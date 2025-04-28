using System.ComponentModel.DataAnnotations.Schema;

namespace garbage_collection.Models
{
    [Table("collections")]
    public class CollectionModel
    {
        public int Id { get; set; }
        public int Bin_id { get; set; }
        public DateTime Collection_time { get; set; }
    }
}