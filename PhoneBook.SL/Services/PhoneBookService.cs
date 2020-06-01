using AutoMapper;
using PhoneBook.DAL.Repository.Interface;
using PhoneBook.SL.DTO;
using PhoneBook.SL.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PhoneBook.Models.Models;
using System.Web.Http.ModelBinding;

namespace PhoneBook.SL.Services
{
    public class PhoneBookService : IPhoneBookService
    {
        //dependency injection
        private readonly IPhoneBookRepository _repository;
        private readonly IMapper _mapper;


        public PhoneBookService(IPhoneBookRepository repository, IMapper mapper)
        {
            _repository = repository; //constructor depend injection
            _mapper = mapper;
        }

  

        public bool Delete(int id)
        {
            bool deleted = _repository.DeleteNumber(id);

            return deleted;
        }


        public IEnumerable<PhoneDTO> GetAllOrdered(bool orderByName, bool asc)
        {
            //get phones and users
            var phones = _repository.GetAllPhoneNumbers();

            IEnumerable<Phone> result = null;

            if (!asc)
            {
                if (!orderByName)
                {
                    result = phones.OrderByDescending(x => x.Surname);
                }
                else
                {
                    result = phones.OrderByDescending(x => x.Name);
                }
            }
            else
            {
                if (!orderByName)
                {
                    result = phones.OrderBy(x => x.Surname);
                }
                else
                {
                    result = phones.OrderBy(x => x.Name);
                }
            }

            // convert it into dto 
            var phonesDto = _mapper.Map<IEnumerable<PhoneDTO>>(result);

            return phonesDto;
        }
          

       public PhoneDTO Post(PhoneDTO phoneBook)
        {
            var  phone= _mapper.Map<Phone>(phoneBook);
           
            _repository.AddNumber(phone);

            return _mapper.Map<PhoneDTO>(phone);

            
        }

       public PhoneDTO Put(PhoneDTO phoneBook)
        {
            var phone = _mapper.Map<Phone>(phoneBook);

            var updatedUser = _repository.UpdateNumber(phone);

            return _mapper.Map<PhoneDTO>(updatedUser);
        }
    }
}
