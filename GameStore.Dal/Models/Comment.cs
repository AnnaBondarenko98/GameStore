using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Dal.Models
{
    public class Comment:BaseEntity
    {
        public string Name { get; set; }

        public string Body { get; set; }

        [ForeignKey("ParentComment")]
        public int? ParentCommentId { get; set; }

        public virtual Comment ParentComment { get; set; }

        public virtual Game Game { get; set; }
    }
}
