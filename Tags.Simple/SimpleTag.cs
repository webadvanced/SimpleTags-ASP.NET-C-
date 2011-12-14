using System.Web;

namespace Tags.Simple {
    public static class SimpleTag {
         public static IHtmlString Tag(string tagName) {
             Check.Argument.IsNotNullOrEmpty(tagName, "tagName");
             return Tag(tagName, null, false);
         }
         public static IHtmlString Tag(string tagName, bool isSelfClosing) {
             Check.Argument.IsNotNullOrEmpty(tagName, "tagName");
             return Tag(tagName, null, isSelfClosing);
         }
         public static IHtmlString Tag(string tagName, object htmlAttributes) {
             Check.Argument.IsNotNullOrEmpty(tagName, "tagName");
             Check.Argument.IsNotNull(htmlAttributes, "htmlAttributes");
             return Tag(tagName, htmlAttributes, false);
         }
         public static IHtmlString Tag(string tagName, object htmlAttributes, bool isSelfClosing) {
             Check.Argument.IsNotNullOrEmpty(tagName, "tagName");
             TagBuilder tagBuilder = new TagBuilder(tagName, htmlAttributes ?? new {}, isSelfClosing);
             return tagBuilder.Render();
         }
    }
}