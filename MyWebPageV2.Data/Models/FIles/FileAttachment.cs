using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebPageV2.Data.Models.Files
{
    [Table("FileAttachments")]
    public class FileAttachment
    {
        [Key]
        public int Id { get; set; }
        public string? Path { get; set; }
        public string? Name { get; set; }
        public string? Mime { get; set; }
        public string? Type { get; set; }
    }


    public enum FileType
    {
        Image,
        MobileApp,
        DesktopApp,
        Document
    }
}
