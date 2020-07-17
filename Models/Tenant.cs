using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Task2_restAPI.Models
{
    public class Tenant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set;  }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PersonalCode { get; set; }

        public string DateOfBirst { get; set; }

        public string PhoneNumber { get; set; }

        public string EMail { get; set; }

        public int FlatId { get; set; }
        public Flat Flat { get; set; }

        public Tenant() { }

    }
}
