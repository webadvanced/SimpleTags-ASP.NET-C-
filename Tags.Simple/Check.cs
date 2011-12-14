using System;

namespace Tags.Simple {
    public static class Check {
        #region Nested type: Argument

        public static class Argument {
            public static void IsNotNull(object parameter, string parameterName) {
                if (parameter == null) {
                    throw new ArgumentNullException(parameterName, String.Format("{0} cannot be null.", parameterName));
                }
            }

            public static void IsNotNullOrEmpty(string parameter, string parameterName) {
                if (string.IsNullOrEmpty(parameter)) {
                    throw new ArgumentNullException(parameterName, String.Format("{0} cannot be null or empty.", parameterName));
                }
            }
        }

        #endregion
    }
}