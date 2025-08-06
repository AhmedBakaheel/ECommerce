using ECommerce.Application.DTOs.Products;
using ECommerce.Domain.Interfaces;
using ECommerce.Domain.UnitOfWork;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Domain.Entities;


namespace ECommerce.Application.Features.Products.Queries
{
    // 1. الاستفسار (Query)
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>
    {
    }

    // 2. المعالج (Handler)
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.Products.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }
    }
}