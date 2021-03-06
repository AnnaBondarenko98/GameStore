﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Dal.Models
{
    public class Genre:BaseEntity
    {
        [Index(IsUnique = true)]
        [MaxLength(20)]
        public string Name { get; set; }

        public virtual Genre ParentGenre { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
