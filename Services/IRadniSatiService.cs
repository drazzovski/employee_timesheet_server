using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeTimesheet.Models;
using EmployeeTimesheet.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTimesheet.Services
{
    public interface IRadniSatiService
    {
        List<RadniSatiViewModel> GetRadniSati(string UserID = null);
        void PostRadniSati(RadniSatiViewModel model);

        void DeleteRadniSati(Guid id);
    }

    public class RadniSatiService : IRadniSatiService
    {
        private ApplicationDbContext _context;

        public RadniSatiService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void DeleteRadniSati(Guid id)
        {
            var item = _context.RadniSati.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _context.RadniSati.Remove(item);
                _context.SaveChanges();
            }
        }

        public List<RadniSatiViewModel> GetRadniSati(string UserID = null)
        {
            var list = _context.RadniSati.Include(x => x.User).Include(x => x.Zadatak).AsQueryable();
            if (!string.IsNullOrWhiteSpace(UserID))
            {
                list.Where(x => x.UserId == UserID);
            }

            var result = list.AsEnumerable().OrderByDescending(x => x.DatumUnosa).Select(x => new RadniSatiViewModel
            {
                Id = x.Id,
                Zadatak = x.Zadatak?.Naziv,
                User = x.User?.FirstName + " " + x.User?.LastName,
                Sati = (int)Math.Floor(TimeSpan.FromTicks(x.UtrosenoVrijeme).TotalHours),
                Minute = TimeSpan.FromTicks(x.UtrosenoVrijeme).Minutes,
                DatumUnosa = x.DatumUnosa.ToString("dd/MM/yyyy HH:mm"),
                Aktivan = x.Zadatak?.Aktivan
            }).ToList();

            return result;
        }

        public void PostRadniSati(RadniSatiViewModel model)
        {

            var radnisati = new RadniSati()
            {
                Id = Guid.NewGuid(),
                DatumUnosa = DateTime.Now,
                UserId = model.UserId,
                ZadatakId = model.ZadatakId.Value,
                UtrosenoVrijeme = new TimeSpan(model.Sati, model.Minute, 0).Ticks
            };

            _context.RadniSati.Add(radnisati);
            _context.SaveChanges();
        }


    }
}