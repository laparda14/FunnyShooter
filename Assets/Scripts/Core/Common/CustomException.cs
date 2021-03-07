using System;
using System.Runtime.Serialization;

namespace FunnyShooter.Core {
    /// <summary>
    /// 异常类
    /// </summary>
    public class CustomException : Exception {
        public CustomException() : base() {
        }

        public CustomException(object message) : base(message.ToString()) {
        }

        public CustomException(string message) : base(message) {
        }

        public CustomException(string message, Exception innerException) : base(message, innerException) {
        }

        protected CustomException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
}