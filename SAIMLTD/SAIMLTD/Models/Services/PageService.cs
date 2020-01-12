using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace SAIMLTD.Models.Services
{
    public class PageService
    {
        public string FormatCapital(double capital)
        {
            NumberFormatInfo nfi = new CultureInfo("fr-FR", false).NumberFormat;
            return capital.ToString("C", nfi);
        }
    }
}