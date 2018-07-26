using System.Collections.Generic;

namespace GameStore.Web.Models
{
    public class GenreVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public  GenreVm ParentGenre { get; set; }

        public  ICollection<GameVm> Games { get; set; }
    }
}