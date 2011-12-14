#Simple Tags#

Simple Tags gives you the ability to create HTML elements in a simmilar way to jQuery in .NET.

##Example Usage (C#)##

    IHtmlString homeLink = SimpleTags.Tag("a", new {href= "http://site.com", text= "Visit My Site!"};

*The third param tells SimpleTags that this tag is self-closing*

    IHtmlString logo = SimpleTags.Tag("img", new {src = "images/logo.png", alt = "My Logo", true};

*You can use @class or css to set the class*

    IHtmlString div = SimpleTags.Tag("div", new {css= "content", html= "<strong>some html</string>"});
