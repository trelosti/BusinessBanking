using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessBanking.DAL.Util
{
    public class CsvReader
    {
        private static readonly string _pathToCurrencies = $"{Directory.GetCurrentDirectory()}{@"\File\currencies.csv"}";

        public static List<string[]> ReadCurrencies()
        {
            List<string[]> result = new List<string[]>();
            using (StreamReader reader = new StreamReader(_pathToCurrencies, Encoding.UTF8))
            {
                using (CsvParser csv = new CsvParser(reader, CultureInfo.InvariantCulture))
                {
                    while (csv.Read())
                    {
                        result.Add(new string[]
                        {
                            csv.Context.Parser.Record[0],
                            csv.Context.Parser.Record[1],
                            csv.Context.Parser.Record[2].Trim(),
                        });
                    }
                }
            }

            return result;
        }
    }
}
