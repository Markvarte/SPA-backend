using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Task2_restAPI.ViewModels
{
    public class FlatVM
    {

    }
    public class CreateFlatDTO
    {
        public int Num { get; set; }

        public int Floor { get; set; }

        public int RoomsCount { get; set; }

        public int TenantsCount { get; set; }

        public float TotalArea { get; set; }

        public float LivingArea { get; set; }

        public int HouseId { get; set; }
    }
}
