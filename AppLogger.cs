namespace Session_09_Assignment
{
    public class AppLogger
    {
        private static AppLogger _logger = null;

        private AppLogger()
        {
        }

        public static AppLogger GetLogger()
        {
            if (_logger is null)
                _logger = new AppLogger();

            return _logger;
        }
    }
}
