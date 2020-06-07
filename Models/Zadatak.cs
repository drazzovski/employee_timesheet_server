using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeTimesheet.Models
{
    public class Zadatak
    {
        public Guid Id { get; set; }
        [Required]
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public DateTime DatumKreiranja { get; set; }
        [ForeignKey("TipZadatka")]
        public int TipId { get; set; }
        public bool Aktivan { get; set; }
        [ForeignKey("User")]
        public string KreiranOd { get; set; }
        public TipZadatka TipZadatka { get; set; }
        public ApplicationUser User { get; set; }

        public ICollection<RadniSati> RadniSati { get; set; }

    }
}