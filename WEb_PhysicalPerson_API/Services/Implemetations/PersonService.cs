using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WEb_PhysicalPerson_API.Data;
using WEb_PhysicalPerson_API.DTOs;
using WEb_PhysicalPerson_API.DTOs.PersonDTO;
using WEb_PhysicalPerson_API.Models;
using WEb_PhysicalPerson_API.Services.Interfaces;

namespace WEb_PhysicalPerson_API.Services.Implemetations
{
    public class PersonService : IPersonService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public PersonService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _db = dbContext;
            _mapper = mapper;
        }

        public async Task<GetPersonDTO> AddPerson(AddPersonDTO newPerson)
        {
            try
            {
                var person = _mapper.Map<Person>(newPerson);
                await _db.Persons.AddAsync(person);
                await _db.SaveChangesAsync();

                // Retrieve the newly added person by their ID
                var addedPerson = await _db.Persons.FindAsync(person.Id);

                // Map the added person to GetPersonDTO
                var personDTO = _mapper.Map<GetPersonDTO>(addedPerson);
                return personDTO;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> DeletePerson(int personId)
        {
            try
            {
                var person = await _db.Persons.FindAsync(personId);

                if (person != null)
                {
                    _db.Persons.Remove(person);
                    await _db.SaveChangesAsync();

                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public async Task<List<GetPersonDTO>> GetAllPersons()
        {
            try
            {
                var persons = await _db.Persons.ToListAsync();
                var personsDTO = _mapper.Map<List<GetPersonDTO>>(persons);

                return personsDTO;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<GetPersonDTO> GetPersonById(int personId)
        {
            var response = await _db.Persons.FirstOrDefaultAsync();
            try
            {
                var person = await _db.Persons.FirstOrDefaultAsync(x =>x.Id == personId);
                if(person != null)
                {
                    var personDTO = _mapper.Map<GetPersonDTO>(person);
                    return personDTO;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<GetPersonDTO> UpdatePerson(int personId, UpdatePersonDTO updatedPerson)
        {
            try
            {
                var person = await _db.Persons.FirstOrDefaultAsync(x=>x.Id == personId);    
                if(person != null)
                {
                    _mapper.Map(updatedPerson, person);
                    await _db.SaveChangesAsync();
                    var UpdatedPersonDTO = _mapper.Map<GetPersonDTO>(person);
                    return UpdatedPersonDTO;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
