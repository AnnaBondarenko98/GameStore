using System.Collections.Generic;

namespace GameStore.Bll.ModelsDto
{
    public class PlatformTypeDto
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<GameDto> Games { get; set; }
    }
}
