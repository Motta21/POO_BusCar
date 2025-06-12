namespace POO_Buscarr.model.session
{
    public class Session
    {
        private User loggedUser = null;

        public User Login(User user) => loggedUser = user;

        public User Logout() => loggedUser = null;

        public User GetLoggedUser => loggedUser;

        public bool IsLoggedIn() => loggedUser != null;
    }
}
