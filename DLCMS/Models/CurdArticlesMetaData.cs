using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace DLCMS.Models
{
    [MetadataType(typeof(metadatafornews))]
    public partial class Updates_MainWebsites
    {

    }

    class metadatafornews
    {
        public int ID { get; set; }
        [Required]
        [DisplayName("Title for News/Article")]
        [StringLength(170)]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [DisplayName("Brief Description for News/Article")]
        public string Brief { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Contents { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayName("Date of the Article")]
        public Nullable<System.DateTime> Date_Update { get; set; }
        [Required]
        public Nullable<System.DateTime> Date_Added { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public bool Live { get; set; }
        [Required]
        [DisplayName("Meta Data (Description)")]
        [StringLength(160)]
        public string Description { get; set; }
        [Required]
        [DisplayName("Meta Data (Keywords)")]
        public string Keywords { get; set; }
        [DisplayName("Image of the department to be used if legal news")]
        public string Blog_Department { get; set; }
        public Nullable<int> Total_Comments { get; set; }
        [Required]
        public Nullable<bool> Image { get; set; }
        public Nullable<long> Duplicate_ID { get; set; }
        public string KeywordsToBeUsed { get; set; }
        [Required]
        [DisplayName("Meta Data (Title)")]
        [StringLength(60)]
        public string Page_Title { get; set; }
        public string DLorNonDL { get; set; }
        [Remote("CheckStaffName","Validation")]
        public string Staff1 { get; set; }
        [Remote("CheckStaffName", "Validation")]
        public string Staff2 { get; set; }
        [Remote("CheckStaffName", "Validation")]
        public string Staff3 { get; set; }
        [Required]
        [DisplayName("What to upload?")]
        public string category { get; set; }
        [Required]
        public bool video { get; set; }
        [Required]
        public string filename { get; set; }
    }
}