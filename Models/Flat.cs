using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Task2_restAPI.Models
{
    public class Flat
    {
        public int Id { get; set; }

        public int Num { get; set; }

        public int Floor { get; set; }

        public int RoomsCount { get; set; }

        public int TenantsCount { get; set; }

        public float TotalArea { get; set; }

        public float LivingArea { get; set; }

        public int HouseId { get; set;  } 
        public House House { get; set;  }

        public List<Tenant> Tenants { get; set; }

        public Flat() { }

    }
}
