using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web_Project_Server.Models
{
    public class Vote
    {
		[Key]
        [Column(Order = 1)]
		public int VoteNumber { get; set; }
		[Key]
		[Column(Order = 2)]
		public string Candidate { set; get; }
        [Key]
        [Column(Order = 3)]
        public string Voter { set; get; }
        public DateTime Date { set; get; }
		public string ElectionID { get; set; }
        public string ElectionCity { get; set; }
		

        
    }
}