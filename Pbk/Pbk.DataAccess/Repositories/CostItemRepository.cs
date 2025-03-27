using Pbk.DataAccess.Context;
using Pbk.Entities.Dto.CostItem;
using Pbk.Entities.Dto.InvoiceItem;
using Pbk.Entities.Models;
using Pbk.Entities.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.DataAccess.Repositories
{
    internal sealed class CostItemRepository : Repository<CostItem>, ICostItemRepository
    {
        ApplicationDbContext _context;

        public CostItemRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }
        public List<CostItemByParamSpDto> GetCostItemByParam(int? shipmentId, int? stageId, int? voyageId)
        {
            try
            {
                var costItemsByParam = _context.Set<CostItemByParamSpDto>()
                .FromSqlRaw("EXEC sp_GetCostItemsByParam @ShipmentId = {0}, @StageId = {1}, @VoyageId = {2}",
                 shipmentId,
                 stageId,
                 voyageId)
                 .ToList();



                return costItemsByParam;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public List<YdNakMasrafHesapPlani> GetVendor(string? search)
        {

            List<YdNakMasrafHesapPlani> list = new List<YdNakMasrafHesapPlani>();
            try
            {

                if (string.IsNullOrEmpty(search) || string.IsNullOrWhiteSpace(search))
                {

                    list = _context.Set<YdNakMasrafHesapPlani>()
                                  .FromSqlRaw("SELECT top 100 * FROM Barsan2025.dbo.ydnakmasrafhesapplani   ")
                                   .ToList();
                }
                else
                {
                 list = _context.Set<YdNakMasrafHesapPlani>()
                                       .FromSqlRaw("SELECT * FROM Barsan2025.dbo.ydnakmasrafhesapplani WHERE Hesapkodu = @HesapKodu OR HesapAdi LIKE @HesapAdi",
                                                   new SqlParameter("@HesapKodu", search),
                                                   new SqlParameter("@HesapAdi", $"{search}%"))
                                       .ToList();
                }
                return list;
            }
            catch (Exception ex)
            {
                return list;
            }
        }

        public List<CostItemListSpDto> GetCostItemList(DateTime? StartDate, DateTime? EndDate, int? SelectedDepartmentId, int RoleId, int UserId, bool ShowIntegrated)
        {
            try
            {
                var costItemList = _context.Set<CostItemListSpDto>()
                .FromSqlRaw("EXEC sp_GetCostItemsList @StartDate = {0}, @EndDate = {1}, @SelectedDepartmentId = {2}, @RoleId = {3}, @UserId = {4}, @ShowIntegrated = {5}",
                 StartDate,
                 EndDate,
                 SelectedDepartmentId,
                 RoleId,
                 UserId,
                 ShowIntegrated)
                 .ToList();

                return costItemList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
   
    
    }
}
