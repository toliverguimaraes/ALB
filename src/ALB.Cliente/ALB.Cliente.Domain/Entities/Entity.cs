using Flunt.Notifications;
using System.Text;

namespace ALB.Cliente.Domain.Entities
{
    public abstract class Entity<Tkey> : Notifiable
    {
        protected Entity() : base(){ }
        public Tkey Id { get; set; }
        public abstract void Validate();

        public string ShowNotification() {
            StringBuilder builder = new StringBuilder();
            foreach (var notification in this.Notifications)
            {
                builder.Append($"{notification.Property} - {notification.Message}");
            }
            return builder.ToString();
        }
    }
}
