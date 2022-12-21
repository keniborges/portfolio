using FluentValidation.Results;
using System.Collections.Generic;

namespace Projetos.Infra.CrossCutting.Handlers.Notifications
{
    public interface INotificationHandler
    {
        void AddNotification(string message);
        void AddNotifications(ValidationResult validationResult);
        IReadOnlyCollection<Notification> GetNotifications();
        bool HasNotifications();
        void DisposeNotifications();
    }
}
