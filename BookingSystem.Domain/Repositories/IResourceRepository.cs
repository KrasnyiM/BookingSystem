using BookingSystem.Domain.Enums;
using BookingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystem.Domain.Repositories
{
    public interface IResourceRepository
    {
        Task<Resource?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<Resource>> GetAllActiveAsync(CancellationToken cancellationToken = default);
        Task AddAsync(Resource resource, CancellationToken cancellationToken = default);
    }
}
