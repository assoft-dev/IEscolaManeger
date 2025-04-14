using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEscolaEntity.Models.Helps
{

    [EnumAsInt]
    public enum Meses
    {
        JANEIRO = 0,
        FEVEREIRO = 2,
        MARCO = 3,
        ABRIL = 4,
        MAIO = 5,
        JULHO = 6,
        JUNHO = 7,
        AGOSTO = 8,
        SETEMBRO = 9,
        OUTUBRO = 10,
        NOVEMBRO = 11,
        DEZEMBRO = 12,
    }

    public class MesesBuscar
    {
        public static int Get(Meses data)
        {
            var t = Enum.GetValues(typeof(Anos));

            int count = 0;

            foreach (var item in t)
            {
                if (item.Equals(data))
                {
                    if (count == 0)
                        return 1;

                    else if (count == 1)
                        return 2;

                    else if (count == 2)
                        return 3;

                    else if (count == 3)
                        return 4;

                    else if (count == 4)
                        return 5;

                    else if (count == 5)
                        return 6;

                    else if (count == 6)
                        return 7;

                    else if (count == 7)
                        return 8;

                    else if (count == 8)
                        return 9;

                    else if (count == 9)
                        return 10;

                    else if (count == 10)
                        return 11;
                    else
                        return 12;
                }
                count++;
            }
            return DateTime.Now.Month;
        }
    }
}
