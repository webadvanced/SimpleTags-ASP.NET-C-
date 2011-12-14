#Simple Tags#

Simple Tags gives you the ability to create HTML elements in a simmilar way to jQuery in .NET.

##Example Usage (C#)##

    var homeLink = SimpleTags.Tag("a", new {href= "http://site.com", text= "Visit My Site!"};

//The third param tells SimpleTags the this tag is self-closing
    var logo = SimpleTags.Tag("img", new {src = "images/logo.png", alt = "My Logo", true};

//You can user @class or css to set the class
    var div = SimpleTags.Tag("div", new {css= "content", html= "<strong>some html</string>"});
