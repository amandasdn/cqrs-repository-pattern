using MediatR;

namespace BookCatalog.Application.Notification
{
    public class BookCreatedNotificationHandler : INotificationHandler<BookCreatedNotification>
    {
        public Task Handle(BookCreatedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"The book {notification.Title} ({notification.Id}) was inserted.");

            return Task.CompletedTask;
        }
    }
}
