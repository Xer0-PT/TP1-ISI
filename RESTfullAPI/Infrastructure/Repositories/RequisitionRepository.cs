using Microsoft.EntityFrameworkCore;
using RestfullAPI.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP1.Domain.Context;
using TP1.Domain.Models;

namespace RestfullAPI.Infrastructure.Repositories
{
    public class RequisitionRepository : IRequisitionRepository
    {
        private readonly DataContext _context;

        public RequisitionRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateRequisitionProduct(int requisitionId, Product product, int quantity)
        {


            var requisitionProduct = new RequisitionProduct
            {
                ProductId = product.Id,
                Quantity = quantity,
                RequisitionId = requisitionId,
                CreateDate = DateTime.UtcNow
            };

            _context.RequisitionProducts.Add(requisitionProduct);

            product.Stock = product.Stock - quantity;
            _context.Products.Update(product);

            await _context.SaveChangesAsync();

            return true;

        }


        public async Task<int> CreateRequisition(Team team)
        {
            var requisition = new Requisition
            {
                CreateDate = DateTime.UtcNow,
                Processed = false,
                TeamId = team.Id
            };
            _context.Requisitions.Add(requisition);
            await _context.SaveChangesAsync();

            return requisition.Id;

        }

     

        public async Task<List<Requisition>> GetRequisitionsByTeam(Team team)
        {
            var result = await _context.Requisitions.Where(r => r.TeamId == team.Id).ToListAsync();

            foreach (var requisition in result)
            {
                requisition.RequisitionProducts = _context.RequisitionProducts.Where(rp => rp.RequisitionId == requisition.Id).ToList();

                foreach (var item in requisition.RequisitionProducts)
                {
                    item.Product = _context.Products.FirstOrDefault(p=> p.Id == item.ProductId);
                }
            }

            

            return result;
        }

        public async Task<List<Requisition>> GetAllRequisitionsPendents()
        {
            return await _context.Requisitions.Where(r => r.Processed == false).ToListAsync();
        }

        public async Task<bool> UpdateRequisition(Requisition requisition)
        {

            _context.Requisitions.Update(requisition);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Requisition>> GetAll()
        { 
            var requisitions = await _context.Requisitions.ToListAsync();

            if (requisitions == null) return null;

            foreach (var item in requisitions)
            {
                var aux = _context.RequisitionProducts.Where(x => x.RequisitionId == item.Id).ToList();

                item.Team = _context.Teams.First(x => x.Id == item.TeamId);

                item.RequisitionProducts = aux;

                foreach (var reqproduct in item.RequisitionProducts)
                {
                    var productAux = _context.Products.FirstOrDefault(x => x.Id == reqproduct.ProductId);

                    reqproduct.Product = productAux;
                }
            }

            return requisitions;
        }

        public async Task<List<RequisitionProduct>> GetRequisitionProductsAsync()
        {
            return  await _context.RequisitionProducts.ToListAsync();

        }
    }
}
