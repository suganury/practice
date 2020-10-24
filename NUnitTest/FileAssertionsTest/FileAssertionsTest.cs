using System.IO;
using NUnit.Framework;

namespace FileAssertionsTest
{
    public class Tests
    {
        
        [TestCase]
        public void FileAreEqualTest1()
        {
            // Test OK.
            using (FileStream
                expected = new FileStream(@"M:\work\TestA1.txt", FileMode.Open),
                actual = new FileStream(@"M:\work\TestA2.txt", FileMode.Open))
            {
                FileAssert.AreEqual(expected, actual);
            }

            // Test OK.
            FileAssert.AreEqual(
                new FileInfo(@"M:\work\TestA1.txt"), 
                new FileInfo(@"M:\work\TestA2.txt"));
            
            // Test OK.
            FileAssert.AreEqual(
                @"M:\work\TestA1.txt", 
                @"M:\work\TestA2.txt");
        }
        
        [TestCase]
        public void BinaryFileAreEqualTest()
        {
            // Test OK.
            FileAssert.AreEqual(
                @"M:\work\TestA1.jpg", 
                @"M:\work\TestA2.jpg");
        }

        
        [TestCase]
        public void FileExistsTest()
        {
            // Test OK.
            FileAssert.Exists(new FileInfo(@"M:\work\TestA1.txt"));

            // Test OK.
            FileAssert.Exists(@"M:\work\TestA1.jpg");
        }


        [TestCase]
        public void DirectoryAreEqualTest()
        {
            // Test OK.
            DirectoryAssert.AreEqual(
                new DirectoryInfo(@"M:\work\TestA1"), 
                new DirectoryInfo(@"M:\work\TestA1"));

            // Test NG. (ディレクトリ配下のファイル内容は同じ)
            DirectoryAssert.AreEqual(
                new DirectoryInfo(@"M:\work\TestA1"), 
                new DirectoryInfo(@"M:\work\TestA2"));
        }

        [TestCase]
        public void DirectoryExistsTest()
        {
            // Test OK.
            DirectoryAssert.Exists(new DirectoryInfo(@"M:\work\TestA1"));

            // Test OK.
            DirectoryAssert.Exists(@"M:\work\TestA1");
            
        }

    }
}