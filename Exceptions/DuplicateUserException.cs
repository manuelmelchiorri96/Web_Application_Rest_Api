namespace Web_Application_Rest_Api.Exceptions {

    public class DuplicateUserException : Exception {

        public DuplicateUserException(string message) : base(message) {
        
        }
    }
}
