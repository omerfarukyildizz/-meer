using Azure;
using Pbk.DataAccess.Context;
using Pbk.Entities.Dto.Stage;
using Pbk.Entities.Dto.Voyage;
using Pbk.Entities.ModelDtos;
using Pbk.Entities.Models;
using Pbk.Entities.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pbk.DataAccess.Repositories
{
    internal sealed class StageRepository : Repository<Stage>, IStageRepository
    {
        ApplicationDbContext _context;
        public StageRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Decimal> getKm(int StageId)
        {
            try
            {
                var stages = _context.Set<GetStageKmDto>()
               .FromSqlRaw("EXEC sp_GetStageKm @StageId = {0}",
                StageId).AsEnumerable().FirstOrDefault();

                if (stages == null) return 1;

                var getKm = await getApi(stages.destinationAddress, stages.originAddress);
                
                decimal distanceInKm = Math.Round(getKm / 1000m, 2);
                return distanceInKm;

            }
            catch (Exception e)
            {
                return 1;
            }
            
        }

        public async Task<Decimal> getDynamicKM(int VehicleId)
        {
            try
            {
                var stages = _context.Set<GetStageKmDto>()
               .FromSqlRaw("EXEC sp_GetEmptyKm @VehicleId = {0}",
                VehicleId).AsEnumerable().FirstOrDefault();

                if (stages == null) return 1;

                var getKm = await getApi(stages.destinationAddress, stages.originAddress);

                decimal distanceInKm = Math.Round(getKm / 1000m, 2);
                return distanceInKm;

            }
            catch (Exception e)
            {
                return 1;
            }

        }
        public async Task<int> getApi(string destinationAddress, string originAddress)
        {

            string url = "https://service.barsan.com/DistanceService/api/Distance/GetDistinc?destinationAddress=" + destinationAddress + "&originAddress=" + originAddress + "&requestKey=Aj$y%25Ao6joBC%5EBG[jEEExN6s";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = await response.Content.ReadAsStringAsync();
                        MapResponse model = JsonSerializer.Deserialize<MapResponse>(jsonString, new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });
                        return model.Data.DistanceValue;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            catch (Exception ex)
            {
                return 1;
            }


        }

        public List<StageSpDto> GetStage(DateTime? StartDate, DateTime? EndDate, int? SelectedDepartmentId, int RoleId, int UserId, bool ShowCompleted)
        {
            try
            {
                var stages = _context.Set<StageSpDto>()
                .FromSqlRaw("EXEC sp_GetStageList @StartDate = {0}, @EndDate = {1}, @SelectedDepartmentId = {2}, @RoleId = {3}, @UserId = {4}, @ShowCompleted = {5}",
                 StartDate ?? (object)DBNull.Value,
                 EndDate ?? (object)DBNull.Value,
                 SelectedDepartmentId ?? 0,
                 RoleId,
                 UserId,
                 ShowCompleted)
                 .ToList();


                return stages;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}



