using System.Runtime.Serialization;

namespace NadinSoftTask.Core.Exceptions;

[Serializable]
public class ItemNotFoundException : Exception
{
    public readonly int? ItemId;
    public readonly string? ItemType;
    public ItemNotFoundException(int itemId, string itemType)
    {
        ItemId = itemId;
        ItemType = itemType;
    }

    public ItemNotFoundException(string? message) : base(message)
    {
    }

    public ItemNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected ItemNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}