using System.Collections.Generic;

namespace GameStore.Bll.ModelsDto
{
    public class GameDto
    {
        public int Id { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsDeleted { get;set;}

        public  ICollection<CommentDto> Comments { get; set; }

        public  ICollection<GenreDto> Genres { get; set; }

        public  ICollection<PlatformTypeDto> PlatformTypes { get; set; }
    }
}
