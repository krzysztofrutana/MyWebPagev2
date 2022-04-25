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
    [Table("ProjectToFileRelations")]
    public class ProjectToFileRelation
    {
        [Key]
        public int Id { get; set; }
        public int FileId { get; set; }
        public FileAttachment File { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
