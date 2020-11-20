using System.Collections.Generic;
using CodingChallengeLike.Domain.Notifications;

namespace CodingChallengeLike.Domain.Interfaces.Notifications
{
    public interface IDomainNotification
    {
        IReadOnlyCollection<NotificationMessage> Notifications { get; }
        bool HasNotifications { get; }
        void AddNotification(string key, string message);
        void AddNotifications(IEnumerable<NotificationMessage> notifications);
    }
}
