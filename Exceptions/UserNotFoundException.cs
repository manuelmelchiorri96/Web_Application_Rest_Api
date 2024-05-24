using System.Runtime.Serialization;

namespace Web_Application_Rest_Api.Exceptions {
    public class UserNotFoundException : Exception, ISerializable {

        public UserNotFoundException(string message) : base(message) {

        }
    }
}
