﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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
}
