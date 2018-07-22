
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;
namespace Web_Project_Server.Models
{
    public class User
    {
        [Required(ErrorMessage = "User Type Required")]
        [Display(Name = "User Type")]
        public string UserType { get; set; }

        public bool isApproved { get; set; }
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Name length: 5-30")]
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name Required")]
        public string Name { get; set; }
        [Key]
        [RegularExpression(@"^^[a-zA-Z0-9]([._](?![._])|[a-zA-Z0-9]){6,18}[a-zA-Z0-9]$", ErrorMessage = "User Name length: 8-18. User Name must contain letters and digits")]
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User Name Required")]
        public string UserName { get; set; }
        [RegularExpression(@"^[0-9+]{5}-[0-9+]{7}-[0-9]{1}$", ErrorMessage = "CNIC must be in the form 11111-1111111-1")]
        [Display(Name = "CNIC")]
        [Required(ErrorMessage = "CNIC Required")]
        public string CNIC { get; set; }
        [Required(ErrorMessage = "Education Required")]
        public string Education { get; set; }
        [Required(ErrorMessage = "City Required")]
        public string City { get; set;}
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{4,15}$", ErrorMessage = "Password Length: 4-15.   Password must contain upper and lower case letters, and digits as well")]
        public string Password { get; set; }
       
        public string PicPath { get; set; }
        [Display(Name = "Age")]
        [Range(minimum: 18, maximum: 150, ErrorMessage = "Age must be greater than 18")]
        [Required(ErrorMessage = "Age Required")]
        
        public int Age { get; set; }
		[Display(Name = "Candidate City")]
		public string CandidateCity { get; set; }
    }
}