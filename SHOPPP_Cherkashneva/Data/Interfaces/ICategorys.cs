using SHOPPP_Cherkashneva.Data.Models;
using System.Collections.Generic;

namespace SHOPPP_Cherkashneva.Data.Interfaces
{
    public interface ICategorys
    {
        public IEnumerable<Categorys> AllCategorys { get; }
    }
}
