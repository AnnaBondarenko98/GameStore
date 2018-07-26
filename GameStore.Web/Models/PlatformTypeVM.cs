using System.Collections.Generic;

namespace GameStore.Web.Models
{
    public class PlatformTypeVm
    {
        public string Type { get; set; }

        public  ICollection<GameVm> Games { get; set; }
    }
}