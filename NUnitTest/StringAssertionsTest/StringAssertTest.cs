using NUnit.Framework;

namespace AssetionsTest
{
    public class StringAssertTest
    {
        [TestCase("hoge", "aaahogeaaa")]// Test OK.
        [TestCase("hoge", "aaahogaaa")]// Test NG.
        [TestCase("hoge", "aaaHOGEaaa")]// Test NG.
        public void ContainsTest(string expected, string actual)
        {
            StringAssert.Contains(expected, actual);
        }
        
        [TestCase("hoge", "aaahogeaaa")]// Test NG.
        [TestCase("hoge", "aaahogaaa")]// Test OK.
        [TestCase("hoge", "aaaHOGEaaa")]// Test OK.
        public void DoesNotContainTest(string expected, string actual)
        {
            StringAssert.DoesNotContain(expected, actual);
        }
        
        [TestCase("hoge", "hogeaaa")]// Test OK.
        [TestCase("hoge", "hogaaa")]// Test NG.
        [TestCase("hoge", "HOGEaaa")]// Test NG.
        public void StartsWithTest(string expected, string actual)
        {
            StringAssert.StartsWith(expected, actual);
        }
        
        [TestCase("hoge", "hogeaaa")]// Test NG.
        [TestCase("hoge", "hogaaa")]// Test OK.
        [TestCase("hoge", "HOGEaaa")]// Test OK.
        public void DoesNotStartWithTest(string expected, string actual)
        {
            StringAssert.DoesNotStartWith(expected, actual);
        }
        
        [TestCase("hoge", "aaahoge")]// Test OK.
        [TestCase("hoge", "aaahog")]// Test NG.
        [TestCase("hoge", "aaaHOGE")]// Test NG.
        public void EndsWithTest(string expected, string actual)
        {
            StringAssert.EndsWith(expected, actual);
        }
        
        [TestCase("hoge", "aaahoge")]// Test NG.
        [TestCase("hoge", "aaahog")]// Test OK.
        [TestCase("hoge", "aaaHOGE")]// Test OK.
        public void DoesNotEndWithTest(string expected, string actual)
        {
            StringAssert.DoesNotEndWith(expected, actual);
        }
        
        [TestCase("hoge", "HOGE")]// Test OK.
        [TestCase("hoge", "Hoge")]// Test OK.
        [TestCase("hoge", "HOG")]// Test NG.
        [TestCase("hoge", "ｈｏｇｅ")]// Test NG.
        public void AreEqualIgnoringCaseTest(string expected, string actual)
        {
            StringAssert.AreEqualIgnoringCase(expected, actual);
        }
        
        [TestCase("hoge", "HOGE")]// Test NG.
        [TestCase("hoge", "Hoge")]// Test NG.
        [TestCase("hoge", "HOG")]// Test OK.
        [TestCase("hoge", "ｈｏｇｅ")]// Test OK.
        public void AreNotEqualIgnoringCaseTest(string expected, string actual)
        {
            StringAssert.AreNotEqualIgnoringCase(expected, actual);
        }
        
        [TestCase("^[0-9]{3}hoge[A-Z]{3}$", "123hogeABC")]// Test OK.
        [TestCase("[0-9]*", "hoge123hoge")]// Test OK.
        [TestCase("^[0-9]{3}hoge[A-Z]{3}$", "ABChoge123")]// Test NG.
        public void IsMatchTest(string regexPattern, string actual)
        {
            StringAssert.IsMatch(regexPattern, actual);
        }
        
        [TestCase("^[0-9]{3}hoge[A-Z]{3}$", "123hogeABC")]// Test NG.
        [TestCase("[0-9]*", "hoge123hoge")]// Test NG.
        [TestCase("^[0-9]{3}hoge[A-Z]{3}$", "ABChoge123")]// Test OK.
        public void DoesNotMatchTest(string regexPattern, string actual)
        {
            StringAssert.DoesNotMatch(regexPattern, actual);
        }
        
    }
}