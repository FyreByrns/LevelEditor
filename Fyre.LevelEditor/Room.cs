using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyre.LevelEditor {

    public class Room {
        enum BorderType { Passable, Solid }

        public string name = "Unnamed";
        public int width, height;
        BorderType borderType;
        List<Camera> cameras;
        float lightAngleX, lightAngleY;
        int water;
        bool waterInFront;

        /// <summary>
        /// Tiles the player collides with
        /// </summary>
        public Tile[,] foregroundTiles;
        public Tile[,] midgroundTiles;
        public Tile[,] backgroundTiles;

        public Tile this[int x, int y, int layer] {
            get => GetTile(x, y, layer);
            set => SetTile(x, y, layer, value);
        }
        Tile GetTile(int x, int y, int layer) {
            if (x < 0 || y < 0 || layer < 0 || x >= width || y >= width || layer > 2) return new Tile();
            return this[x, y, layer];
        }
        public void SetTile(int x, int y, int layer, Tile tile) {
            if (x < 0 || y < 0 || x >= width || y >= height || layer < 0 || layer > 2) {
                Console.WriteLine($"Can't set tile outside the room at: {x},{y} layer {layer}.");
            }

            switch (layer) {
                case 0:
                    foregroundTiles[x, y].type = tile.type;
                    break;
                case 1:
                    midgroundTiles[x, y].type = tile.type;
                    break;
                case 2:
                    backgroundTiles[x, y].type = tile.type;
                    break;
            }
        }

        public Room(int width, int height) {
            this.width = width;
            this.height = height;

            foregroundTiles = new Tile[width, height];
            midgroundTiles = new Tile[width, height];
            backgroundTiles = new Tile[width, height];

            cameras = new List<Camera>() {
                new Camera(0, 0),
            };
            borderType = BorderType.Passable;

            water = -1;
        }

        string GetCameraString() {
            string cameraPositions = "";

            foreach (Camera c in cameras) {
                cameraPositions += $"{c.x},{height * 20 - 800 - c.y}|";
            }

            return cameraPositions.TrimEnd('|');
        }

        public string[] CreateSaveData() {
            string[] toSave = new string[12];

            toSave[0] = name;
            toSave[1] = $"{width}*{height}|{water}|{(waterInFront ? 1 : 0)}";
            toSave[2] = $"{lightAngleX}*{lightAngleY}|0|0";
            toSave[3] = GetCameraString();
            toSave[4] = $"Border: {borderType}";
            toSave[5] = "";//GetThrowableString();

            toSave[6] = "";
            toSave[7] = "";
            toSave[8] = "";
            toSave[9] = "0";
            toSave[10] = "";

            toSave[11] = GetTileString();

            return toSave;
        }

        string GetTileString() {
            string tilesToReturn = "";

            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++) {
                    if (backgroundTiles[i, j].type != Tile.TileType.Air || backgroundTiles[i, j].type != Tile.TileType.Air)
                        foregroundTiles[i, j].HasWall = true;
                    tilesToReturn += foregroundTiles[i, j].ToString();
                }

            return tilesToReturn.TrimEnd('|');
        }
    }
}
