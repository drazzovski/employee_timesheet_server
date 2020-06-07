using System;

namespace EmployeeTimesheet.ViewModels
{
    public class ZadatakViewModel
    {
        public Guid? Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string Tip { get; set; }
        public string DatumKreiranja { get; set; }
        public string KreiranOd { get; set; }
        public bool Aktivan { get; set; }
        public bool IsEdit { get; set; }
    }
}