using SHOPPP_Cherkashneva.Data.Models;
using System.Collections;
using System.Collections.Generic;

namespace SHOPPP_Cherkashneva.Data.ViewModell
{
    public class VMItems
    {
        public IEnumerable<Items> Items { get; set; }
        public IEnumerable<Categorys> Categorys { get; set; }
        public int SelectCategory {  get; set; }

    }
}
