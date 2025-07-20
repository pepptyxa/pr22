using SHOPPP_Cherkashneva.Data.Models;
using System.Collections.Generic;

namespace SHOPPP_Cherkashneva.Data.Interfaces
{
    public interface IItems
    {
        public IEnumerable<Items> AllItems { get; }
    }
}
