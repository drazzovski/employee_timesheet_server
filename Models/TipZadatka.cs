using System.Collections.Generic;

namespace EmployeeTimesheet.Models
{
    public class TipZadatka
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Zadatak> Zadaci { get; set; }
    }
}