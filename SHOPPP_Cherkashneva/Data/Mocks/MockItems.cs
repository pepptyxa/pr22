using MySql.Data.MySqlClient;
using SHOPPP_Cherkashneva.Data.Common;
using SHOPPP_Cherkashneva.Data.Interfaces;
using SHOPPP_Cherkashneva.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace SHOPPP_Cherkashneva.Data.Mocks
{
    public class MockItems : IItems
    {
        public ICategorys ICategory = new MockCategorys();

    public IEnumerable<Items> AllItems
    {
            get
            {
                return new List<Items>()
                {
                    new Items()
                    {
                        Id=1,
                        Name="DEXP MS-70",
                        Description = "Благодаря черному корпусу с лаконичным дизайном микроволновая печь DEXP MS-70 отлично впишется в кухню с любым интерьером. Камера вмещает 20 л и дополняется удобным поворотным столом со стеклянным блюдом диаметром 25.5 см. С эмалированных стенок легко удаляются засохшие частички пищи. Для простоты ухода перед очисткой камеры можно поставить на 1-2 минуты стакан с водой и лимонной кислотой.",
                        Img = "https://c.dns-shop.ru/thumb/st1/fit/500/500/59a87f71c12f41fa3c6ad251a93b7811/b1a761fddbd2197e22bdcf5ee0cd1cfd773ce824ab6ef6eba7411b9a626c50a7.jpg.webp",
                        Price = 3699,
                        Category = ICategory.AllCategorys.Where(x => x.Id == 1).First()
                    },
                    new Items()
                    {
                        Id=2,
                        Name="Philips FC9571/0",
                        Description = "Пылесос Philips FC9571/01 с силой всасывания 410 Вт тщательно собирает мусор, пыль, волосы, шерсть домашних животных с разных напольных покрытий. Благодаря технологии PowerCyclone 7 с аэродинамической конструкцией снижается сопротивление воздуха и создается интенсивный поток в цилиндрической камере. При помощи позиционного регулятора на корпусе мощность всасывания настраивается с учетом типа очищаемого покрытия.",
                        Img = "https://c.dns-shop.ru/thumb/st1/fit/500/500/136b4038b47e99bc7d402801019ca62c/720349ed4ef9a23f306ef5aaa569ae74fbbc84974e1bdf60f3bf65c15412910b.jpg.webp",
                        Price = 8799,
                        Category = ICategory.AllCategorys.Where(x => x.Id == 2).First()
                    }
                };
            }
        }
    }
    public int Add(Items item)
    {
        
    }
}
