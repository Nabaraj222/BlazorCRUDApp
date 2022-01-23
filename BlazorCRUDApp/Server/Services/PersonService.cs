using BlazorCRUDApp.Server.Models;
using BlazorCRUDApp.Server.Repository;

namespace BlazorCRUDApp.Server.Services
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<Person> _person;
        public PersonService(IRepository<Person> person)
        {
            _person = person;
        }
        public async Task<Person> AddPerson(Person person)
        {
            return await _person.CreateAsync(person);
        }

        public async Task<bool> UpdatePerson(int id, Person person) 
        {
            var data = await _person.GetByIdAsync(id);

            if (data != null)
            {  
                data.FirstName = person.FirstName;
                data.LastName = person.LastName;
                data.Email = person.Email;
                data.MobileNo = person.MobileNo;

                await _person.UpdateAsync(data);
                return true;
            }
            else
                return false;
        }

        public async Task<bool> DeletePerson(int id)
        {
            await _person.DeleteAsync(id);
            return true;
        }

        public async Task<List<Person>> GetAllPersons()
        {
            return await _person.GetAllAsync();
        }

        public async Task<Person> GetPerson(int id)
        {
            return await _person.GetByIdAsync(id);
        }
    }
}
