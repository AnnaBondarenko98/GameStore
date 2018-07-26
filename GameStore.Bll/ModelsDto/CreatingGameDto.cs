using System.Collections.Generic;

namespace GameStore.Bll.ModelsDto
{
    public class CreatingGameDto
    {
        public int Id { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<CommentDto> Comments { get; set; }

        public ICollection<int> PlatformTypesIds { get; set; }

        public ICollection<int> GenresIds { get; set; }

    }
}
