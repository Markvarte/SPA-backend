using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Task2_restAPI.ViewModels
{
    public class CreateHouseDTO
    {
        public int Num { get; set; }

        public string Street { get; set; }

        public string Sity { get; set; }

        public string Country { get; set; }

        public string PostCode { get; set; }
    }


}
