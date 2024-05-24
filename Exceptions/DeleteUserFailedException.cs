using System.Runtime.Serialization;

namespace Web_Application_Rest_Api.Exceptions {

    public class DeleteUserFailedException : Exception, ISerializable {

        public DeleteUserFailedException(string message) : base(message) {

        }
    }
}
