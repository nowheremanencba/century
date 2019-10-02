using System.Threading.Tasks;

namespace Domain.Core
{
    /// <summary>
    /// Represents that the implemented classes are message handlers.
    /// </summary>
    /// <typeparam name="TMessage">The type of the message to be handled.</typeparam>
    public interface IHandler<in TMessage>
    {
        /// <summary>
        /// Handles the message asynchronously.
        /// </summary>
        /// <param name="message">The message to be handled.</param>
        /// <returns>The <see cref="Task"/> instance which executes the message handling logic.</returns>
        Task HandleAsync(TMessage message);
    }
}
