using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("travels")]
    public class TravelEntity
    {
        [Column("travel_id")]
        public int Id { get; set;}
        [Required]
        [StringLength(50)]
        public string Name { get; set;}
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        [StringLength(50)]
        public string StartPlace { get; set; }
        [Required]
        [StringLength(50)]
        public string EndPlace { get; set; }
        public int NumbParticipants { get; set; }
        [Required]
        [StringLength(50)]
        public string Guide { get; set; }
        public TravelAgencyEntity? TravelAgency { get; set; }
        public int? TravelAgencyId { get; set; }
        
    }
}
