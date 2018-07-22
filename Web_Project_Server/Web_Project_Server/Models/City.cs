﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web_Project_Server.Models
{

    public class City
    {
        
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Province { get; set; }
        
        
		
	}
    
}