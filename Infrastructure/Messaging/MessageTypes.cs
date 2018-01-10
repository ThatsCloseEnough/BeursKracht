namespace BeursKracht.Infrastructure.Messaging
{
    /// <summary>
    /// Complete list of message types in the system.
    /// </summary>
    public enum MessageTypes
    {
        // General
        Unknown, 

        // Commands
        RegisterOrder,

        // Events
        SaleWasMade
    }
}
