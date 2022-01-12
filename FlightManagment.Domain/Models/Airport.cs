using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagment.Domain.Models
{
    public class Airport
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        /*      #### IMPORTANT ####
             
              We still have to manually configure the initial migration
              to check this set up this as null and especially proper datatype being "date"

        */
        [DataType(DataType.Date)]
        public DateTime? ConstructionDate { get; set; }
        // NavProps
        public int CountryId { get; set; }
        [ForeignKey(nameof(CountryId))]
        [NotMapped]
        public Country Country { get; set; }
    }
}
