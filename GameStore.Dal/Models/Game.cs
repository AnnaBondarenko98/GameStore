using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Dal.Models
{
    public class Game : BaseEntity
    {
        [Index(IsUnique = true)]
        public string Key { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }

        public virtual ICollection<PlatformType> PlatformTypes { get; set; }
    }
}