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
        /// Retrieves all guard duties.
        /// </summary>
        /// <returns>List of guard duties.</returns>
        Task<List<GuardDutyDto>> GetGuardDutiesAsync();

        /// <summary>
        /// Retrieves a specific guard duty by its ID.
        /// </summary>
        /// <param name="id">The ID of the guard duty.</param>
        /// <returns>The guard duty details.</returns>
        Task<GuardDutyDto> GetGuardDutyByIdAsync(int id);

        /// <summary>
        /// Adds a new guard duty.
        /// </summary>
        /// <param name="guardDutyDto">The details of the guard duty to add.</param>
        /// <returns>The added guard duty.</returns>
        //Task<GuardDutyDto> AddGuardDutyAsync(GuardDutyDto guardDutyDto);

        /// <summary>
        /// Updates an existing guard duty.
        /// </summary>
        /// <param name="id">The ID of the guard duty to update.</param>
        /// <param name="guardDutyDto">The updated guard duty details.</param>
        /// <returns>The updated guard duty.</returns>
        Task<GuardDutyDto> UpdateGuardDutyAsync(int id, GuardDutyDto guardDutyDto);

        /// <summary>
        /// Deletes a specific guard duty by its ID.
        /// </summary>
        /// <param name="id">The ID of the guard duty to delete.</param>
        /// <returns>Whether the delete operation was successful.</returns>
        Task<bool> DeleteGuardDutyAsync(int id);

        Task<List<GuardDutyDto>> GetGuardDutiesByWardenUserIdAsync(string wardenUserId);

        Task<GuardDutyDto> AddGuardDutyAsync(GuardDutyDto guardDutyDto);
    }


}
