using Cengaver.Domain;
using Cengaver.BL.Abstractions;
using System;
using Cengaver.Infrastructure.Extentions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Cengaver.Dto;
using Cengaver.Infrastructure.Repository;

namespace Cengaver.BL
{
    public class GuardDutyNoteService : IGuardDutyNoteService
    {
        private readonly IGuardDutyNoteRepository _guardDutyNoteRepository;
        private readonly IMapper _mapper;

        public GuardDutyNoteService(IGuardDutyNoteRepository guardDutyNoteRepository, IMapper mapper)
        {
            _guardDutyNoteRepository = guardDutyNoteRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all guard duty notes.
        /// </summary>
        /// <returns>A list of guard duty notes.</returns>
        public async Task<List<GuardDutyNoteDto>> GetGuardDutyNotesAsync()
        {
            var notes = await _guardDutyNoteRepository.GetAllAsync().ConfigureAwait(false);
            return _mapper.Map<List<GuardDutyNoteDto>>(notes);
        }

        /// <summary>
        /// Retrieves a specific guard duty note by ID.
        /// </summary>
        /// <param name="id">The ID of the guard duty note.</param>
        /// <returns>The guard duty note with the specified ID.</returns>
        public async Task<GuardDutyNoteDto> GetGuardDutyNoteByIdAsync(int id)
        {
            var note = await _guardDutyNoteRepository.GetByIdAsync(id).ConfigureAwait(false);
            return _mapper.Map<GuardDutyNoteDto>(note);
        }

        /// <summary>
        /// Retrieves guard duty notes by Guard Duty ID.
        /// </summary>
        /// <param name="guardDutyId">The Guard Duty ID to filter notes.</param>
        /// <returns>A list of guard duty notes associated with the given Guard Duty ID.</returns>
        public async Task<List<GuardDutyNoteDto>> GetGuardDutyNotesByGuardDutyIdAsync(int guardDutyId)
        {
            var notes = await _guardDutyNoteRepository.GetByGuardDutyIdAsync(guardDutyId).ConfigureAwait(false);
            return _mapper.Map<List<GuardDutyNoteDto>>(notes);
        }

        /// <summary>
        /// Adds a new guard duty note.
        /// </summary>
        /// <param name="guardDutyNoteDto">The guard duty note details to add.</param>
        /// <returns>The result of the add operation.</returns>
        public async Task<GuardDutyNoteDto> AddGuardDutyNoteAsync(GuardDutyNoteDto guardDutyNoteDto)
        {
            var note = _mapper.Map<GuardDutyNote>(guardDutyNoteDto);
            await _guardDutyNoteRepository.AddAsync(note).ConfigureAwait(false);
            await _guardDutyNoteRepository.SaveChangesAsync().ConfigureAwait(false);
            return _mapper.Map<GuardDutyNoteDto>(note);
        }

        /// <summary>
        /// Updates an existing guard duty note.
        /// </summary>
        /// <param name="id">The ID of the guard duty note to update.</param>
        /// <param name="guardDutyNoteDto">The updated guard duty note details.</param>
        /// <returns>The result of the update operation.</returns>
        public async Task<GuardDutyNoteDto> UpdateGuardDutyNoteAsync(int id, GuardDutyNoteDto guardDutyNoteDto)
        {
            var existingNote = await _guardDutyNoteRepository.GetByIdAsync(id).ConfigureAwait(false);
            if (existingNote == null)
            {
                return null; // or throw an exception if preferred
            }

            _mapper.Map(guardDutyNoteDto, existingNote);
            _guardDutyNoteRepository.Update(existingNote);
            await _guardDutyNoteRepository.SaveChangesAsync().ConfigureAwait(false);
            return _mapper.Map<GuardDutyNoteDto>(existingNote);
        }

        /// <summary>
        /// Deletes a guard duty note by ID.
        /// </summary>
        /// <param name="id">The ID of the guard duty note to delete.</param>
        /// <returns>True if the deletion was successful, otherwise false.</returns>
        public async Task<bool> DeleteGuardDutyNoteAsync(int id)
        {
            var note = await _guardDutyNoteRepository.GetByIdAsync(id).ConfigureAwait(false);
            if (note == null)
            {
                return false;
            }

            _guardDutyNoteRepository.Delete(note);
            await _guardDutyNoteRepository.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }
    }


}
