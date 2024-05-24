using System.Runtime.Serialization;

namespace Web_Application_Rest_Api.Exceptions {

    public class DuplicateUserException : Exception, ISerializable {

        public DuplicateUserException(string message) : base(message) {
        
        }
    }
}
