using System;
using NUnit.Framework;
using TargetLib;
using static TargetLib.TrafficLight.Color;

namespace TargetLibTest
{
    public class TrafficLightTest
    {
        [TestCase(BLUE)]
        public void TrafficLight_judge_success(TrafficLight.Color color)
        {
            string result = TrafficLight.judge(color);
            Assert.AreEqual("進め！", result);
        }

        
        [TestCase(BLUE, "進め！")]
        [TestCase(YELLOW, "注意して進め！")]
        [TestCase(RED, "止まれ！")]
        public void TrafficLight_judge_success(TrafficLight.Color color, string expectedResult)
        {
            string result = TrafficLight.judge(color);
            Assert.AreEqual(expectedResult, result);
        }
        
        [TestCase((TrafficLight.Color)int.MaxValue)]
        public void TrafficLight_judge_failure(TrafficLight.Color color)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => TrafficLight.judge(color));
        }

        [TestCase(BLUE, "進んでヨシ！")]
        [TestCase(RED, "ダメ")]
        public void TrafficLight_judge2_success(TrafficLight.Color color, string expectedResult)
        {
            string result = TrafficLight.judge2(color);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void TrafficLight_judge2_success([Values]TrafficLight.Color color)
        {
            string result = TrafficLight.judge2(color);
            switch(color)
            {
                case TrafficLight.Color.BLUE:
                    Assert.AreEqual("進んでヨシ！", result);
                    break;
                case TrafficLight.Color.RED:
                    Assert.AreEqual("ダメ", result);
                    break;
                default:
                    Assert.Fail($"{color}をテストしてないよ！");
                    break;
            }
        }
    }
}