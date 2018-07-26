using System.Collections.Generic;
using GameStore.Bll.ModelsDto;

namespace GameStore.Bll.Interfaces
{
    public interface IGenreService
    {
        IEnumerable<GenreDto> GetAll();

        GenreDto Get(int id);

        void Create(GenreDto genre);

        void Update(GenreDto genre);

        void Delete(int id);
    }
}