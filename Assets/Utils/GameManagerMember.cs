using System;
using Domini;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameManagerMember : MonoBehaviour
    {
        protected GameManager _gameManager;

        protected virtual void InitGameManager(Action actionAfterStarted)
        {
            _gameManager = GameManager.Instance;

            if (_gameManager.IsStarted)
                actionAfterStarted();
            else
                _gameManager.GameManagerStarted += (s, a) => actionAfterStarted();
        }
    }
}