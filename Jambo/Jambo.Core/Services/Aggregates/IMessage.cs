namespace Jambo.Core.Services.Aggregates
{
    public interface IMessage
    {
        int MessageID { get; set; }
        int RoomID { get; set; }
        string Text { get; set; }
        string AuthorName { get; set; }
    }
}
