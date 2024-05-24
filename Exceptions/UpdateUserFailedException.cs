using System.Runtime.Serialization;

namespace Web_Application_Rest_Api.Exceptions {

    public class UpdateUserFailedException : Exception, ISerializable {

        public UpdateUserFailedException(string message) : base(message) {

        }
    }
}
