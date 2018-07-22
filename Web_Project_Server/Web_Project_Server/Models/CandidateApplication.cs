using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web_Project_Server.Models
{
    public class CandidateApplication
    {
        [Key]
        [Column(Order = 1)]
        public string Candidate { get; set; }
        [Key]
        [Column(Order = 2)]
        public int Election_Id { get; set; }
        [Key]
        [Column(Order = 3)]
        public string City { get; set; }
        [Key]
        [Column(Order = 4)]
        public string Level { get; set; }


    }
}