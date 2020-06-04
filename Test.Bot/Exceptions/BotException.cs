using System;
namespace Test.Bot.Exceptions
{
	/// <seealso cref="System.ApplicationException" />
	[Serializable]
	public class BotException : ApplicationException
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="BotException"/> class.
		/// </summary>
		public BotException() : base()
		{ }

		/// <summary>
		/// Initializes a new instance of the <see cref="BotException"/> class.
		/// </summary>
		/// <param name="message">A message that describes the error.</param>
		public BotException(string message) : base(message)
		{ }

		/// <summary>
		/// Initializes a new instance of the <see cref="BotException"/> class.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="innerException">The exception that is the cause of the current exception. If the <paramref name="innerException" /> parameter is not a null reference, the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
		public BotException(string message, Exception innerException) : base(message, innerException)
		{ }

		/// <summary>
		/// Initializes a new instance of the <see cref="BotException"/> class.
		/// </summary>
		/// <param name="serializationInfo">The serialization information.</param>
		/// <param name="streamingContext">The streaming context.</param>
		protected BotException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext) : base(serializationInfo, streamingContext)
		{ }
	}
}
