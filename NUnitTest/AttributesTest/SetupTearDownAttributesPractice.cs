
using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace SetupTearDownAttributesPractice
{

    [Category("SetupTearDownAttributesTest")]
    public class SetupTearDownAttributesTest
    {
        [SetUp]
        public void Init() { TestContext.WriteLine("SetUp処理");}
        
        [TearDown]
        public void CleanUp() { TestContext.WriteLine("TearDown処理"); }

        [TestCase]
        public void TestA()
        {
            TestContext.WriteLine("A method.");
            Assert.Pass();
        }

        [TestCase]
        public void TestB()
        {
            TestContext.WriteLine("B method.");
            Assert.Pass();
        }
    }

    [Category("SetupTearDownAttributesTest")]
    public class NonSetupTearDownAttributesTest
    {
        [TestCase]
        public void TestC()
        {
            TestContext.WriteLine("C method.");
            Assert.Pass();
        }
    }

    [Category("SetupTearDownAttributesTest")]
    public class SetupTearDownAttributesSubTest : SetupTearDownAttributesTest
    {
        [TestCase]
        public void TestD()
        {
            TestContext.WriteLine("SubClass D method.");
            Assert.Pass();
        }
    }

    [Category("OneTimeSetupSetupTearDownAttributesTest")]
    public class OneTimeSetupTearDownAttributesTest
    {
        private string setupStr;
        private string teardownStr;

        [OneTimeSetUp]
        public void Init() { setupStr = "OneTimeSetUp処理";}
        
        [OneTimeTearDown]
        public void CleanUp() { teardownStr = "OneTimeTearDown処理"; }

        [TestCase]
        public void TestA()
        {
            TestContext.WriteLine($"A method. setupStr={setupStr}, teardownStr={teardownStr}");
            Assert.Pass();
        }

        [TestCase]
        public void TestB()
        {
            TestContext.WriteLine($"B method. setupStr={setupStr}, teardownStr={teardownStr}");
            Assert.Pass();
        }
    }
}


namespace SetUpFixturePractice
{
    
    [SetUpFixture]
    [Category("SetUpFixtureAttributesTest")]
    public class MySetUpClass
    {
        public static Dictionary<string, object> Config = new Dictionary<string, object>();

        public static string SettingKeyA = "setting-A";
        public static string SettingKeyB = "setting-B";
        public static string SettingKeyC = "setting-C";

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            Config.Add(SettingKeyA,"aaa");
            Config.Add(SettingKeyB,"bbb");
            Config.Add(SettingKeyC,"ccc");
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            Config.Clear();
        }
     }

    [Category("SetUpFixtureAttributesTest")]
    public class SetUpFixtureAttributesTestA
    {
        [TestCase]
        public void TestA()
        {
            TestContext.WriteLine($"A method. settings={MySetUpClass.Config[MySetUpClass.SettingKeyA]}");
            Assert.Pass();
        }
    }
    
    [Category("SetUpFixtureAttributesTest")]
    public class SetUpFixtureAttributesTestB
    {
        [TestCase]
        public void TestB()
        {
            TestContext.WriteLine($"B method. settings={MySetUpClass.Config[MySetUpClass.SettingKeyB]}");
            Assert.Pass();
        }
    }
}


namespace AllSetUpTearDownPatternPractice
{
    
    [SetUpFixture]
    [Category("AllSetUpTearDownPattern")]
    public class MySetUpClass
    {
        public static Dictionary<string, object> Config = new Dictionary<string, object>();

        public static string SettingKeyA = "setting-A";
        public static string SettingKeyB = "setting-B";
        public static string SettingKeyC = "setting-C";

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            Config.Add(SettingKeyA,"aaa");
            Config.Add(SettingKeyB,"bbb");
            Config.Add(SettingKeyC,"ccc");
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            Config.Clear();
        }
     }

    [Category("AllSetUpTearDownPattern")]
    public class SetUpFixtureAttributesTestA
    {
        private string setupStr;
        private string teardownStr;

        [OneTimeSetUp]
        public void Init() { setupStr = "OneTimeSetUp処理";}
        
        [OneTimeTearDown]
        public void CleanUp() { teardownStr = "OneTimeTearDown処理"; }

        [SetUp]
        public void InitMethod() { TestContext.WriteLine("SetUp処理");}
        
        [TearDown]
        public void CleanUpMethod() { TestContext.WriteLine("TearDown処理"); }

        [TestCase]
        public void TestA()
        {
            TestContext.WriteLine($"A method. settings={MySetUpClass.Config[MySetUpClass.SettingKeyA]}");
            TestContext.WriteLine($"A method. setupStr={setupStr}, teardownStr={teardownStr}");
            Assert.Pass();
        }
    }
}
