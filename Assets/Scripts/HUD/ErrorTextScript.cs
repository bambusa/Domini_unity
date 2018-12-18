using System;
using System.Threading.Tasks;
using DefaultNamespace.Messages;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ErrorTextScript : MessengerMember
    {
        protected override void Start()
        {
            base.Start();
            Messenger.ErrorMessageReceiver += ErrorMessageReceiver;
            transform.gameObject.SetActive(false);
        }

        private void ErrorMessageReceiver(object sender, ErrorMessage errorMessage)
        {
            transform.GetComponent<Text>().text = errorMessage.Message;
            transform.gameObject.SetActive(true);
            HideInSeconds(errorMessage.ShowSeconds);
        }

        private async void HideInSeconds(int delaySeconds)
        {
            await Task.Delay(delaySeconds * 1000);
            transform.GetComponent<Text>().text = string.Empty;
            transform.gameObject.SetActive(false);
        }
    }
}