using ServiceStack.DataAnnotations;
using System;

namespace IEscolaEntity.Models.Helps
{
    [EnumAsInt]
    public enum Anos
    {
        [System.ComponentModel.Description("2019")]
        ANO2019 = 0,

        [System.ComponentModel.Description("2020")]
        ANO2020 = 1,

        [System.ComponentModel.Description("2021")]
        ANO2021 = 2,

        [System.ComponentModel.Description("2022")]
        ANO2022 = 3,

        [System.ComponentModel.Description("2023")]
        ANO2023 = 4,

        [System.ComponentModel.Description("2024")]
        ANO2024 = 5,

        [System.ComponentModel.Description("2025")]
        ANO2025 = 6,

        [System.ComponentModel.Description("2026")]
        ANO2026 = 7,

        [System.ComponentModel.Description("2027")]
        ANO2027 = 8,

        [System.ComponentModel.Description("2028")]
        ANO2028 = 9,

        [System.ComponentModel.Description("2029")]
        ANO2029 = 10,

        [System.ComponentModel.Description("2030")]
        ANO2030 = 11,

        [System.ComponentModel.Description("2031")]
        ANO2031 = 12,

        [System.ComponentModel.Description("2032")]
        ANO2032 = 13,

        [System.ComponentModel.Description("2033")]
        ANO2033 = 14,

        [System.ComponentModel.Description("2034")]
        ANO2034 = 15,
    }

    public class AnosBuscar
    {
        public static int GetAno(object data)
        {
            var t = Enum.GetValues(typeof(Anos));

            int count = 0;

            foreach (var item in t)
            {
                if (item.Equals(data))
                {
                    if (count == 0)
                        return 2019;

                    else if (count == 1)
                        return 2020;

                    else if (count == 2)
                        return 2021;

                    else if (count == 3)
                        return 2022;

                    else if (count == 4)
                        return 2023;

                    else if (count == 5)
                        return 2024;

                    else if (count == 6)
                        return 2025;

                    else if (count == 7)
                        return 2026;

                    else if (count == 8)
                        return 2027;

                    else if (count == 9)
                        return 2028;

                    else if (count == 10)
                        return 2029;

                    else if (count == 11)
                        return 2030;

                    else if (count == 12)
                        return 2031;

                    else if (count == 13)
                        return 2032;

                    else if (count == 14)
                        return 2033;
                    else
                        return 2034;
                }
                count++;
            }
            return DateTime.Now.Year;
        }
    }
}
