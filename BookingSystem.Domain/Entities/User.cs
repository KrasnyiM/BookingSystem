using BookingSystem.Domain.Common;
using BookingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystem.Domain.Enums
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; } = string.Empty;
        public string PasswordHash { get; private set; } = string.Empty;
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public UserRole Role { get; private set; }
        public DateTimeOffset CreatedAtUtc { get; private set; }

        // Порожній приватний конструктор потрібен для EF Core під час матеріалізації з БД
        private User() { }

        public static Result<User> Create(
            string email,
            string passwordHash,
            string firstName,
            string lastName,
            UserRole role = UserRole.Customer)
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
                return Result.Failure<User>("Некоректний формат email.");

            if (string.IsNullOrWhiteSpace(passwordHash))
                return Result.Failure<User>("Хеш пароля не може бути порожнім.");

            if (string.IsNullOrWhiteSpace(firstName))
                return Result.Failure<User>("Ім'я користувача є обов'язковим.");

            return Result.Success(new User
            {
                Id = Guid.NewGuid(),
                Email = email.Trim().ToLowerInvariant(),
                PasswordHash = passwordHash,
                FirstName = firstName.Trim(),
                LastName = lastName.Trim(),
                Role = role,
                CreatedAtUtc = DateTimeOffset.UtcNow
            });
        }

        public void UpdateProfile(string firstName, string lastName)
        {
            if (!string.IsNullOrWhiteSpace(firstName))
                FirstName = firstName.Trim();

            if (!string.IsNullOrWhiteSpace(lastName))
                LastName = lastName.Trim();
        }
    }
}
