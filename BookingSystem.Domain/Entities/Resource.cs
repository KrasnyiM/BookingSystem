using BookingSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystem.Domain.Enums
{
    public class Resource
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public TimeSpan SlotDuration { get; private set; }
        public bool IsActive { get; private set; }

        private Resource() { }

        public static Result<Resource> Create(string name, string description, TimeSpan slotDuration)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result.Failure<Resource>("Назва ресурсу не може бути порожньою.");

            if (slotDuration <= TimeSpan.Zero)
                return Result.Failure<Resource>("Тривалість слота має бути більшою за 0.");

            return Result.Success(new Resource
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                SlotDuration = slotDuration,
                IsActive = true
            });
        }
    }
}
