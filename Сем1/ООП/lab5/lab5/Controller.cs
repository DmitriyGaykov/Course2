using lab4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    static class Controller
    {
        public static void FindByColor(ref ClassBouquet Bouquet, string Color)
        {
            Color = $"Color [{Color}]";
            var repliedColorFlowers = Bouquet.AllFlowerIn.Where
            (
                el => el.Color.ToString().ToUpper() == Color.ToUpper()
            ).ToArray();
            if (repliedColorFlowers.Length == 0)
            {
                Console.WriteLine("Растения с таким цветом не найдено");
                return;
            }
            else
            {
                foreach (var el in repliedColorFlowers)
                {
                    Console.WriteLine(el.ToString() + " ");
                }
            }
        }

        public static void SortByPrice(ref ClassBouquet Bouquet)
        {
            var currFlowers = new AFlower[Bouquet.AllFlowerIn.Length];
            Array.Copy(Bouquet.AllFlowerIn, currFlowers, Bouquet.AllFlowerIn.Length);

            var tmp = currFlowers.OrderBy(el => el.Price).ToArray();
            Array.Copy(tmp, Bouquet.Flowers, tmp.Length);
        }
    }
}
