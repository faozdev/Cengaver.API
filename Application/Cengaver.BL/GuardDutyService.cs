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
using Cengaver.Persistence;

namespace Cengaver.BL
{
    public class GuardDutyService : IGuardDutyService
    {
        private readonly DataContext _context;

        public GuardDutyService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<GuardDutyDto>> GetGuardDutiesAsync()
        {
            var guardDuties = await _context.GuardDuties
                .Include(gd => gd.WardenUser)
                .Include(gd => gd.GuardDutyNotes)
                .ToListAsync();

            // Map to DTOs
            return guardDuties.Select(gd => new GuardDutyDto
            {
                Id = gd.Id,
                StartDate = gd.StartDate,
                EndDate = gd.EndDate,
                WardenUserId = gd.WardenUserId,
                DateOfAssignment = gd.DateOfAssignment,
                GuardAssignedByUser = gd.GuardAssignedByUser,
                // Map related entities if needed
                // Example: WardenUser = gd.WardenUser?.Name,
                //          GuardDutyNotes = gd.GuardDutyNotes?.Select(note => note.Content).ToList()
            }).ToList();
        }

        public async Task<GuardDutyDto> GetGuardDutyByIdAsync(int id)
        {
            var guardDuty = await _context.GuardDuties
                .Include(gd => gd.WardenUser)
                .Include(gd => gd.GuardDutyNotes)
                .FirstOrDefaultAsync(gd => gd.Id == id);

            if (guardDuty == null)
                return null;

            // Map to DTO
            return new GuardDutyDto
            {
                Id = guardDuty.Id,
                StartDate = guardDuty.StartDate,
                EndDate = guardDuty.EndDate,
                WardenUserId = guardDuty.WardenUserId,
                DateOfAssignment = guardDuty.DateOfAssignment,
                GuardAssignedByUser = guardDuty.GuardAssignedByUser,
                // Map related entities if needed
                // Example: WardenUser = guardDuty.WardenUser?.Name,
                //          GuardDutyNotes = guardDuty.GuardDutyNotes?.Select(note => note.Content).ToList()
            };
        }
        /*
        public async Task<GuardDutyDto> AddGuardDutyAsync(GuardDutyDto guardDutyDto)
        {
            var guardDuty = new GuardDuty
            {
                StartDate = guardDutyDto.StartDate,
                EndDate = guardDutyDto.EndDate,
                WardenUserId = guardDutyDto.WardenUserId,
                DateOfAssignment = guardDutyDto.DateOfAssignment,
                GuardAssignedByUser = guardDutyDto.GuardAssignedByUser
            };

            _context.GuardDuties.Add(guardDuty);
            await _context.SaveChangesAsync();

            // Map to DTO
            return new GuardDutyDto
            {
                Id = guardDuty.Id,
                StartDate = guardDuty.StartDate,
                EndDate = guardDuty.EndDate,
                WardenUserId = guardDuty.WardenUserId,
                DateOfAssignment = guardDuty.DateOfAssignment,
                GuardAssignedByUser = guardDuty.GuardAssignedByUser
            };
        }
        */

        public async Task<GuardDutyDto> UpdateGuardDutyAsync(int id, GuardDutyDto guardDutyDto)
        {
            var guardDuty = await _context.GuardDuties.FindAsync(id);

            if (guardDuty == null)
                return null;

            // Update properties
            guardDuty.StartDate = guardDutyDto.StartDate;
            guardDuty.EndDate = guardDutyDto.EndDate;
            guardDuty.WardenUserId = guardDutyDto.WardenUserId;
            guardDuty.DateOfAssignment = guardDutyDto.DateOfAssignment;
            guardDuty.GuardAssignedByUser = guardDutyDto.GuardAssignedByUser;

            _context.GuardDuties.Update(guardDuty);
            await _context.SaveChangesAsync();

            // Map to DTO
            return new GuardDutyDto
            {
                Id = guardDuty.Id,
                StartDate = guardDuty.StartDate,
                EndDate = guardDuty.EndDate,
                WardenUserId = guardDuty.WardenUserId,
                DateOfAssignment = guardDuty.DateOfAssignment,
                GuardAssignedByUser = guardDuty.GuardAssignedByUser
            };
        }

        public async Task<bool> DeleteGuardDutyAsync(int id)
        {
            var guardDuty = await _context.GuardDuties.FindAsync(id);

            if (guardDuty == null)
                return false;

            _context.GuardDuties.Remove(guardDuty);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<GuardDutyDto>> GetGuardDutiesByWardenUserIdAsync(string wardenUserId)
        {
            var guardDuties = await _context.GuardDuties
                .Where(gd => gd.WardenUserId == wardenUserId)
                .Include(gd => gd.WardenUser)
                .Include(gd => gd.GuardDutyNotes)
                .ToListAsync();

            // Map to DTOs
            return guardDuties.Select(gd => new GuardDutyDto
            {
                Id = gd.Id,
                StartDate = gd.StartDate,
                EndDate = gd.EndDate,
                WardenUserId = gd.WardenUserId,
                DateOfAssignment = gd.DateOfAssignment,
                GuardAssignedByUser = gd.GuardAssignedByUser,
                // Map related entities if needed
                // Example: WardenUser = gd.WardenUser?.Name,
                //          GuardDutyNotes = gd.GuardDutyNotes?.Select(note => note.Content).ToList()
            }).ToList();
        }

        public async Task<GuardDutyDto> AddGuardDutyAsync(GuardDutyDto guardDutyDto)
        {
            // Create a new GuardDuty entity from the provided DTO
            var guardDuty = new GuardDuty
            {
                StartDate = guardDutyDto.StartDate,
                EndDate = guardDutyDto.EndDate,
                WardenUserId = guardDutyDto.WardenUserId,
                DateOfAssignment = guardDutyDto.DateOfAssignment,
                GuardAssignedByUser = guardDutyDto.GuardAssignedByUser
            };

            // Add the new entity to the context
            _context.GuardDuties.Add(guardDuty);

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Map the created entity back to a DTO
            return new GuardDutyDto
            {
                Id = guardDuty.Id,
                StartDate = guardDuty.StartDate,
                EndDate = guardDuty.EndDate,
                WardenUserId = guardDuty.WardenUserId,
                DateOfAssignment = guardDuty.DateOfAssignment,
                GuardAssignedByUser = guardDuty.GuardAssignedByUser
            };
        }



    }


}
