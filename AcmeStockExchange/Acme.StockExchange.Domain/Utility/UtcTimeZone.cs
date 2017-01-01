using System;

namespace Acme.StockExchange.Domain.Utility
{
    public class UtcTimeZone
    {
        private readonly TimeZoneInfo _timeZoneInfo;

        public UtcTimeZone(TimeZoneInfo timeZoneInfo)
        {
            if (timeZoneInfo == null)
                throw new ArgumentNullException(nameof(timeZoneInfo));

            _timeZoneInfo = timeZoneInfo;
        }

        public DateTime GetCurrentDisplayTime() =>
            TimeZoneInfo.ConvertTimeFromUtc(GetCurrentRepositoryTime(), _timeZoneInfo);

        public DateTime GetCurrentRepositoryTime() => DateTime.UtcNow;

        public DateTime GetDisplayTime(DateTime repositoryDateTime)
        {
            var convertedDateTime = new DateTime();

            var utcDateTime = DateTime.SpecifyKind(repositoryDateTime, DateTimeKind.Utc);
            convertedDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, _timeZoneInfo);

            return convertedDateTime;
        }

        public DateTime GetRepositoryTime(DateTime displayDateTime)
        {
            var convertedDateTime = new DateTime();

            var unspecifiedDateTime = DateTime.SpecifyKind(displayDateTime, DateTimeKind.Unspecified);
            convertedDateTime = TimeZoneInfo.ConvertTimeToUtc(unspecifiedDateTime, _timeZoneInfo);

            return convertedDateTime;
        }
    }
}