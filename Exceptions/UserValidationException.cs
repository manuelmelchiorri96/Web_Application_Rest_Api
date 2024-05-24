using System.Runtime.Serialization;

namespace Web_Application_Rest_Api.Exceptions {

    public class UserValidationException : Exception, ISerializable {

        public UserValidationException(string message) : base(message) {

        }
    }
}
