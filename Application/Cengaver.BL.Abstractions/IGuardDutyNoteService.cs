using Cengaver.Domain;
using Cengaver.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.BL.Abstractions
{
    public interface IGuardDutyNoteService
    {
        /// <summary>
        /// Retrieves all guard duty notes.
        /// </summary>
        /// <returns>A list of guard duty notes.</returns>
        Task<List<GuardDutyNoteDto>> GetGuardDutyNotesAsync();

        /// <summary>
        /// Retrieves a specific guard duty note by ID.
        /// </summary>
        /// <param name="id">The ID of the guard duty note.</param>
        /// <returns>The guard duty note with the specified ID.</returns>
        Task<GuardDutyNoteDto> GetGuardDutyNoteByIdAsync(int id);

        /// <summary>
        /// Retrieves guard duty notes by Guard Duty ID.
        /// </summary>
        /// <param name="guardDutyId">The Guard Duty ID to filter notes.</param>
        /// <returns>A list of guard duty notes associated with the given Guard Duty ID.</returns>
        Task<List<GuardDutyNoteDto>> GetGuardDutyNotesByGuardDutyIdAsync(int guardDutyId);

        /// <summary>
        /// Adds a new guard duty note.
        /// </summary>
        /// <param name="guardDutyNoteDto">The guard duty note details to add.</param>
        /// <returns>The result of the add operation.</returns>
        Task<GuardDutyNoteDto> AddGuardDutyNoteAsync(GuardDutyNoteDto guardDutyNoteDto);

        /// <summary>
        /// Updates an existing guard duty note.
        /// </summary>
        /// <param name="id">The ID of the guard duty note to update.</param>
        /// <param name="guardDutyNoteDto">The updated guard duty note details.</param>
        /// <returns>The result of the update operation.</returns>
        Task<GuardDutyNoteDto> UpdateGuardDutyNoteAsync(int id, GuardDutyNoteDto guardDutyNoteDto);

        /// <summary>
        /// Deletes a guard duty note by ID.
        /// </summary>
        /// <param name="id">The ID of the guard duty note to delete.</param>
        /// <returns>True if the deletion was successful, otherwise false.</returns>
        Task<bool> DeleteGuardDutyNoteAsync(int id);
    }

}
