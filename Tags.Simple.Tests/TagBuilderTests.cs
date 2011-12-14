using System;
using System.Web;
using Xunit;

namespace Tags.Simple.Tests {
    public class TagBuilderTests {
        [Fact]
        public void ShouldThrow_WhenCreateNewInstance_WithStringEmptyAsTagType() {
            Assert.Throws<ArgumentNullException>(() => new TagBuilder(string.Empty, new {}, default(bool)));
        }

        [Fact]
        public void ShouldThrow_WhenCreateNewInstance_WithNullAsTagType() {
            Assert.Throws<ArgumentNullException>(() => new TagBuilder(null, new {}, default(bool)));
        }

        [Fact]
        public void ShouldThrow_WhenCreateNewInstance_WithNullHtmlAttributes() {
            Assert.Throws<ArgumentNullException>(() => new TagBuilder("fakeTag", null, default(bool)));
        }

        [Fact]
        public void ShouldBeAbleTo_CreateNewInstance_WithValidTagType() {
            IHtmlString tag = new TagBuilder("a", new {}, false).Render();
            Assert.NotNull(tag);
        }

        [Fact]
        public void
            RenderShouldBuild_EmptyAnchorTagWithClosingTag_WhenPassedTheLetterA_WithNoHtmlAttributesAndSelfClosingFalse() {
            string actual = new TagBuilder("a", new {}, false).Render().ToString();
            string expected = new HtmlString("<a></a>").ToString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void
            RenderShouldBuild_AnchorTagWithClosingTagAndAttributes_WhenPassedTheLetterA_WithHtmlAttributesAndSelfClosingFalse() {
            string actual = new TagBuilder("a", new
                                                {
                                                    href = "http://asp.net",
                                                    text = "Click Me!",
                                                    css = "fake-class"
                                                }, false).Render().ToString();
            string expected = new HtmlString("<a href=\"http://asp.net\" class=\"fake-class\">Click Me!</a>").ToString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RenderShouldBuild_ImageTagWithOutClosingTag_WhenPassedStringImg_WithSelfClosingTrue() {
            string actual = new TagBuilder("img", new
                                                  {
                                                      src = "../fake-image.png",
                                                      alt = "fake image"
                                                  }, true).Render().ToString();
            string expected = "<img src=\"../fake-image.png\" alt=\"fake image\" />";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldBeAbleTo_NestTags() {
            string actual = new TagBuilder("div", new
                                                  {
                                                      html = new TagBuilder("img", new {
                                                          src = "../fake-image.png",
                                                          alt = "fake image"
                                                      }, true).Render().ToString()
                                                  }, false).Render().ToString();
            string expected = "<div><img src=\"../fake-image.png\" alt=\"fake image\" /></div>";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldBeAbleToEncodeHtmlContent_ByUsingTextKeyWord() {
            string actual = new TagBuilder("div", new {text = "<script>alert('this should be encoded')</script>"}, false).Render().ToString();
            string expected = "<div>&lt;script&gt;alert(&#39;this should be encoded&#39;)&lt;/script&gt;</div>";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldBeAbleToReturnHtmlContent_ByUsingHtmlKeyWord() {
            string actual = new TagBuilder("div", new { html = "<script>alert('this should be encoded')</script>" }, false).Render().ToString();
            string expected = "<div><script>alert('this should be encoded')</script></div>";
            Assert.Equal(expected, actual);
        }
    }
}