using System.Collections;
using Domini;
using Domini.Buildings;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    private GameManager _gameManager;
    
    // Use this for initialization
    void Start()
    {
        print("Start MainCameraScript");
        _gameManager = GameManager.Instance;

        if (_gameManager.IsStarted)
            InitCamera();
        else
            _gameManager.GameManagerStarted += (s, a) => InitCamera();
    }

    private void InitCamera()
    {
        gameObject.transform.position = new Vector3(_gameManager.CameraPositionX, _gameManager.CameraPositionY, 
            gameObject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameManager.IsStarted)
        {
            _gameManager.Update(Time.time, Time.deltaTime);
            if (Input.GetMouseButtonUp(0))
            {
                print("Clicked");
                _gameManager.BuildingManager.Build(BuildingType.Woodjack);
            }
        }
    }
}