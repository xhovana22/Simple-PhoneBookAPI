using PhoneBook.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhoneBook.SL.DTO
{
    public class PhoneDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneType { get; set; }

        public bool Deleted { get; set; }

        public string PhoneNumber { get; set; }

    }
}
