using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static SovosAssessmentMVC.Models.Enum;

namespace SovosAssessmentMVC.Models
{
    public class CaseViewModel
    {
        public Guid Id { get; set; }
        public int? Type { get; set; }
        public TypeEnum? TypeEnum { get; set; }
        public int? Status { get; set; }
        public StatusEnum? StatusEnum { get; set; }
        [DisplayName("User Name")]
        public string UserName { get; set; }
        public string Title { get; set; }
        [Display(Name = "Search Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateStart { get; set; }
        [Display(Name = "Search End Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateEnd { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}