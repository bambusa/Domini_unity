using Domini;
using Domini.Buildings;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameManagerScript : MonoBehaviour
    {
        private GameManager _gameManager;

        // Use this for initialization
        void Start()
        {
            _gameManager = GameManager.Instance;
            _gameManager.Start();
        }

        // Update is called once per frame
        void Update()
        {
            _gameManager.Update(Time.time, Time.deltaTime);
        }
    }
}