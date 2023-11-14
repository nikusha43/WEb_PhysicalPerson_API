using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using WEb_PhysicalPerson_API.Data;
using WEb_PhysicalPerson_API.DTOs;
using WEb_PhysicalPerson_API.DTOs.PhoneNumberDTO;
using WEb_PhysicalPerson_API.Models;
using WEb_PhysicalPerson_API.Services.Interfaces;

namespace WEb_PhysicalPerson_API.Services.Implemetations
{
    public class PhoneNumberService : IPhoneService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public PhoneNumberService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _db = dbContext;
            _mapper = mapper;
        }

        public async Task<GetPhoneDTO> AddPhoneNumber(AddPhoneDTO Newphone, int personId)
        {
            try
            {
                var phone = _mapper.Map<Phone>(Newphone);
                phone.PersonId = personId;
                await _db.Phones.AddAsync(phone);
                await _db.SaveChangesAsync();

                var addedphone = await _db.Phones.FindAsync(phone.Id);

                var phoneDTO = _mapper.Map<GetPhoneDTO>(addedphone);
                return phoneDTO;
            }
            catch (Exception ex)
            {
               
                throw;
            }
        }


        public async Task<bool> DeletePhoneNumber(int phoneId)
        {
            try
            {
                var phone =await _db.Phones.FindAsync(phoneId);
                if (phone != null)
                {
                    _db.Phones.Remove(phone);
                    await _db.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<GetPhoneDTO>> GetAllPhones()
        {
            try
            {
                var phones = await _db.Phones.ToListAsync();
                var phonedto = _mapper.Map<List<GetPhoneDTO>>(phones);

                return phonedto;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<GetPhoneDTO> GetPhoneByPersonId(int personId)
        {
            try
            {
               
                var phone = await _db.Phones.FirstOrDefaultAsync(x => x.PersonId == personId);
                if (phone != null)
                {
                    var phoneDto = _mapper.Map<GetPhoneDTO>(phone);
                    return phoneDto;
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


        public async Task<GetPhoneDTO> UpdatePhoneNumber(int phoneId, UpdatePhoneDTO Updatedphone)
        {
            try
            {
                var phone = await _db.Phones.FirstOrDefaultAsync(x => x.Id == phoneId);
                if (phone != null)
                {
                    _mapper.Map(Updatedphone, phone);
                    await _db.SaveChangesAsync();
                    var updatedPhoneDTO = _mapper.Map<GetPhoneDTO>(phone);
                    return updatedPhoneDTO;
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
