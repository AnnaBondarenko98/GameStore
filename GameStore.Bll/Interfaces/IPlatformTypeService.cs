using System.Collections.Generic;
using GameStore.Bll.ModelsDto;

namespace GameStore.Bll.Interfaces
{
    public interface IPlatformTypeService
    {
        IEnumerable<PlatformTypeDto> GetAll();

        PlatformTypeDto Get(int id);

        void Create(PlatformTypeDto platform);

        void Update(PlatformTypeDto platform);

        void Delete(int id);
    }
}