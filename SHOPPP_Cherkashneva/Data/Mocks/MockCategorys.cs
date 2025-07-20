using SHOPPP_Cherkashneva.Data.Interfaces;
using SHOPPP_Cherkashneva.Data.Models;
using System.Collections.Generic;

namespace SHOPPP_Cherkashneva.Data.Mocks
{
    public class MockCategorys : ICategorys
    {
        IEnumerable<Categorys> ICategorys.AllCategorys
        {
            get
            {
                return new List<Categorys>()
                {
                    new Categorys() {
                        Id = 1,
                        Name = "Микроволновые печи",
                        Description = "Описание"
                    },
                    new Categorys() {
                        Id = 2,
                        Name = "Пылесосы",
                        Description = "Описание"
                    }
                };
            }
        }
    }
}
