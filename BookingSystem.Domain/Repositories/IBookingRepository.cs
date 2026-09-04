using BookingSystem.Domain.Common;
using BookingSystem.Domain.Enums;
using BookingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystem.Domain.Repositories
{
    public interface IBookingRepository
    {
        Task<Booking?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> HasOverlapAsync(Guid resourceId, DateTimeRange timeRange, CancellationToken cancellationToken = default);
        Task AddAsync(Booking booking, CancellationToken cancellationToken = default);
    }
}
