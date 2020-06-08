using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeTimesheet.Models;
using EmployeeTimesheet.Models.Settings;
using EmployeeTimesheet.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTimesheet.Services
{
    public interface IZadatakService
    {
        List<ZadatakViewModel> GetZadaci(string UserID = null);

        void PostZadatak(ZadatakViewModel model);
        void EditZadatak(ZadatakViewModel model);

        List<ZadaciDropdown> ZadaciDropdown(string UserId);

        void Deactivate(Guid id);
    }

    public class ZadatakService : IZadatakService
    {

        private ApplicationDbContext _context;

        public ZadatakService(ApplicationDbContext context)
        {
            _context = context;
        }


        public List<ZadatakViewModel> GetZadaci(string UserID = null)
        {
            var list = _context.Zadaci.Include(x => x.User).Include(x => x.TipZadatka).AsQueryable();
            if (!string.IsNullOrWhiteSpace(UserID))
            {
                list.Where(x => x.KreiranOd == UserID);
            }

            var result = list.AsEnumerable().OrderByDescending(x => x.DatumKreiranja).Select(x => new ZadatakViewModel
            {
                Id = x.Id,
                Naziv = x.Naziv,
                Opis = x.Opis,
                DatumKreiranja = x.DatumKreiranja.ToString("dd/MM/yyyy HH:mm"),
                KreiranOd = x.User.FirstName + " " + x.User.LastName,
                Aktivan = x.Aktivan,
                Tip = x.TipZadatka.Name
            }).ToList();


            return result;
        }

        public void PostZadatak(ZadatakViewModel model)
        {

            var zadatak = new Zadatak()
            {
                Id = Guid.NewGuid(),
                Naziv = model.Naziv,
                Opis = model.Opis,
                TipId = int.Parse(model.Tip),
                Aktivan = true,
                DatumKreiranja = DateTime.Now,
                KreiranOd = model.KreiranOd
            };

            _context.Zadaci.Add(zadatak);
            _context.SaveChanges();
        }

        public void EditZadatak(ZadatakViewModel model)
        {
            var zadatak = _context.Zadaci.FirstOrDefault(x => x.Id == model.Id);

            if (zadatak != null)
            {
                zadatak.Naziv = model.Naziv;
                zadatak.Opis = model.Opis;
                zadatak.TipId = int.Parse(model.Tip);

                _context.SaveChanges();
            }
        }

        public List<ZadaciDropdown> ZadaciDropdown(string UserId)
        {
            var list = _context.Zadaci.Include(x => x.User).Include(x => x.TipZadatka).AsQueryable();
            if (!string.IsNullOrWhiteSpace(UserId))
            {
                list.Where(x => x.KreiranOd == UserId);
            }

            var zadacidropdown = list.Where(x => x.Aktivan).Select(x => new ZadaciDropdown
            {
                Id = x.Id,
                Naziv = x.Naziv
            }).ToList();

            return zadacidropdown;
        }

        public void Deactivate(Guid id)
        {
            var item = _context.Zadaci.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.Aktivan = false;
                _context.SaveChanges();
            }
        }
    }
}