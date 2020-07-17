using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task2_restAPI.Models
{
    public class House
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Num { get; set; }

        public string Street { get; set; }

        public string Sity { get; set; }

        public string Country { get; set; }

        public string PostCode { get; set; }

        public List<Flat> Flats { get; set; } // connected flats

        public House()
        {
        }
    }
}