namespace TextualRedundancy.Classes
{
    public class AppDispatcher
    {
        private static System.Windows.Threading.Dispatcher dispatch = null;
        public static System.Windows.Threading.Dispatcher Dispatcher
        {
            get { return dispatch; }
            set { dispatch = value; }
        }
    }
}
