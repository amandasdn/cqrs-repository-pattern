using MediatR;

namespace BookCatalog.Application.Notification
{
    public class BookCreatedNotification(Guid id, string title) : INotification
    {
        public Guid Id { get; private set; } = id;
        public string Title { get; private set; } = title;
    }
}
