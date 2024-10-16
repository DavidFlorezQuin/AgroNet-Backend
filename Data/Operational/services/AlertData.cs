﻿using Data.Operational.Inferface;
using Entity.Context;
using Entity.Dto.Operation;
using Entity.Model.Operational;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    (a.Animal == null || a.Animal.Lot.Farm.Id == farmId) &&  // Permite registros sin animal
                    (a.Animal == null || a.Animal.Lot.Farm.state == true) && // Valida estado si tiene animal
                    a.deleted_at == null)
                .Select(a => new AlertDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                    Date = a.Date,
                    IsRead = a.IsRead,
                    AnimalId = a.AnimalId,
                    Animal = a.Animal != null ? a.Animal.Name : "Sin animal", // Maneja caso nulo
                    CategoryAlertId = a.CategoryAlertId,
                    CategoryAlert = a.CategoryAlert.Name,
                    UsersId = a.UsersId,
                    Users = a.Users.username,
                    state = a.state
                }).ToListAsync();

            return alerts;
        }

    }
}
