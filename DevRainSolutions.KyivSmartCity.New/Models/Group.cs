using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using WebGrease.Css.Extensions;

namespace DevRainSolutions.KyivSmartCity.New.Models
{
    public static class Recaptcha
    {
        public const string SiteKey = "6LfVeQkTAAAAAGOokhrTa3BXmlg957l-vq1Ssnvc";
        public const string SecretKey = "6LfVeQkTAAAAAO1T0RDmBQLmNSxmL7G2UJ5qPreD";
    }


    public static class PasswordForExtensions
    {
        public static MvcHtmlString PasswordPlaceHolderFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlAttributes)
        {
            var dict = new RouteValueDictionary(htmlAttributes);
            return html.PasswordPlaceHolderFor(expression, dict);
        }
        public static MvcHtmlString PasswordPlaceHolderFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            var htmlAttributes = new Dictionary<string, object>();
            return html.PasswordPlaceHolderFor(expression, htmlAttributes);
        }

        public static MvcHtmlString PasswordPlaceHolderFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);

            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();

            if (!String.IsNullOrEmpty(labelText))
            {
                if (htmlAttributes == null)
                {
                    htmlAttributes = new Dictionary<string, object>();
                }

                if (metadata.IsRequired)
                {
                    labelText += " *";
                }

                htmlAttributes.Add("placeholder", labelText);
            }

            return html.PasswordFor(expression, htmlAttributes);
        }

    }



    public static class TextAreaForExtensions
    {
        public static MvcHtmlString TextAreaPlaceHolderFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlAttributes)
        {
            var dict = new RouteValueDictionary(htmlAttributes);
            return html.TextAreaPlaceHolderFor(expression, dict);
        }
        public static MvcHtmlString TextAreaPlaceHolderFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            var htmlAttributes = new Dictionary<string, object>();
            return html.TextAreaPlaceHolderFor(expression, htmlAttributes);
        }

        public static MvcHtmlString TextAreaPlaceHolderFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);

            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string labelText = metadata.DisplayName
                ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();

            if (!String.IsNullOrEmpty(labelText))
            {
                if (htmlAttributes == null)
                {
                    htmlAttributes = new Dictionary<string, object>();
                }

                if (metadata.IsRequired)
                {
                    labelText += " *";
                }

                htmlAttributes.Add("placeholder", labelText);
            }

            return html.TextAreaFor(expression, htmlAttributes);
        }

    }
    public static class SpamProtectionExtensions
    {
        /// <summary>
        /// Create a hidden field containing the 'SpamProtectionTimeStamp'.
        /// </summary>
        /// <param name="helper">The <see cref="HtmlHelper"/>.</param>
        /// <returns>The hidden field containing the 'SpamProtectionTimeStamp'.</returns>
        public static IHtmlString SpamProtectionTimeStamp(this HtmlHelper helper)
        {
            var builder1 = new TagBuilder("input");
            builder1.MergeAttribute("name", "SpamProtectionTimeStamp");
            builder1.MergeAttribute("type", "hidden");
            builder1.MergeAttribute("value", ((long)(DateTime.Now - new DateTime(1970, 1, 1)).TotalSeconds).ToString());

            var builder2 = new TagBuilder("input");
            builder2.MergeAttribute("name", "website");
            builder2.MergeAttribute("type", "text");
            builder2.MergeAttribute("style", "display:inline;height:1px;left:-10000px;overflow:hidden;position:absolute;width:1px;");
            builder2.MergeAttribute("value", string.Empty);
            return MvcHtmlString.Create(builder1.ToString(TagRenderMode.SelfClosing) + builder2.ToString(TagRenderMode.SelfClosing));
        }
    }

    public static class DataSets
    {
        public static string Age(this DateTime bday)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - bday.Year;

            if (age == 0)
            {
                return string.Format("{0} міс.", today.Month - bday.Month);
            }


            if (bday > today.AddYears(-age)) age--;
            return string.Format("{0} років", age);
        }



        public static string ToRelative2(this DateTimeOffset yourDate)
        {
            return yourDate.LocalDateTime.ToString("dd.MM.yyyy HH:mm");
        }

        public static string ToRelative2(this DateTime yourDate)
        {
            //return yourDate.ToString("dd.MM.yyyy HH:mm");
            return yourDate.ToString("yyyy-MM-dd HH:mm");
        }



        public static string ToRelative(this DateTimeOffset yourDate)
        {
            return ToRelative(yourDate.DateTime);
        }

        public static string ToRelative(this DateTime yourDate)
        {
            const int SECOND = 1;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            const int MONTH = 30 * DAY;

            var ts = new TimeSpan(DateTime.Now.ToLocalTime().Ticks - yourDate.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 0)
            {
                return "not yet";
            }
            if (delta < 1 * MINUTE)
            {
                return ts.Seconds == 1 ? "секунду назад" : ts.Seconds + " секунд назад";
            }
            if (delta < 2 * MINUTE)
            {
                return "хвилину назад";
            }
            if (delta < 45 * MINUTE)
            {
                return ts.Minutes + " хвилин назад";
            }
            if (delta < 90 * MINUTE)
            {
                return "годину назад";
            }
            if (delta < 24 * HOUR)
            {
                return ts.Hours + " годин назад";
            }
            if (delta < 48 * HOUR)
            {
                return "вчора";
            }
            if (delta < 30 * DAY)
            {
                return ts.Days + " днів назад";
            }
            if (delta < 12 * MONTH)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "місяць назад" : months + " місяців назад";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                return years <= 1 ? "рік назад" : years + " років назад";
            }
        }

        public static string SummaryNoHtml(this string text, int length = 200)
        {
            return Summary(NoHtml(text), length);
        }

        public static string Summary(this string text, int length = 200)
        {
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;

            return text.Length > length ? text.Substring(0, length) + "..." : text;
        }


        public static string NoHtml(this string html)
        {
            string noHtml = Regex.Replace(html, @"<[^>]+>|&nbsp;", "").Trim();
            return Regex.Replace(noHtml, @"\s{2,}", " ");
        }


        /*
        public static List<BaseItem> WorkTypes
        {
            get
            {
                return new List<BaseItem>
            {
                new BaseItem { Id =1, Name = "Створення стратегії Kyiv Smart City Strategy" },
                new BaseItem { Id =2, Name = "Робота з вендорами, системними інтеграторами" },
                new BaseItem { Id =3, Name = "Робота з ІТ-спільнотою для розробки міських сервісів" },
                new BaseItem { Id =4, Name = "Школа Smart City Kyiv" },

           

            };
            }
        }
*/



    }

    public class Group
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Title { get; set; }

        [Required]
        [StringLength(600)]
        public string Description { get; set; }

        [Required]
        [UIHint("HtmlEditor"), AllowHtml]
        public string Body { get; set; }

        public virtual ICollection<Expert> Experts { get; set; }

        public virtual ICollection<Document> Documents { get; set; }

        public int TeamMemberId { get; set; }

        public virtual TeamMember TeamMember { get; set; }
    }
}
