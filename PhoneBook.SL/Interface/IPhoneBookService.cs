using PhoneBook.SL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.SL.Interface
{
   public  interface IPhoneBookService
    {
        IEnumerable<PhoneDTO> GetAllOrdered(bool orderByName, bool asc);

        PhoneDTO Post(PhoneDTO phoneBook);

        PhoneDTO Put(PhoneDTO phoneBook);

        bool Delete(int id);

    
    }
}
