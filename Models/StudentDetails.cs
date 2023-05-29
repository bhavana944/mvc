using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace StudentDetails_MVC_.Models
{
    public class StudentDetails
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression("[A-Za-z]*", ErrorMessage = "Invalid Name ")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please Select Standard")]
        public string Standard { get; set; }


        [Required(ErrorMessage = "Section is required")]
        public string Section { get; set; }

        //[Required]
        public string Hobbies { get; set; }
        //public bool IsSelected { get; set; }

        [Required(ErrorMessage = "Subjects is required")]
        public string Subjects { get; set; }
      //  public List<string>Subject{get;set;}
        public int? Marks1 { get; set; }
        public int? Marks2 { get; set; }
        public int? Marks3 { get; set; }
        public long Total { get; set; }

    }
    //public class Subjects
    //{
    //    public int Sid { get; set; }
    //    public string Sname { get; set; }
    //}


}