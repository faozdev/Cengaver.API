using Cengaver.Domain;
using Cengaver.BL.Abstractions;
using Cengaver.Infrastructure.Extentions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Cengaver.Dto;
using Cengaver.Infrastructure.Repository;

namespace Cengaver.BL
{
    

    public class GuardDutyBreakService : IGuardDutyBreakService
    {
        private readonly IGuardDutyBreakRepository _guardDutyBreakRepository;
        private readonly IMapper _mapper; // AutoMapper or similar mapping tool

        public GuardDutyBreakService(IGuardDutyBreakRepository guardDutyBreakRepository, IMapper mapper)
        {
            _guardDutyBreakRepository = guardDutyBreakRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GuardDutyBreakDto>> GetGuardDutyBreaksAsync()
        {
            var breaks = await _guardDutyBreakRepository.GetAllAsync().ConfigureAwait(false);
            return _mapper.Map<IEnumerable<GuardDutyBreakDto>>(breaks);
        }

        public async Task<GuardDutyBreakDto> GetGuardDutyBreakByIdAsync(int id)
        {
            var guardDutyBreak = await _guardDutyBreakRepository.GetByIdAsync(id).ConfigureAwait(false);
            return guardDutyBreak == null ? null : _mapper.Map<GuardDutyBreakDto>(guardDutyBreak);
        }

        public async Task<List<GuardDutyBreakDto>> GetGuardDutyBreaksByUserIdAsync(string userId)
    {
        var guardDutyBreaks = await _guardDutyBreakRepository.GetByUserIdAsync(userId).ConfigureAwait(false);
        return _mapper.Map<List<GuardDutyBreakDto>>(guardDutyBreaks);
    }

        public async Task<GuardDutyBreakDto> AddGuardDutyBreakAsync(GuardDutyBreakDto guardDutyBreakDto)
        {
            var guardDutyBreak = _mapper.Map<GuardDutyBreak>(guardDutyBreakDto);
            await _guardDutyBreakRepository.AddAsync(guardDutyBreak).ConfigureAwait(false);
            return _mapper.Map<GuardDutyBreakDto>(guardDutyBreak);
        }

        public async Task<GuardDutyBreakDto> UpdateGuardDutyBreakAsync(int id, GuardDutyBreakDto guardDutyBreakDto)
        {
            var existingBreak = await _guardDutyBreakRepository.GetByIdAsync(id).ConfigureAwait(false);
            if (existingBreak == null)
            {
                return null; // Not found
            }

            _mapper.Map(guardDutyBreakDto, existingBreak);
            await _guardDutyBreakRepository.UpdateAsync(existingBreak).ConfigureAwait(false);
            return _mapper.Map<GuardDutyBreakDto>(existingBreak);
        }

        public async Task<bool> DeleteGuardDutyBreakAsync(int id)
        {
            var existingBreak = await _guardDutyBreakRepository.GetByIdAsync(id).ConfigureAwait(false);
            if (existingBreak == null)
            {
                return false; // Not found
            }

            await _guardDutyBreakRepository.DeleteAsync(id).ConfigureAwait(false);
            return true;
        }

    }



}
