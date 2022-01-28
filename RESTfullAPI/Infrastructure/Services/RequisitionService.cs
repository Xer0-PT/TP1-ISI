using AutoMapper;
using RestfullAPI.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TP1.Domain.Models.DTO;

#pragma warning disable CS8632

namespace RestfullAPI.Infrastructure.Services
{
    public class RequisitionService : IRequisitionService
    {
        private readonly IRequisitionRepository _requisitionRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public RequisitionService(IRequisitionRepository requisitionRepository, ITeamRepository teamRepository,
            IProductRepository productRepository, IMapper mapper)
        {
            _requisitionRepository = requisitionRepository;
            _teamRepository = teamRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<bool> CreateRequisition(string teamName, List<ProductQuantityDTO> products)
        {
            var team = await _teamRepository.GetTeam(null, teamName);
            if (team != null)
            {
                var requisitionId = await _requisitionRepository.CreateRequisition(team);
                foreach (var item in products)
                {
                    var product = await _productRepository.GetProductAsync(null, item.ProductName);

                    if (product != null && product.Stock > item.Quantity)
                    {
                        await _requisitionRepository.CreateRequisitionProduct(requisitionId, product, item.Quantity);

                    }
                    else
                    {
                        return false;
                    }

                }
                return true;
            }
            return false;

        }


        public async Task<List<RequisitionDTO>> GetRequisitionsByTeam(int? teamId, string? teamName)
        {
            var team = await _teamRepository.GetTeam(teamId, teamName);

            if (team != null)
            {
                var result = await _requisitionRepository.GetRequisitionsByTeam(team);

                return _mapper.Map<List<RequisitionDTO>>(result);


            }

            return null;

        }

        public async Task CheckTimeOfRequisition()
        {
            var requisitions = await _requisitionRepository.GetAllRequisitionsPendents();

            if (requisitions != null)
            {
                foreach (var requisition in requisitions)
                {
                    if (requisition.CreateDate.AddMinutes(1) < DateTime.UtcNow)
                    {
                        requisition.Processed = true;
                        requisition.ChangeDate = DateTime.UtcNow;
                        await _requisitionRepository.UpdateRequisition(requisition);
                    }
                }
            }

        }

        public async Task<List<RequisitionDTO>> GetAllRequisitions()
        {
            var result = await _requisitionRepository.GetAll();
            return _mapper.Map<List<RequisitionDTO>>(result);
        }
    }
}
