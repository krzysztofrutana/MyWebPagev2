using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebPageV2.Data.Models.Files;

namespace MyWebPageV2.Data.Models.Project
{
    [Table("Projects")]

    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string? NameJSON { get; set; }
        public int? LogoId { get; set; }
        public FileAttachment? Logo { get; set; }
        public string? ShortDiscriptionJSON { get; set; }
        public string? DiscriptionJSON { get; set; }
        public string? RequirementsJSON { get; set; }
        public string? Technologies { get; set; }
        public string? License { get; set; }
        public string? SourceLink { get; set; }
        public string? Platform { get; set; }
        public int? DownloadFileId { get; set; }
        public FileAttachment? DownloadFile { get; set; }
        public ICollection<ProjectToFileRelation>? Screenshots { get; set; }
        public string? ProjectType { get; set; }
    }

    public enum ProjectType
    {
        MobileApp,
        DesktopApp,
        WebPage
    }
}
