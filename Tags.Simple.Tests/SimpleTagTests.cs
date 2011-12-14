using System.Web;
using Xunit;

namespace Tags.Simple.Tests {
    public class SimpleTagTests {
        [Fact]
        public void ShouldReturnType_AddinableFrom_IHtmlString() {
            IHtmlString tagHtml = SimpleTag.Tag("a");
            Assert.IsAssignableFrom<IHtmlString>(tagHtml);
        }

        [Fact]
        public void ShouldBeAbleTo_CreateTagWithJust_TagNameArgument() {
            IHtmlString tagHtml = SimpleTag.Tag("a");
            Assert.Equal("<a></a>", tagHtml.ToString());
        }

        [Fact]
        public void IsSelfClosing_ShouldBeFalse_ByDefault() {
            IHtmlString tagHtml1 = SimpleTag.Tag("div");
            IHtmlString tagHtml2 = SimpleTag.Tag("div", new {});
            Assert.True(tagHtml1.ToString().Contains("</div>"));
            Assert.True(tagHtml2.ToString().Contains("</div>"));
        }

        [Fact]
        public void ShouldBeAbleToSet_IsSelfClosing() {
            IHtmlString tagHtml1 = SimpleTag.Tag("input", true);
            IHtmlString tagHtml2 = SimpleTag.Tag("input", new {type = "text"}, true);
            Assert.True(tagHtml1.ToString().Contains(" />"));
            Assert.True(tagHtml2.ToString().Contains(" />"));
        }

        [Fact]
        public void ShouldBeAbleToDefine_CusomHtmlAttributes() {
            IHtmlString tagHtml1 = SimpleTag.Tag("input", new {type = "submit", value = "GO!"}, true);
            IHtmlString tagHtml2 = SimpleTag.Tag("input", new {type = "text", disabled = "disabled"}, true);

            string expected1 = "<input type=\"submit\" value=\"GO!\" />";
            string expected2 = "<input type=\"text\" disabled=\"disabled\" />";

            Assert.Equal(expected1, tagHtml1.ToString());
            Assert.Equal(expected2, tagHtml2.ToString());
        }
    }
}