using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DLCMS.Models
{
    [MetadataType(typeof(MetadataforWebsitePages))]
    public partial class Website_Pages
    {

    }

    class MetadataforWebsitePages
    {
        public int ID { get; set; }
        [Required]
        [DisplayName("Name/Heading/H1 Tag")]
        [StringLength(170)]
        public string Name { get; set; }
        [Required]
        public string Department { get; set; }
        
        [DisplayName("Sub Department")]
        public string Sub_Department { get; set; }
        [Required]
        [DisplayName("Meta Data (Keywords)")]
        public string Keywords { get; set; }
        [Required]
        [DisplayName("Meta Data (Title)")]
        [StringLength(70)]
        public string Title { get; set; }
        [Required]
        [StringLength(160)]
        [DisplayName("Meta Data (Description)")]
        public string Description { get; set; }
        [Required]
        [DisplayName("Page Text")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        [DisplayName("Sub Sub Department")]
        public string Sub_Sub_Department { get; set; }
        [Required]
        public string Filename { get; set; }
        public string RewriteURL { get; set; }
        public string Company { get; set; }
        public Nullable<int> Sequence { get; set; }
        public Nullable<System.DateTime> date_update { get; set; }
        public string anchortextnavigation { get; set; }
    }
}