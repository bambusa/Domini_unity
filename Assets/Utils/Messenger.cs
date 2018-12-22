using System;
using System.Collections.Generic;
using UnityEngine;
using Utils.BroadcastMessages;

namespace Utils
{
    public class Messenger : MonoBehaviour
    {
        public static readonly string ObjectName = "Messenger";

        public event EventHandler<ErrorMessage> ErrorMessageReceiver;
        public event EventHandler<ChooseBuildPositionMessage> ChooseBuildPositionMessageReceiver;

        public void Send<T>(T broadcastMessage)
        {
            EventHandler<T> handler = null;
            if (T == typeof(ErrorMessage))
            if (handler != null)
                handler(this, broadcastMessage);  
        }
    }
}