using BookingSystem.Domain.Enums;
using BookingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystem.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<bool> IsEmailUniqueAsync(string email, CancellationToken cancellationToken = default);
        Task AddAsync(User user, CancellationToken cancellationToken = default);
    }
}
