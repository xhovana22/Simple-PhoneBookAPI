using AutoMapper;
using PhoneBook.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.SL.DTO.Mappings
{
   public class Mappings: Profile
    {
        public Mappings()
        {
            CreateMap<Phone, PhoneDTO>().ReverseMap();   //bidirectional mapping
        }
    }
}
