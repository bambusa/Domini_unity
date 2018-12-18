using System;
using DefaultNamespace.Messages;
using UnityEngine;

namespace DefaultNamespace
{
    public class Messenger : MonoBehaviour
    {
        public static readonly string ObjectName = "Messenger";

        public event EventHandler<ErrorMessage> ErrorMessageReceiver;

        public void Send(ErrorMessage errorMessage)
        {
            var handler = ErrorMessageReceiver;  
            if (handler != null)
                handler(this, errorMessage);  
        }
    }
}