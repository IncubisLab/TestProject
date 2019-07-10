using System;

namespace TestXamarin.Exceptions
{
    public class NavigationException:Exception
    {
        public NavigationException(string message) : base(message) { }

        public NavigationException(string message, Exception exception) : base(message, exception) { }
    }
}
