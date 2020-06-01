using AutoMapper;
using Moq;
using NUnit.Framework;
using PhoneBook.DAL.Repository.Interface;
using PhoneBook.Models.Models;
using PhoneBook.SL.DTO;
using PhoneBook.SL.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.UnitTest
{
    [TestFixture]
    class PhoneBookServiceShould
    {
        private List<PhoneDTO> _list;

        [SetUp]
        public void Setup() => _list = new List<PhoneDTO> {

            new PhoneDTO
            {
                Id = 5,
                Name = It.IsAny<string>(),
                Surname= It.IsAny<string>(),
                PhoneType = It.IsAny<string>(),
                PhoneNumber = It.IsAny<string>()
            },
            new PhoneDTO
            {
                Id = 6,
                Name = It.IsAny<string>(),
                Surname= It.IsAny<string>(),
                PhoneType = It.IsAny<string>(),
                PhoneNumber = It.IsAny<string>()
            } };

        [Test]
        public void ReturnTheListOfPhoneBooks()
        {
        
        }

        [Test]
        public void AddPhoneBookToList()
        {
          
        }

    
        [Test]
        public void RemovesPhoneBook()
        {
        }
    }
}
