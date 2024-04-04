using CommonData.Enums;
using Godot;
using Models.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tome2D.Constants;

namespace Tome2D.BusinessLogic.Map
{
    public class MapBL
    {
        public static string GetTextureNameFromMapTileType(MapTileTypes tileType)
        {
            string fileName = null;
            switch (tileType)
            {
                case MapTileTypes.Grass:
                    fileName = "Grass.png";
                    break;
                case MapTileTypes.Stone:
                    fileName = "Stone.png";
                    break;
            }
            return fileName;
        }

        public static void AddMapTile(Node currentScene, MapTileInfo mapTile)
        {
            PackedScene Ground = (PackedScene)GD.Load("res://Nodes/Ground.tscn");
            Sprite2D ground = (Sprite2D)Ground.Instantiate();
            currentScene.AddChild(ground);
            ground.GlobalPosition = new Vector2(mapTile.XPosition, mapTile.YPosition);
            string textureName = GetTextureNameFromMapTileType(mapTile.MapTileType);
            if (textureName == null)
            {
                return;
            }
            ground.Texture = (Texture2D)GD.Load($"{GameConstants.SpriteFolder}/{textureName}");
        }

        public static void AddChunk(Node currentScene, List<MapTileInfo> mapTiles)
        {
            foreach (var mapTile in mapTiles)
            {
                AddMapTile(currentScene, mapTile);
            }
        }
    }
}
