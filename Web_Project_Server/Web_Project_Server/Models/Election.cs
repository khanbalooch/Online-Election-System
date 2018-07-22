using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web_Project_Server.Models
{
    public class Election
    {
        public Election(Election e)
        {
            ID = e.ID;
            City = e.City;
            Year = e.Year;
            Level = e.Level;
            startDate = e.startDate;
            endDate = e.endDate;
            Winner = e.Winner;
        }

        public Election()
        {
        }

        [Key]
        [Column(Order = 1)]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Key]
        [Column(Order = 2)]
        public string City { get; set; }

        public string Year { get; set; }
        public string Level { get; set; }
        [Display(Name = "Start Date")]
        public DateTime startDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime endDate { get; set; }
        public string Winner { get; set; }
        public bool isApproved { get; set; }
    }
}