using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyre.LevelEditor {
    public struct Tile {
        public enum TileType {
            Air,
            Solid,
            Slope,
            Floor,
            ShortcutEntrance,
        }

        public TileType type;
        public bool PoleH;
        public bool PoleV;
        public bool HasShortcut;
        public bool HasWall;
        public bool HasHive;
        public bool GarbageHole;
        public bool WormGrass;

        public Tile(TileType type = TileType.Air) {
            this.type = type;
            PoleH = false;
            PoleV = false;
            HasShortcut = false;
            HasWall = false;
            HasHive = false;
            GarbageHole = false;
            WormGrass = false;

            if (type == TileType.ShortcutEntrance)
                HasShortcut = true;
        }

        public override string ToString() {
            StringBuilder stringRepresentation = new StringBuilder();

            stringRepresentation.Append($"{(int)type}");
            if (PoleV) stringRepresentation.Append(",1");
            if (PoleH) stringRepresentation.Append(",2");
            if (HasShortcut) stringRepresentation.Append(",3");
            if (HasWall) stringRepresentation.Append(",6");
            if (HasHive) stringRepresentation.Append(",7");
            if (GarbageHole) stringRepresentation.Append(",10");
            if (WormGrass) stringRepresentation.Append(",11");
            stringRepresentation.Append("|");

            return stringRepresentation.ToString();
        }
    }
}
