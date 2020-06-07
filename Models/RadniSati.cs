using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeTimesheet.Models
{
    public class RadniSati
    {
        public Guid Id { get; set; }
        [ForeignKey("Zadatak")]
        public Guid ZadatakId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public long UtrosenoVrijeme { get; set; }
        public DateTime DatumUnosa { get; set; }

        public Zadatak Zadatak { get; set; }
        public ApplicationUser User { get; set; }
    }
}