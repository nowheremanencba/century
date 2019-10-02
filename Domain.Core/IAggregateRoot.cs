namespace Domain.Core
{
    /// <summary>
    /// Represents that the implemented classes are aggregate roots.
    /// </summary>
    /// <typeparam name="TKey">The type of the aggregate root key.</typeparam>
    /// <seealso cref="Domain.Core.IEntity{TKey}" />
    public interface IAggregateRoot
        
    {
        /// <summary>
        /// Gets the uncommitted events stored in current aggregate root.
        /// </summary>
        /// <value>
        /// The uncommitted events.
        /// </value>
        //IEnumerable<IDomainEvent> UncommittedEvents { get; }

        /// <summary>
        /// Reapplies the events on current aggregate root.
        /// </summary>
        /// <param name="events">The events.</param>
        //void Replay(IEnumerable<IDomainEvent> events);


    }
}
