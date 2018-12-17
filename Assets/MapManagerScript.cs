using Domini;
using Domini.Map;
using UnityEngine;

namespace DefaultNamespace
{
    public class MapManagerScript : MonoBehaviour
    {
        public Transform Parent;
        public Transform MapTile;
        public Texture2D DefaultSprite;
        public Texture2D GrassSprite;
        public Texture2D WaterSprite;
        public Texture2D MountainSprite;
        
        private GameManager _gameManager;
        
        // Use this for initialization
        void Start()
        {
            print("Start MapManagerScript");
            _gameManager = GameManager.Instance;

            if (_gameManager.IsStarted)
                RenderMap();
            else
                _gameManager.GameManagerStarted += (s, a) => RenderMap();
        }
        
        private void RenderMap()
        {
            foreach (var mapRows in _gameManager.MapManager.GetAllMapTiles())
            {
                foreach (var tile in mapRows)
                {
                    var sprite = DefaultSprite;
                    switch (tile.TileType)
                    {
                            case TileType.Grass:
                                sprite = GrassSprite;
                                break;
                            case TileType.Water:
                                sprite = WaterSprite;
                                break;
                            case TileType.Mountain:
                                sprite = MountainSprite;
                                break;
                    }
                    
                    var transform = Instantiate(MapTile, new Vector3(tile.PositionX, tile.PositionY, 0), Quaternion.identity);
                    transform.GetComponent<Renderer>().material.mainTexture = sprite;
                    transform.SetParent(Parent);
                }
            }
        }
    }
}