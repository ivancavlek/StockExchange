using Acme.StockExchange.Domain.Utility;
using System;

namespace Acme.StockExchange.Domain.ValueType
{
    public class Period
    {
        public DateTime ValidFrom { get; set; }
        public DateTime? ValidTill { get; set; }

        public Period() { }

        public Period(DateTime dateFrom)
        {
            ValidFrom = dateFrom;
        }

        public bool IsActive(DateTime dateTime) =>
            ValidFrom <= dateTime && (!ValidTill.HasValue || dateTime < ValidTill);

        public bool IsWithin(DateTime dateFrom, DateTime? dateTill)
        {
            bool isWithin = false;

            if (!ValidTill.HasValue && !dateTill.HasValue)
                isWithin = ValidFrom <= dateFrom;
            else if (!ValidTill.HasValue)
                isWithin = ValidFrom <= dateFrom;
            else if (!dateTill.HasValue)
                isWithin = false;
            else
                isWithin = ValidFrom <= dateFrom && ValidTill.Value >= dateTill;

            return isWithin;
        }

        public void SetValidTill(DateTime? validTill)
        {
            if (validTill.HasValue && validTill < ValidFrom)
                throw new DomainException("Valid till has no value or is before valid from");

            ValidTill = validTill;
        }

        public override string ToString() =>
            $"{ValidFrom} - {(ValidTill.HasValue ? ValidTill.Value.ToString() : string.Empty)}";
    }
}