
namespace Assignment2
{
    public interface IAtmosphere
    {
    }

    public class SunShine : IAtmosphere{

        private static SunShine instance;
        private SunShine() { }

        public static SunShine Instance()
        {
            if(instance == null)
            {
                instance = new SunShine();  
            }

            return instance;
        }
    
    }
    public class Thunderstorm : IAtmosphere{
        private static Thunderstorm instance;
        private Thunderstorm() { }

        public static Thunderstorm Instance()
        {
            if (instance == null)
            {
                instance = new Thunderstorm();
            }

            return instance;
        }
    }
    public class Other : IAtmosphere {
        private static Other instance;
        private Other() { }

        public static Other Instance()
        {
            if (instance == null)
            {
                instance = new Other();
            }

            return instance;
        }
    }
}
