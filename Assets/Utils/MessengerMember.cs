using UnityEngine;

namespace Utils
{
    public class MessengerMember : GameManagerMember
    {
        public Messenger Messenger { private set; get; }

        protected virtual void Start()
        {
            Messenger = GameObject.Find(Messenger.ObjectName).GetComponent<Messenger>();
        }
    }
}