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
            string tret = "";

            tret += $"{(int)type}";
            if (PoleV) tret += ",1";
            if (PoleH) tret += ",2";
            if (HasShortcut) tret += ",3";
            if (HasWall) tret += ",6";
            if (HasHive) tret += ",7";
            if (GarbageHole) tret += ",10";
            if (WormGrass) tret += ",11";

            return tret + "|";
        }
    }
}
