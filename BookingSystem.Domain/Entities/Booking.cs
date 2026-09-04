using BookingSystem.Domain.Common;
using BookingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystem.Domain.Enums
{
    public class Booking
    {
        public Guid Id { get; private set; }
        public Guid ResourceId { get; private set; }
        public Guid CustomerId { get; private set; }
        public DateTimeRange TimeRange { get; private set; } = null!;
        public BookingStatus Status { get; private set; }
        public DateTimeOffset CreatedAtUtc { get; private set; }
        public uint Version { get; private set; } // xmin concurrency token

        private Booking() { } // Для EF Core

        public static Result<Booking> Create(Guid resourceId, Guid customerId, DateTimeRange timeRange)
        {
            if (resourceId == Guid.Empty || customerId == Guid.Empty)
                return Result.Failure<Booking>("Ідентифікатори ресурсу та клієнта обов'язкові.");

            var booking = new Booking
            {
                Id = Guid.NewGuid(),
                ResourceId = resourceId,
                CustomerId = customerId,
                TimeRange = timeRange,
                Status = BookingStatus.Confirmed,
                CreatedAtUtc = DateTimeOffset.UtcNow
            };

            return Result.Success(booking);
        }

        public Result Cancel(DateTimeOffset currentUtc, TimeSpan cancellationWindow)
        {
            if (Status == BookingStatus.Cancelled)
                return Result.Failure("Бронювання вже скасовано.");

            if (TimeRange.Start - currentUtc < cancellationWindow)
                return Result.Failure($"Скасування неможливе менше ніж за {cancellationWindow.TotalHours} год до початку.");

            Status = BookingStatus.Cancelled;
            return Result.Success();
        }
    }
}
