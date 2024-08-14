using Cengaver.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cengaver.BL.Abstractions
{
    using Cengaver.Dto;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGuardDutyBreakService
    {
        /// <summary>
        /// Gets all guard duty breaks.
        /// </summary>
        /// <returns>A list of guard duty breaks.</returns>
        Task<IEnumerable<GuardDutyBreakDto>> GetGuardDutyBreaksAsync();

        /// <summary>
        /// Gets a specific guard duty break by its ID.
        /// </summary>
        /// <param name="id">The ID of the guard duty break.</param>
        /// <returns>The guard duty break with the specified ID.</returns>
        Task<GuardDutyBreakDto> GetGuardDutyBreakByIdAsync(int id);

        /// <summary>
        /// Gets the list of guard duty breaks by Guard Duty ID.
        /// </summary>
        /// <param name="userId">The Guard Duty ID to filter breaks.</param>
        /// <returns>A list of guard duty breaks associated with the given Guard Duty ID.</returns>
        Task<List<GuardDutyBreakDto>> GetGuardDutyBreaksByUserIdAsync(string userId);

        /// <summary>
        /// Adds a new guard duty break.
        /// </summary>
        /// <param name="guardDutyBreakDto">The guard duty break details to add.</param>
        /// <returns>The added guard duty break.</returns>
        Task<GuardDutyBreakDto> AddGuardDutyBreakAsync(GuardDutyBreakDto guardDutyBreakDto);

        /// <summary>
        /// Updates an existing guard duty break.
        /// </summary>
        /// <param name="id">The ID of the guard duty break to update.</param>
        /// <param name="guardDutyBreakDto">The updated guard duty break details.</param>
        /// <returns>The updated guard duty break.</returns>
        Task<GuardDutyBreakDto> UpdateGuardDutyBreakAsync(int id, GuardDutyBreakDto guardDutyBreakDto);

        /// <summary>
        /// Deletes a specific guard duty break by its ID.
        /// </summary>
        /// <param name="id">The ID of the guard duty break to delete.</param>
        /// <returns>True if the deletion was successful, otherwise false.</returns>
        Task<bool> DeleteGuardDutyBreakAsync(int id);
    }


}
