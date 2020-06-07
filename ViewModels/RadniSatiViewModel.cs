using System;

namespace EmployeeTimesheet.ViewModels
{
    public class RadniSatiViewModel
    {
        public Guid? Id { get; set; }
        public string Zadatak { get; set; }
        public Guid? ZadatakId { get; set; }
        public string User { get; set; }
        public string UserId { get; set; }
        public int Sati { get; set; }
        public int Minute { get; set; }
        public string DatumUnosa { get; set; }
        public bool? Aktivan { get; set; }

    }
}