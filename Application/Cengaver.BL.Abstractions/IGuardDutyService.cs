using Cengaver.Domain;
using Cengaver.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.BL.Abstractions
{
    public interface IGuardDutyService
    {
        /// <summary>
        /// Gets the list of all guard duties.
        /// </summary>
        /// <returns>List of guard duties.</returns>
        Task<List<GuardDutyDto>> GetGuardDutiesAsync();

        /// <summary>
        /// Gets a specific guard duty by ID.
        /// </summary>
        /// <param name="id">The ID of the guard duty.</param>
        /// <returns>Details of the specified guard duty.</returns>
        Task<GuardDutyDto> GetGuardDutyByIdAsync(int id);

        /// <summary>
        /// Adds a new guard duty.
        /// </summary>
        /// <param name="guardDutyDto">The guard duty details to add.</param>
        /// <returns>Result of the add operation.</returns>
        Task<GuardDutyDto> AddGuardDutyAsync(GuardDutyCreateDto guardDutyDto);

        /// <summary>
        /// Updates an existing guard duty.
        /// </summary>
        /// <param name="id">The ID of the guard duty to update.</param>
        /// <param name="guardDutyDto">The updated guard duty details.</param>  
        /// <returns>Result of the update operation.</returns>
        Task<GuardDutyDto> UpdateGuardDutyAsync(int id, GuardDutyDto guardDutyDto);

        /// <summary>
        /// Deletes a specific guard duty by ID.
        /// </summary>
        /// <param name="id">The ID of the guard duty to delete.</param>
        /// <returns>Result of the delete operation.</returns>
        Task<bool> DeleteGuardDutyAsync(int id);
    }

}
