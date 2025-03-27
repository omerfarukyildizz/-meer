 using Pbk.Entities.EditorRepositories;
using Pbk.Entities.Editors;
using Pbk.Entities.Models;
using Pbk.Entities.Repositories;
using Pbk.Entities.Views;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Pbk.Core.Utilities.Uniq
{
    public static class Regex_Helper
    {
        public static string ConvertTurkishToEnglish(string input)
        {
            Dictionary<char, char> turkishToEnglish = new Dictionary<char, char>()
        {
            { 'ı', 'I' }, { 'ğ', 'G' }, { 'ü', 'U' }, { 'ş', 'S' }, { 'ö', 'O' }, { 'ç', 'C' },
            { 'İ', 'I' }, { 'Ğ', 'G' }, { 'Ü', 'U' }, { 'Ş', 'S' }, { 'Ö', 'O' }, { 'Ç', 'C' }
        };

            string result = string.Empty;
            foreach (char c in input)
            {
                if (turkishToEnglish.ContainsKey(c))
                {
                    result += turkishToEnglish[c];
                }
                else
                {
                    result += char.ToUpper(c, CultureInfo.InvariantCulture);
                }
            }
            return result;
        }
        public static bool IsNumber(string text)
        {
            Regex regex = new Regex(@"^[0-9]+$");
            return regex.IsMatch(text);
        }

        public static int ConvertInt(string text)
        {
            Regex regex = new Regex(@"^[0-9]+$");
            Match match = regex.Match(text);

            if (match.Success)
            {
                string numberString = match.Value;
                if (int.TryParse(numberString, out int result))
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }

        }
    }
}
