using System.Collections.Generic;
using System.ComponentModel;
using System.Web;

namespace Tags.Simple {
    public static class TagHelpers {
        private static IList<ContentKey> _contentKeys;
        private static IDictionary<string, string> _attributeAlternates;

        static TagHelpers() {
            SetDefaultContentKeys();
            SetDefaulltAttributealternates();
        }

        public static IList<ContentKey> ContentKeys {
            get { return _contentKeys; }
        }

        public static IDictionary<string, string>  AttributeAlternates {
            get { return _attributeAlternates; }
        }

        private static void SetDefaulltAttributealternates() {
            _attributeAlternates = new Dictionary<string, string>
                                   {
                                       {"css", "class"}
                                   };
        }

        private static void SetDefaultContentKeys() {
            _contentKeys = new List<ContentKey>
                           {
                               new ContentKey("text", x => HttpUtility.HtmlEncode(x)),
                               new ContentKey("html", x => x)
                           };
        }

        public static IDictionary<string, object> AnonymousObjectToHtmlAttributes(object htmlAttributes) {
            IDictionary<string, object> result = new Dictionary<string, object>();
            if (htmlAttributes != null) {
                foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(htmlAttributes)) {
                    result.Add(property.Name.Replace('_', '-'), property.GetValue(htmlAttributes));
                }
            }
            return result;
        }
    }
}