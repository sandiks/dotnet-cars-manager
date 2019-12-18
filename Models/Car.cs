using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsManager.Models
{
    public class Car
    {
        public int ID { get; set; }

        [StringLength(20, MinimumLength = 3)]
        public string Manufacture { get; set; }

        [StringLength(20, MinimumLength = 3)]
        public string Model { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Production Date")]
        public DateTime ProductionDate { get; set; }

        [Range(0, 10000)]
        public int Engine { get; set; }

    }
}