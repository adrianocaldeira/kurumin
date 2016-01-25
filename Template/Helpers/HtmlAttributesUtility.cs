using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Template.Helpers
{
    internal static class HtmlAttributesUtility
    {
        public static IDictionary<string, object> ObjectToHtmlAttributesDictionary(object htmlAttributes)
        {
            if (htmlAttributes == null)
            {
                return new Dictionary<string, object>();
            }

            return htmlAttributes as IDictionary<string, object> ?? 
                   HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
        }

        public static void AddMaxLengthAttribute<TModel, TProperty>(this IDictionary<string, object> attributes, 
            Expression<Func<TModel, TProperty>> expression, int? maximumLength = null)
        {
            var member = expression.Body as MemberExpression;
            var maximum = maximumLength;

            if (member != null)
            {
                var stringLengthAttribute = member.Member.GetCustomAttributes(typeof(StringLengthAttribute), false).FirstOrDefault() as StringLengthAttribute;

                if (stringLengthAttribute != null)
                {
                    maximum = stringLengthAttribute.MaximumLength;
                }
            }

            if (!attributes.ContainsKey("maxlength") && maximum.HasValue)
            {
                attributes.Add("maxlength", maximum);    
            }
        }
    }
}