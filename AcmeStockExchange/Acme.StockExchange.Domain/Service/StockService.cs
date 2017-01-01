using Acme.StockExchange.Domain.DataTransferObject;
using Acme.StockExchange.Domain.Entity;
using Acme.StockExchange.Domain.Repository;
using Acme.StockExchange.Domain.Utility;
using System;
using System.Collections.Generic;

namespace Acme.StockExchange.Domain.Service
{
    public sealed class StockService : BaseService, IStockService
    {
        private readonly IIdentityFactory<Guid> _identityFactory;
        private readonly IStockRepository _stockRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StockService(
            IIdentityFactory<Guid> identityFactory,
            IStockRepository stockRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
            : base(mapper)
        {
            if (identityFactory == null)
                throw new ArgumentNullException(nameof(identityFactory));
            if (stockRepository == null)
                throw new ArgumentNullException(nameof(stockRepository));
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            _identityFactory = identityFactory;
            _stockRepository = stockRepository;
            _unitOfWork = unitOfWork;
        }

        StockDto IStockService.CreateStock(StockDto stockDto)
        {
            if (stockDto == null)
                throw new DomainException("Stock must be set");

            var newStock = new Stock(_identityFactory);
            Mapper.Map(stockDto, newStock);

            _unitOfWork.Insert(newStock);
            _unitOfWork.Commit();

            Mapper.Map(newStock, stockDto);
            return stockDto;
        }

        void IStockService.DeleteStock(Guid stockId)
        {
            if (stockId.Equals(Guid.Empty))
                throw new DomainException("Stock identification must be set");

            var existingStock = _stockRepository.GetStockById(stockId);

            _unitOfWork.Delete(existingStock);
            _unitOfWork.Commit();
        }

        IEnumerable<StockDto> IStockService.GetStocks()
        {
            var allStocks = _stockRepository.GetStocks();

            return Mapper.Map<IEnumerable<Stock>, IEnumerable<StockDto>>(allStocks);
        }

        StockDto IStockService.UpdateStock(StockDto stockDto)
        {
            if (stockDto == null || stockDto.Id.Equals(Guid.Empty))
                throw new DomainException("Stock and stock identification must be set");

            var existingStock = _stockRepository.GetStockById(stockDto.Id);
            Mapper.Map(stockDto, existingStock);

            _unitOfWork.Update(existingStock);
            _unitOfWork.Commit();

            return stockDto;
        }
    }
}