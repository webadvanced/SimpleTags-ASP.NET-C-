using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Tags.Simple {
    public class TagBuilder {
        private readonly IDictionary<string, object> _htmlAttributes;
        private readonly bool _selfClosing;
        private readonly string _tagType;

        public TagBuilder(string tagType, object htmlAttributes, bool selfClosing) {
            Check.Argument.IsNotNullOrEmpty(tagType, "tagType");
            Check.Argument.IsNotNull(htmlAttributes, "htmlAttributes");
            _tagType = tagType;
            _htmlAttributes = TagHelpers.AnonymousObjectToHtmlAttributes(htmlAttributes);
            _selfClosing = selfClosing;
        }

        public IHtmlString Render() {
            var sb = new StringBuilder();
            sb.Append('<')
                .Append(_tagType);
            AppendAttributesAndContent(sb);
            sb.Append(_selfClosing ? " />" : String.Format("</{0}>", _tagType));
            return new HtmlString(sb.ToString());
        }

        public override string ToString() {
            return _tagType;
        }

        private void AppendAttributesAndContent(StringBuilder sb) {
            string content = string.Empty;
            foreach (var attribute in _htmlAttributes) {
                string key = attribute.Key;
                if ((String.Equals(key, "id", StringComparison.Ordinal) && String.IsNullOrEmpty((string) attribute.Value))) { 
                    continue;
                }
                if(TagHelpers.ContentKeys.Any(x => x.Key == key)) {
                    var contentKey = TagHelpers.ContentKeys.FirstOrDefault(x => x.Key == key);
                    if(contentKey != null) {
                        content += contentKey.Func((string)attribute.Value);
                    }
                    
                    continue;
                }
                string alternateKey;
                TagHelpers.AttributeAlternates.TryGetValue(key, out alternateKey);
                string value = HttpUtility.HtmlAttributeEncode((string) attribute.Value);
                sb.Append(' ')
                    .Append( alternateKey ?? key)
                    .Append("=\"")
                    .Append(value)
                    .Append('"');
            }
            if(!_selfClosing) {
                sb.Append('>')
                    .Append(content);    
            }
        }
    }
}