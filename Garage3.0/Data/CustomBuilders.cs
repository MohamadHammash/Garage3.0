using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage3._0.Data
{
    public  class CustomBuilders : DataSet
    {
        public string GetRegNr()
        {
            var sb = new StringBuilder();

            sb.Append(Random.String2(3, Chars.UpperCase));
            sb.Append(Random.String2(2, Chars.Numbers));
            sb.Append(Random.String2(1, Chars.AlphaNumericUpperCase));
            return sb.ToString();
        }

        public string GetPersonnummer()
        {
            var sb = new StringBuilder();
            sb.Append(RandomDay().ToString("yyyymmdd"));
            sb.Append("-");
            sb.Append(Random.String2(4, Chars.Numbers));
            return sb.ToString();
        }

        DateTime RandomDay()
        {
       var gen = new Random();

            DateTime start = new DateTime(1901, 1, 1);
            int range = (DateTime.Today - start.AddDays(-1)).Days;
            return start.AddDays(gen.Next(range));
        }
        public int GetAge( string personnummer)
        {
             //personnummer = GetPersonnummer();
            var parseYear = int.TryParse(personnummer.Substring(0, 4), out int year);
           
            return year;
        }
    }
}
