namespace Domain.Core
{
    /// <summary>
    /// Represents that the implemented classes are the objects
    /// that can be purged.
    /// </summary>
    internal interface IPurgeable
    {
        /// <summary>
        /// Performs the purge operation.
        /// </summary>
        void Purge();
    }
}
