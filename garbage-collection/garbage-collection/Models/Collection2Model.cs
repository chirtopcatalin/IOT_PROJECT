using System.ComponentModel.DataAnnotations.Schema;

namespace garbage_collection.Models
{
    [Table("collections2")]
    public class Collection2Model
    {
        public int Id { get; set; }
        public string NrMasina { get; set; }
        public string IdPubela { get; set; }
        public DateTime? ColectatLa { get; set; }
        public string Adresa { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
