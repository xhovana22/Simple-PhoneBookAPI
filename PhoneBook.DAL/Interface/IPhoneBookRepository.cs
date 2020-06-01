
using PhoneBook.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.DAL.Repository.Interface
{
    public interface IPhoneBookRepository
    {

        Phone GetPhoneNumber(int id);
        IEnumerable<Phone> GetAllPhoneNumbers();
        Phone AddNumber(Phone phoneBook);
        Phone UpdateNumber(Phone phoneBook);
        bool DeleteNumber(int id);
    }
}
