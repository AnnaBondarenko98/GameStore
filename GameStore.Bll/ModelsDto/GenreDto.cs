using System.Collections.Generic;

namespace GameStore.Bll.ModelsDto
{
    public class GenreDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public  GenreDto ParentGenre { get; set; }

        public ICollection<GameDto> Games { get; set; }
    }
}
