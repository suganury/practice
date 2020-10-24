using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace AssertionsTest
{
    public class Target {}
    public class TargetSub : Target {}

    public class CollectionAssertTest
    {

        [TestCase]
        public void AllItemsAreInstancesOfTypeTest()
        {
            // Test OK.
            CollectionAssert.AllItemsAreInstancesOfType(
                new ArrayList() {"hoge", "fuga", "hage"}, Type.GetType("System.String"));

            // Test NG.
            CollectionAssert.AllItemsAreInstancesOfType(
                new ArrayList() {"hoge", "fuga", new Target()}, Type.GetType("System.String"));

            // Test OK.
            CollectionAssert.AllItemsAreInstancesOfType(
                new ArrayList() {new Target(), new Target(), new TargetSub()}, Type.GetType("AssetionsTest.Target"));
        }
        
        [TestCase]
        public void AllItemsAreNotNullTest()
        {
            // Test OK.
            CollectionAssert.AllItemsAreNotNull(
                new List<string>() {"hoge", "fuga", "hage"});

            // Test NG.
            CollectionAssert.AllItemsAreNotNull(
                new List<string>() {"hoge", null, "hage"});
                
            // Test OK.
            CollectionAssert.AllItemsAreNotNull(
                new List<string>() {});
        }
        
        [TestCase]
        public void AllItemsAreUniqueTest()
        {
            // Test OK.
            CollectionAssert.AllItemsAreUnique(
                new List<string>() {"hoge", "fuga", "hage"});

            // Test NG.
            CollectionAssert.AllItemsAreUnique(
                new List<string>() {"hoge", "hoge", "hage"});

            // Test OK.
            CollectionAssert.AllItemsAreUnique(
                new List<string>() {"hoge", null, "hage"});

            // Test NG.
            CollectionAssert.AllItemsAreUnique(
                new List<string>() {new String("hoge"), new String("hoge"), new String("hage")});

        }
        
        [TestCase]
        public void AreEqualTest()
        {
            // Test OK.
            CollectionAssert.AreEqual(
                new List<string>() {"hoge", "fuga", "hage"},
                new List<string>() {"hoge", "fuga", "hage"});

            // Test NG.
            CollectionAssert.AreEqual(
                new List<string>() {"hoge", "fuga", "hage"},
                new List<string>() {"hoge", "hoge", "hage"});

            // Test NG.
            CollectionAssert.AreEqual(
                new List<string>() {"hoge", "fuga", "hage"},
                new List<string>() {"fuga", "hoge", "hage"});

            // Test OK.
            CollectionAssert.AreEqual(
                new List<string>() {"hoge", "fuga", "hage"},
                new List<string>() {new String("hoge"), new String("fuga"), new String("hage")});

        }
        
        [TestCase]
        public void AreNotEqualTest()
        {
            // Test NG.
            CollectionAssert.AreNotEqual(
                new List<string>() {"hoge", "fuga", "hage"},
                new List<string>() {"hoge", "fuga", "hage"});

            // Test OK.
            CollectionAssert.AreNotEqual(
                new List<string>() {"hoge", "fuga", "hage"},
                new List<string>() {"hoge", "hoge", "hage"});

            // Test OK.
            CollectionAssert.AreNotEqual(
                new List<string>() {"hoge", "fuga", "hage"},
                new List<string>() {"fuga", "hoge", "hage"});

            // Test NG.
            CollectionAssert.AreNotEqual(
                new List<string>() {"hoge", "fuga", "hage"},
                new List<string>() {new String("hoge"), new String("fuga"), new String("hage")});

        }
        
        [TestCase]
        public void AreEquivalentTest()
        {
            // Test OK.
            CollectionAssert.AreEquivalent(
                new List<string>() {"hoge", "fuga", "hage"},
                new List<string>() {"hoge", "fuga", "hage"});

            // Test NG.
            CollectionAssert.AreEquivalent(
                new List<string>() {"hoge", "fuga", "hage"},
                new List<string>() {"hoge", "hoge", "hage"});

            // Test OK.
            CollectionAssert.AreEquivalent(
                new List<string>() {"hoge", "fuga", "hage"},
                new List<string>() {"fuga", "hoge", "hage"});

            // Test OK.
            CollectionAssert.AreEquivalent(
                new List<string>() {"hoge", "fuga", "hage"},
                new List<string>() {new String("hoge"), new String("fuga"), new String("hage")});

        }
        
        [TestCase]
        public void AreNotEquivalentTest()
        {
            // Test NG.
            CollectionAssert.AreNotEquivalent(
                new List<string>() {"hoge", "fuga", "hage"},
                new List<string>() {"hoge", "fuga", "hage"});

            // Test OK.
            CollectionAssert.AreNotEquivalent(
                new List<string>() {"hoge", "fuga", "hage"},
                new List<string>() {"hoge", "hoge", "hage"});

            // Test NG.
            CollectionAssert.AreNotEquivalent(
                new List<string>() {"hoge", "fuga", "hage"},
                new List<string>() {"fuga", "hoge", "hage"});

            // // Test NG.
            CollectionAssert.AreNotEquivalent(
                new List<string>() {"hoge", "fuga", "hage"},
                new List<string>() {new String("hoge"), new String("fuga"), new String("hage")});

        }
        
        [TestCase]
        public void ContainsTest()
        {
            // Test OK.
            CollectionAssert.Contains(
                new List<string>() {"hoge", "fuga", "hage"},
                "hoge");

            // Test NG.
            CollectionAssert.Contains(
                new List<string>() {"hoge", "fuga", "hage"},
                "HOGE");

            // Test OK.
            CollectionAssert.Contains(
                new List<string>() {"hoge", "fuga", "hage"},
                new String("hoge"));

        }
        
        [TestCase]
        public void DoesNotContainTest()
        {
            // Test NG.
            CollectionAssert.DoesNotContain(
                new List<string>() {"hoge", "fuga", "hage"},
                "hoge");

            // Test OK.
            CollectionAssert.DoesNotContain(
                new List<string>() {"hoge", "fuga", "hage"},
                "HOGE");

            // Test NG.
            CollectionAssert.DoesNotContain(
                new List<string>() {"hoge", "fuga", "hage"},
                new String("hoge"));

        }
        
        [TestCase]
        public void IsSubsetOfTest()
        {
            // Test OK.
            CollectionAssert.IsSubsetOf(
                new List<string>() {"hoge", "fuga"},
                new List<string>() {"hoge", "fuga", "hage"});

            // Test NG.
            CollectionAssert.IsSubsetOf(
                new List<string>() {"HOGE", "FUGA"},
                new List<string>() {"hoge", "fuga", "hage"});

            // Test NG.
            CollectionAssert.IsSubsetOf(
                new List<string>() {"hoge", "fuga", "hage"},
                new List<string>() {"hoge", "fuga"});

        }
        
        [TestCase]
        public void IsNotSubsetOfTest()
        {
            // Test NG.
            CollectionAssert.IsNotSubsetOf(
                new List<string>() {"hoge", "fuga"},
                new List<string>() {"hoge", "fuga", "hage"});

            // Test OK.
            CollectionAssert.IsNotSubsetOf(
                new List<string>() {"HOGE", "FUGA"},
                new List<string>() {"hoge", "fuga", "hage"});

            // Test OK.
            CollectionAssert.IsNotSubsetOf(
                new List<string>() {"hoge", "fuga", "hage"},
                new List<string>() {"hoge", "fuga"});

        }
        
        [TestCase]
        public void IsEmptyTest()
        {
            // Test OK.
            CollectionAssert.IsEmpty(
                new List<string>() {});

            // Test NG.
            CollectionAssert.IsEmpty(
                new List<string>() {"hoge"});

            // Test NG.
            CollectionAssert.IsEmpty(

                new List<string>() {null});
        }
        
        [TestCase]
        public void IsNotEmptyTest()
        {
            // Test NG.
            CollectionAssert.IsNotEmpty(
                new List<string>() {});

            // Test OK.
            CollectionAssert.IsNotEmpty(
                new List<string>() {"hoge"});

            // Test OK.
            CollectionAssert.IsNotEmpty(
                new List<string>() {null});
        }
        
        [TestCase]
        public void IsOrderedTest()
        {
            // Test OK.
            CollectionAssert.IsOrdered(
                new List<string>() {"A", "B", "C"});

            // Test NG.
            CollectionAssert.IsOrdered(
                new List<string>() {"C", "B", "A"});

            // Test OK.
            CollectionAssert.IsOrdered(
                new List<string>() {null, "A", "B"});

            // Test NG.
            CollectionAssert.IsOrdered(
                new List<string>() {"A", "B", null});

            // Test ArgumentException.
            CollectionAssert.IsOrdered(
                new ArrayList() {"A", "B", new Target()});

            // Test OK.
            CollectionAssert.IsOrdered(
                new List<string>() {"C", "B", "A"},
                new StringOrderDesc()
            );
        }
        
        public class StringOrderDesc : Comparer<string>
        {
            public override int Compare(string x, string y) => y.CompareTo(x);
        }

    }
}