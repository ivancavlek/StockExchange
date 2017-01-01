using System;

namespace Acme.StockExchange.Domain.Utility
{
    public interface ITimeZone
    {
        DateTime GetCurrentDisplayTime();
        DateTime GetCurrentRepositoryTime();
        DateTime GetDisplayTime(DateTime repositoryDateTime);
        DateTime GetRepositoryTime(DateTime displayDateTime);
    }
}