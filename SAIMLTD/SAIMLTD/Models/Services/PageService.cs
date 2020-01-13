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

        public string MakePagination(int affichage, int nombre, int page_actuel, string url)
        {
            if (nombre == 0)
            {
                return "";
            }
            else
            {
                string tab_index = "tabindex='-1'";
                string numero_pagination_dom = "";
                string prev_dom = "";
                string next_dom = "";
                string class_li = "page-item";
                string class_a = "page-link";
                string active = " active";
                string disabled = " disabled";
                int nombre_de_page = Convert.ToInt32(nombre / affichage);
                string class_prev = class_li;
                string href_prev = url + "" + (page_actuel - 1);
                string attribute = "";
                string href = "href = '" + href_prev + "'";
                if (page_actuel <= 1) { class_prev = class_prev + "" + disabled; attribute = tab_index; href = ""; }
                prev_dom = "<li class='" + class_prev + "'>" +
                                "<a class='" + class_a + "' " + href + " " + attribute + " aria-label='Previous'>" +
                                    "<span aria-hidden='true'>&laquo;</span>" +
                                    "<span class='sr-only'>Previous</span>" +
                                "</a>" +
                            "</li>";
                if (nombre <= affichage)
                {
                    var li = "<li class='" + class_li + active + "'><a class='" + class_a + "' href='" + url + "1'>1</a></li>";
                    numero_pagination_dom = li;
                }
                if (nombre > affichage)
                {
                    numero_pagination_dom = "";
                    if ((nombre % affichage) != 0) nombre_de_page++;
                    if ((nombre_de_page) <= 5)
                    {
                        for (var i = 1; i <= nombre_de_page; i++)
                        {
                            var class_liste = class_li;
                            if (i == page_actuel) class_liste = class_liste + "" + active;
                            var li = "<li class='" + class_liste + "'><a class='" + class_a + "' href='" + url + "" + i + "'>" + i + "</a></li>";
                            numero_pagination_dom = numero_pagination_dom + "" + li;
                        }
                    }
                    if ((nombre_de_page) > 5)
                    {
                        if (IsLastTwoOrFirstTwo(page_actuel, nombre_de_page))
                        {
                            string[] numpage = { "1", "2", "...", (nombre_de_page - 1) + "", "" + nombre_de_page };
                            string[] class_num = { class_li, class_li, class_li + "" + disabled, class_li, class_li };
                            for (int i = 0; i < numpage.Length; i++)
                            {
                                string classe = class_num[i];
                                attribute = "";
                                href = "href='" + url + numpage[i] + "'";
                                if (class_num[i].Contains("disabled")) { attribute = tab_index; href = ""; }
                                if (numpage[i].Equals(page_actuel.ToString())) classe = classe + "" + active;
                                var li = "<li class='" + classe + "'><a class='" + class_a + "' " + attribute + " " + href + ">" + numpage[i] + "</a></li>";
                                numero_pagination_dom = numero_pagination_dom + "" + li;
                            }
                        }
                        else
                        {
                            string[] numpage = { "1", "...", "" + page_actuel, "...", "" + nombre_de_page };
                            string[] class_num = { class_li, class_li + "" + disabled, class_li + "" + active, class_li + "" + disabled, class_li };
                            for (int i = 0; i < numpage.Length; i++)
                            {
                                string classe = class_num[i];
                                href = "href='" + url + numpage[i] + "'";
                                if (class_num[i].Contains("disabled")) { href = ""; }
                                string li = "<li class='" + classe + "'><a class='" + class_a + "' " + href + ">" + numpage[i] + "</a></li>";
                                numero_pagination_dom = numero_pagination_dom + "" + li;
                            }
                        }
                    }
                }
                string class_next = "page-item";
                string href_next = url + "" + (page_actuel + 1);
                attribute = "";
                href = "href = '" + href_next + "'";
                if ((page_actuel) >= (nombre_de_page)) { class_next = "page-item disabled"; attribute = tab_index; href = ""; }
                next_dom = "<li class='" + class_next + "'>" +
                                "<a class='" + class_a + "' " + attribute + " " + href + ">" +
                                    "<span aria-hidden='true'>&raquo;</span>" +
                                    "<span class='sr-only'>Next</span>" +
                                "</a>" +
                            "</li>";
                return prev_dom + numero_pagination_dom + next_dom;
            }
        }
        public bool IsLastTwoOrFirstTwo(int current_page, int number_of_page)
        {
            bool isLastTwoOrFirstTwo = false;
            if (current_page <= 2 || Math.Abs(number_of_page - current_page) <= 1) isLastTwoOrFirstTwo = true;
            return isLastTwoOrFirstTwo;
        }
    }
}