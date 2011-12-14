using Xunit;
using System;

namespace Tags.Simple.Tests {
    public class CheckTests {
        [Fact]
        public void IsNullShouldThrow_ArgumentNullException_WhenPassedNull() {
            Assert.Throws<ArgumentNullException>(() => Check.Argument.IsNotNull(null, "null"));
        }
        [Fact]
        public void IsNullShouldNotThrow_WhenPassedAnomousObject() {
            Assert.DoesNotThrow(() => Check.Argument.IsNotNull(new {}, "fake object"));
        }
        [Fact]
        public void IsNullOrEmptyShouldThrow_ArgumentNullException_WhenPassedNull() {
            Assert.Throws<ArgumentNullException>(() => Check.Argument.IsNotNullOrEmpty(null, "null"));
        }
        [Fact]
        public void IsNullOrEmptyShouldThrow_ArgumentNullException_WhenPassedEmptyString() {
            Assert.Throws<ArgumentNullException>(() => Check.Argument.IsNotNullOrEmpty(String.Empty, "String.Empty"));
        }
        [Fact]
        public void IsNullShouldNotThrow_WhenPassedFakeString_SystemString() {
            Assert.DoesNotThrow(() => Check.Argument.IsNotNullOrEmpty("fake string", "fake string"));
        }
    }
}