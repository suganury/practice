using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AssetionsTest
{
    public class AssetionsTest
    {

        [TestCase]
        public void messageTest()
        {
            string expected = "hoge";
            string actual = "fuga";
            Assert.AreEqual(expected, actual, $"メッセージが想定と異なります。expected={expected}, actual={actual}");
        }
        
        [TestCase]
        public void TestAreEqual()
        {
            // Test OK.
            string expected = new string("hoge");
            string actual = new string("hoge");
            Assert.AreEqual(expected, actual);
        }
        
        [TestCase]
        public void TestAreSame()
        {
            // Test NG.
            string expected = new string("hoge");
            string actual = new string("hoge");
            Assert.AreSame(expected, actual);
        }
        
        [TestCase]
        public void TestCollections_OK()
        {
            // Test OK.
            string[] args1 = {"りんご", "バナナ", "オレンジ"};
            string[] args2 = {"りんご", "バナナ", "オレンジ"};
            Assert.AreEqual(args1, args2);
            
            // Test OK.
            List<string> list1 = new List<string>(){ "りんご", "バナナ", "オレンジ"};
            List<string> list2 = new List<string>(){ "りんご", "バナナ", "オレンジ"};
            Assert.AreEqual(list1, list2);
            
            // Test OK.
            Assert.AreEqual(args1, list2);

        }
        
        [TestCase]
        public void TestCollections_NG()
        {
            // Test NG.
            string[] args1 = {"りんご", "バナナ", "オレンジ"};
            string[] args2 = {"りんご", "オレンジ", "バナナ"};
            Assert.AreEqual(args1, args2);
        }
        
        public class Target {}
        public class TargetSub : Target {}

        [TestCase]
        public void TestIsInstanceOf()
        {
            // Test OK.
            Assert.IsInstanceOf<Target>(new Target());
            // Test OK.
            Assert.IsInstanceOf<Target>(new TargetSub());
            // Test NG.
            Assert.IsInstanceOf<TargetSub>(new Target());
        }
        
        [TestCase]
        public void TestIsAssignableFrom()
        {
            // Test OK.
            Assert.IsAssignableFrom<TargetSub>(new Target());
            // Test OK.
            Assert.IsAssignableFrom<Target>(new Target());
            // Test NG.
            Assert.IsAssignableFrom<Target>(new TargetSub());
        }
        
        delegate void TestDelegate();

        public class MyException : Exception {}

        public class MyClass {
            public static void TestTargetFunc() { throw new MyException(); }
            public static void NonException() { throw new MyException(); }
        }

        public class MyClass2 {
            public static void ThrowException() { throw new MyException(); }
            public static void NoException() {  }
        }

        public class MyClass3 {
            public static async Task ThrowException() {
                await Task.Delay(100);
                throw new MyException(); 
            }
        }

        [TestCase]
        public void TestThrows()
        {
            // Test OK.
            Assert.Throws<MyException>(() => MyClass.TestTargetFunc());
        }

        [TestCase]
        public void TestThrowsConst()
        {
            // Test OK.
            Assert.Throws(
                Is.TypeOf<Exception>()
                .And.Message.EqualTo("ErrorCode:9999"),
                () => MyClass2.ThrowException()
            );
        }


        [TestCase]
        public void TestThrows2()
        {
            // Test OK.
            Assert.Throws<MyException>(() => MyClass.TestTargetFunc());
            // Test NG.
            Assert.Throws<Exception>(() => MyClass.TestTargetFunc());
        }

        [TestCase]
        public void TestCatch()
        {
            // Test OK.
            Assert.Catch<MyException>(() => MyClass.TestTargetFunc());
            // Test OK.
            Assert.Catch<Exception>(() => MyClass.TestTargetFunc());
        }

        [TestCase]
        public void TestCatch2()
        {
            // Test OK.
            Assert.Catch(() => MyClass2.ThrowException());
            // Test NG.
            Assert.Catch(() => MyClass2.NoException());
        }

        [TestCase]
        public void TestPass()
        {
            Assert.Pass("成功だよ");
        }
        
        [TestCase]
        public void TestFail()
        {
            Assert.Fail("失敗だ！");
        }
        
        [TestCase]
        public void TestIgnore()
        {
            Assert.Ignore("無視するよ");
        }
        
        [TestCase]
        public void TestInconclusive()
        {
            Assert.Inconclusive("このテストは●●だから保留だよ");
        }
    }
}