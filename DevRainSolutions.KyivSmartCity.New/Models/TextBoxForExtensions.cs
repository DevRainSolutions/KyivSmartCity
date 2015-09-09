using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace DevRainSolutions.KyivSmartCity.New.Models
{
    /// <summary>
    /// http://mvcdiary.com/2012/09/28/create-a-custom-htmlhelper-textboxfor-to-display-label-text-as-placeholder-integrated-with-twitter-bootstrap/
    /// </summary>
    public static class TextBoxForExtensions
    {
        public static MvcHtmlString TextBoxPlaceHolderFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlAttributes)
        {
            var dict = new RouteValueDictionary(htmlAttributes);
            return html.TextBoxPlaceHolderFor(expression, dict);
        }
        public static MvcHtmlString TextBoxPlaceHolderFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            var htmlAttributes = new Dictionary<string, object>();
            return html.TextBoxPlaceHolderFor(expression, htmlAttributes);
        }

        public static MvcHtmlString TextBoxPlaceHolderFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes)
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

            return html.TextBoxFor(expression, htmlAttributes);
        }

    }
}