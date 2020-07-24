using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Task2_restAPI.Models;

namespace Task2_restAPI.ViewModels
{
    public class FlatVM
    {
        public int Id { get; set; }

        public int Num { get; set; }

        public int Floor { get; set; }

        public int RoomsCount { get; set; }

        public int TenantsCount { get; set; }

        public float TotalArea { get; set; }

        public float LivingArea { get; set; }

        public int HouseId { get; set; }
        public House House { get; set; }

        // This field is needed on frontend to display on which house user is in
        public int HouseNum { get; set; }
        // This field is needed on frontend to display on which street user is in
        public string HouseStreet { get; set; }
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
