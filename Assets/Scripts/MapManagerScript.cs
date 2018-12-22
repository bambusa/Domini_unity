using System.Collections.Generic;
using Domini;
using Domini.Map;
using Domini.Utils;
using UnityEngine;
using Utils;

public class MapManagerScript : MonoBehaviour
{
    public Transform Parent;
    public Transform MapTile;
    public Texture2D DefaultSprite;
    public Texture2D GrassSprite;
    public Texture2D WaterSprite;
    public Texture2D MountainSprite;
        
    private GameManager _gameManager;
    private Dictionary<Transform, Tile> _tiles;
        
    // Use this for initialization
    void Start()
    {
        _gameManager = GameManager.Instance;

        if (_gameManager.IsStarted)
            RenderMap();
        else
            _gameManager.GameManagerStarted += (s, a) => RenderMap();
    }
        
    private void RenderMap()
    {
        _tiles = new Dictionary<Transform, Tile>();
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
                transform.name = $"{Constants.MapTilePrefix} {tile.PositionX}/{tile.PositionY} {tile.TileType}";
                _tiles.Add(transform, tile);
            }
        }
    }

    public void ObjectClicked(Transform transform)
    {
        if (_tiles.ContainsKey(transform))
        {
            _tiles[transform].RaiseObjectClicked(ObjectClickedArgument.ClickType.Single);
        }
    }
}