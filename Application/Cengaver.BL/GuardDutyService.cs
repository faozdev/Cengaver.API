using Cengaver.Domain;
using Cengaver.BL.Abstractions;
using Cengaver.Infrastructure.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Cengaver.Dto;

namespace Cengaver.BL
{
    public class GuardDutyService : IGuardDutyService
    {
        private readonly IGenericRepository<GuardDuty> _repository;
        private readonly IMapper _mapper;

        public GuardDutyService(IGenericRepository<GuardDuty> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GuardDutyDto>> GetGuardDutiesAsync()
        {
            var guardDuties = await _repository.GetAllAsync();
            return _mapper.Map<List<GuardDutyDto>>(guardDuties);
        }

        public async Task<GuardDutyDto> GetGuardDutyByIdAsync(int id)
        {
            var guardDuty = await _repository.GetByIdAsync(id);
            if (guardDuty == null)
            {
                return null;
            }
            return _mapper.Map<GuardDutyDto>(guardDuty);
        }

        public async Task<GuardDutyDto> AddGuardDutyAsync(GuardDutyCreateDto guardDutyCreateDto)
        {
            var guardDuty = _mapper.Map<GuardDuty>(guardDutyCreateDto);
            await _repository.AddAsync(guardDuty);
            var createdGuardDuty = await _repository.GetByIdAsync(guardDuty.Id);
            return _mapper.Map<GuardDutyDto>(createdGuardDuty);
        }

        public async Task<GuardDutyDto> UpdateGuardDutyAsync(int id, GuardDutyDto guardDutyDto)
        {
            var existingGuardDuty = await _repository.GetByIdAsync(id);
            if (existingGuardDuty == null)
            {
                return null;
            }

            _mapper.Map(guardDutyDto, existingGuardDuty);
            await _repository.UpdateAsync(existingGuardDuty);
            return _mapper.Map<GuardDutyDto>(existingGuardDuty);
        }

        public async Task<bool> DeleteGuardDutyAsync(int id)
        {
            var guardDuty = await _repository.GetByIdAsync(id);
            if (guardDuty == null)
            {
                return false;
            }

            await _repository.DeleteAsync(id);
            return true;
        }
    }

}
