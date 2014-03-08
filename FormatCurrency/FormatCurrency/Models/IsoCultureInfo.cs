using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
namespace FormatCurrency.Models
{
    public class IsoCultureInfo
    {
        public int Id { get; set; }
        public string LanguageCultureName { get; set; }
        public string DisplayName { get; set; }
        public string CultureCode { get; set; }
        public string ISO639xValue { get; set; }
    }
}