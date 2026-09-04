using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystem.Domain.Common
{
    public record DateTimeRange
    {
        public DateTimeOffset Start { get; }
        public DateTimeOffset End { get; }
        public TimeSpan Duration => End - Start;

        private DateTimeRange(DateTimeOffset start, DateTimeOffset end)
        {
            Start = start;
            End = end;
        }

        public static Result<DateTimeRange> Create(DateTimeOffset start, DateTimeOffset end)
        {
            if (start >= end)
                return Result.Failure<DateTimeRange>("Time start must be earlier than time end.");

            return Result.Success(new DateTimeRange(start, end));
        }

        public bool OverlapsWith(DateTimeRange other) =>
            Start < other.End && End > other.Start;
    }
}
