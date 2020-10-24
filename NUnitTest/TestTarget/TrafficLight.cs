using System;

namespace TargetLib
{
    public class TrafficLight
    {
        public enum Color {BLUE, YELLOW, RED}

        
        public static string judge(Color color) {

            switch(color) {
                case Color.BLUE:
                    return "進め！";
                case Color.YELLOW:
                    return "注意して進め！";
                case Color.RED:
                    return "止まれ！";
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }

        public static string judge2(Color color) {
            if(color.Equals(Color.BLUE) || color.Equals(Color.YELLOW)) {
                return "進んでヨシ！";
            }
            return "ダメ";
        }
    }
}
