using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Task2_restAPI.Models;

namespace Task2_restAPI.ViewModels
{
    public class CreateTenantDTO
        {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PersonalCode { get; set; }

        public string DateOfBirst { get; set; }

        public string PhoneNumber { get; set; }

        public string EMail { get; set; }

        public int FlatId { get; set; }
    }

    public class TenantVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PersonalCode { get; set; }

        public string DateOfBirst { get; set; }

        public string PhoneNumber { get; set; }

        public string EMail { get; set; }

        public int FlatId { get; set; }
        // This field is needed on frontend to display on which flat user is in
        public int FlatNum { get; set; }
        // HouseId is needed on frontend in Tenant list
        // to gets back to Flats which depends on houseId
        public int HouseId { get; set; }  
        // This field is needed on frontend to display on which house user is in
        public int HouseNum { get; set; }
        // This field is needed on frontend to display on which street user is in
        public string HouseStreet { get; set; }
    }
}
