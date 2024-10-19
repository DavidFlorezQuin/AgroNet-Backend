using Data.Operational.Inferface;
using Entity.Context;
using Entity.Dto.Operation;
using Entity.Model.Operational;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Data.Operational.services
{
    public class AlertData : ABaseData<Alerts>, IAlertData
    {
        private readonly AplicationDbContext _context;
        public AlertData(AplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<AlertDto>> GetAlertsAsync(int farmId)
        {
            var alerts = await _context.Alerts
                .Include(a => a.Animal)
                .Include(a => a.CategoryAlert)
                .Include(a => a.Users)
                .Where(a =>
                    (a.FarmsId == farmId) &&
                    a.deleted_at == null)
                .Select(a => new AlertDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                    Date = a.Date,
                    IsRead = a.IsRead,
                    AnimalId = a.AnimalId,
                    Animal = a.Animal != null ? a.Animal.Name : "Sin animal",
                    CategoryAlertId = a.CategoryAlertId,
                    CategoryAlert = a.CategoryAlert.Name,
                    UsersId = a.UsersId,
                    Users = a.Users.username,
                    state = a.state
                }).ToListAsync();

            return alerts;
        }


        public async Task<List<Alerts>> GetAlertsNotReads(int farmId)
        {
            var alerts = await _context.Alerts
                .Where(a => a.Date <= DateTime.Now && a.IsRead == false && a.state == true && a.FarmsId == farmId).ToListAsync();

            return alerts;

        }

        public async Task AlertIsRead(int alertId)
        {
            var entity = await _context.Alerts.FindAsync(alertId); 

            if(entity != null)
            {
                entity.IsRead = true;

                await _context.SaveChangesAsync();
            }
        }
    }
}
