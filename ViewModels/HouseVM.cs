using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Task2_restAPI.ViewModels
{
    public class HouseVM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Num { get; set; }

        public string Street { get; set; }

        public string Sity { get; set; }

        public string Country { get; set; }

        public string PostCode { get; set; }

        public FlatVM Flat { get; set; }
    }

    public class CreateHouseDTO
    {
        public int Num { get; set; }

        public string Street { get; set; }

        public string Sity { get; set; }

        public string Country { get; set; }

        public string PostCode { get; set; }
    }


}
