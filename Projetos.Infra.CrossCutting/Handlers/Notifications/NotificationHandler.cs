using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace Projetos.Infra.CrossCutting.Handlers.Notifications
{
    public class NotificationHandler : INotificationHandler
    {
        private List<Notification> _notifications;

        public NotificationHandler()
        {
            _notifications = new List<Notification>();
        }

        public IReadOnlyCollection<Notification> GetNotifications() => _notifications;

        public bool HasNotifications() => _notifications.Any();

        public void DisposeNotifications() => _notifications = new List<Notification>();

        public void AddNotification(string message)
        {
            _notifications.Add(new Notification(message));
        }

        public void AddNotifications(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                var msgError = error.ErrorMessage;

                AddNotification(msgError);
            }
        }
    }
}
