using System;

namespace Tags.Simple {
    public class ContentKey {
        public ContentKey(string key, Func<string, string> func) {
            Check.Argument.IsNotNullOrEmpty(key, "key");
            Check.Argument.IsNotNull(func, "func");
            Key = key;
            Func = func;
        }

        public string Key { get; private set; }
        public Func<string, string> Func { get; private set; }
    }
}