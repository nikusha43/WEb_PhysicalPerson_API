using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WEb_PhysicalPerson_API.Data;
using WEb_PhysicalPerson_API.DTOs.ConnectedPersonDTO;
using WEb_PhysicalPerson_API.Models;
using WEb_PhysicalPerson_API.Services.Interfaces;

namespace WEb_PhysicalPerson_API.Services.Implemetations
{
    public class PersonConnectionService : IPersonConnectionService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public PersonConnectionService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _db = dbContext;
            _mapper = mapper;
        }
        public async Task<bool> AddPersonConnection(ConnectedPersonDTO connectionDTO)
        {
            try
            {
                var Connperson = _mapper.Map<ConnectedPerson>(connectionDTO);

                // vamowmeb null xomaraa romelime 
                if (Connperson == null || Connperson.PersonId == null || Connperson.connectionPersonId == null)
                {

                    return false;
                }

                var person = await _db.Persons
                                     .Include(p => p.RelatedPersons)
                                     .FirstOrDefaultAsync(p => p.Id == connectionDTO.personId);
                var connectedPerson = await _db.Persons.FirstOrDefaultAsync(p => p.Id == connectionDTO.connectionPersonId);

                // tu person an connectedperson ar aris null 

                if (person != null && connectedPerson != null)
                {
                    //aris tu ara mat shoris kavshiri 
                    bool connectionExists = person.RelatedPersons.Any(p => p.connectionPersonId == connectedPerson.Id);

                    if (!connectionExists)
                    {
                        // daamatos connection
                        person.RelatedPersons.Add(new ConnectedPerson
                        {
                            ConnectionType = connectionDTO.ConnectionType,
                            PersonId = connectedPerson.Id,
                            connectionPersonId = connectionDTO.connectionPersonId
                        });

                        await _db.SaveChangesAsync();

                        return true;
                    }
                    else
                    {
                       
                        return false;
                    }
                }
                else
                {

                    return false;
                }

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<bool> DeletePersonConnection(int personId, int connectionPersonId)
        {
            try
            {
                var person = await _db.Persons
                    .Include(p => p.RelatedPersons)
                    .FirstOrDefaultAsync(p => p.Id == personId);

                if (person != null)
                {
                    var connectionToRemove = person.RelatedPersons.FirstOrDefault(p => p.connectionPersonId == connectionPersonId);

                    if (connectionToRemove != null)
                    {
                        person.RelatedPersons.Remove(connectionToRemove);
                        await _db.SaveChangesAsync();
                        return true;
                    }
                }

                return false; 
            }
            catch (Exception ex)
            {
              
                return false;
            }
        }

        public async Task<List<ConnectedPersonDTO>> GetAllPersonConnections()
        {
            try
            {
                var ConnPersons = await _db.ConnectedPersons.ToListAsync();

                var ConPersonDTO = _mapper.Map<List<ConnectedPersonDTO>>(ConnPersons);

                return ConPersonDTO;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

