namespace POO_Buscarr.model.session
{
    public static class Session
    {
        private static User loggedUser = null;

        public static void Login(User user)
        {
            loggedUser = user;
        }

        public static void Logout()
        {
            loggedUser = null;
        }

        public static User GetLoggedUser()
        {
            return loggedUser;
        }

        public static bool IsLoggedIn()
        {
            return loggedUser != null;
        }
    }
}
