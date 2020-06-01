using PhoneBook.DAL.Repository.Interface;
using PhoneBook.Models.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace PhoneBook.DAL.Repository
{
    public class PhoneBookRepository : IPhoneBookRepository
    {
        readonly string FilePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "PhoneBook.DAL", "Files");
        readonly string _file;

        public PhoneBookRepository()
        {
            _file = Path.Combine(FilePath, "PhoneBook.json");
        }

        public Phone AddNumber(Phone phoneBook)
        {
            //Get phones
            var phoneJson = File.ReadAllText(_file);
            var phones = Newtonsoft.Json.JsonConvert
                                        .DeserializeObject<List<Phone>>(phoneJson)
                                        .Where(p=>!p.Deleted)
                                        .ToList();
            //increment the id by one 
            var phoneId = phones.Count() + 1;

            // Execute command
            phones.Add(new Phone
            {
                Id = phoneId,
                Name = phoneBook.Name,
                Surname = phoneBook.Surname,
                PhoneType = phoneBook.PhoneType,
                PhoneNumber = phoneBook.PhoneNumber
            });

            // Save 
            string newUser = Newtonsoft.Json.JsonConvert.SerializeObject(phones, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(_file, newUser);

            // Get Updated user and his phone number
            return GetPhoneNumber(phoneId);
        }

        public bool DeleteNumber(int id)
        {
            //get phone book
            var phoneJson = File.ReadAllText(_file);
            var phone = Newtonsoft.Json.JsonConvert
                                       .DeserializeObject<List<Phone>>(phoneJson)
                                       .ToList();

            //remove : change the state to true
            phone.Where(p => p.Id == id)
                  .ToList()
                  .ForEach(p =>
                  {
                      p.Deleted = true;
                  });
          

            string deletedPhone = Newtonsoft.Json.JsonConvert.SerializeObject(phone, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(_file, deletedPhone);

            return true;
        }

        public IEnumerable<Phone> GetAllPhoneNumbers()
        {
            var phoneJson = File.ReadAllText(_file);
            var phones = Newtonsoft.Json.JsonConvert
                                     .DeserializeObject<List<Phone>>(phoneJson)
                                     .Where(p => !p.Deleted)
                                     .ToList();

            return  phones;
        }

        public Phone GetPhoneNumber(int id)
        {
            var phoneJson = File.ReadAllText(_file);
            var phone =  Newtonsoft.Json.JsonConvert
                                     .DeserializeObject<List<Phone>>(phoneJson)
                                     .Where(p => p.Id == id && !p.Deleted)
                                     .FirstOrDefault();

            return  phone;
        }

        public Phone UpdateNumber(Phone phoneBook)
        {
            // Get users
            var phoneJson = File.ReadAllText(_file);
            var phone = Newtonsoft.Json.JsonConvert
                                        .DeserializeObject<List<Phone>>(phoneJson)
                                        .ToList();

            // Update 
            phone.Where(p => p.Id == phoneBook.Id)
                  .ToList()
                  .ForEach(p =>
                  {
                      p.Name = phoneBook.Name;
                      p.Surname = phoneBook.Surname;
                      p.PhoneType = phoneBook.PhoneType;
                      p.PhoneNumber = phoneBook.PhoneNumber;

                  });
            

            // Save 
            string updatedPhone = Newtonsoft.Json.JsonConvert.SerializeObject(phone, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(_file, updatedPhone);
            
            // Get Updated user and phone
            return GetPhoneNumber(phoneBook.Id);
        }
    }
}
