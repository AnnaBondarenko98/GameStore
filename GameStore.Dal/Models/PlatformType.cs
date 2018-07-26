using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Dal.Models
{
    public class PlatformType : BaseEntity
    {
        [Index(IsUnique = true)]
        public string Type { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
