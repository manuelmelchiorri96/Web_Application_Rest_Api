using System.Runtime.Serialization;

namespace Web_Application_Rest_Api.Exceptions {
    public class EmptyUserListException : Exception, ISerializable {

        public EmptyUserListException(string message) : base(message) {
        
        }
    }
}
