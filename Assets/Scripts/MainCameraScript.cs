using System.Collections;
using Domini;
using Domini.Buildings;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    private GameManager _gameManager;

    public enum GameStates
    {
        Default,
        Build
    }

    public GameStates GameState;
    
    // Use this for initialization
    void Start()
    {
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
//                print("Clicked");
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                Physics.Raycast(ray, out hit);
//                print("This hit at " + hit.point );
                if (hit.transform != null)
                    print("This hit " + hit.transform.name);
            }
        }
    }
}