using Cengaver.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.Infrastructure.Repository
{
    public interface IGuardDutyNoteRepository
    {
        /// <summary>
        /// Retrieves all guard duty notes.
        /// </summary>
        /// <returns>A list of guard duty notes.</returns>
        Task<List<GuardDutyNote>> GetAllAsync();

        /// <summary>
        /// Retrieves a specific guard duty note by ID.
        /// </summary>
        /// <param name="id">The ID of the guard duty note.</param>
        /// <returns>The guard duty note with the specified ID, or null if not found.</returns>
        Task<GuardDutyNote> GetByIdAsync(int id);

        /// <summary>
        /// Retrieves guard duty notes by Guard Duty ID.
        /// </summary>
        /// <param name="guardDutyId">The Guard Duty ID to filter notes.</param>
        /// <returns>A list of guard duty notes associated with the given Guard Duty ID.</returns>
        Task<List<GuardDutyNote>> GetByGuardDutyIdAsync(int guardDutyId);

        /// <summary>
        /// Adds a new guard duty note.
        /// </summary>
        /// <param name="guardDutyNote">The guard duty note to add.</param>
        /// <returns>The added guard duty note.</returns>
        Task AddAsync(GuardDutyNote guardDutyNote);

        /// <summary>
        /// Updates an existing guard duty note.
        /// </summary>
        /// <param name="guardDutyNote">The guard duty note to update.</param>
        void Update(GuardDutyNote guardDutyNote);

        /// <summary>
        /// Deletes a guard duty note.
        /// </summary>
        /// <param name="guardDutyNote">The guard duty note to delete.</param>
        void Delete(GuardDutyNote guardDutyNote);

        /// <summary>
        /// Saves changes to the data store.
        /// </summary>
        /// <returns>The number of state entries written to the database.</returns>
        Task<int> SaveChangesAsync();
    }

}
