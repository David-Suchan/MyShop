using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Useful
{
    internal class Messenger
    {
        private static Dictionary<Type, Action<object>> recipients = new Dictionary<Type, Action<object>>();

        public static void Subscribe(Type messageType, Action<object> methodToCall)
        {
            recipients.Add(messageType, methodToCall);
        }

        public static void SendMessage(Type messageType, object messageContent)
        {
            Action<object> recipient;
            bool exists = recipients.TryGetValue(messageType, out recipient);
            if (exists)
            {
                recipient(messageContent);
            }
        }
    }
}
