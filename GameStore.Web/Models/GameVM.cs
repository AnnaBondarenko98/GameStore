using System.Collections.Generic;

namespace GameStore.Models
{
    public class GameVm
    {
        public int Id { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public  ICollection<CommentVm> Comments { get; set; }

        public  ICollection<GenreVm> Genres { get; set; }

        public  ICollection<PlatformTypeVm> PlatformTypes { get; set; }
    }
}