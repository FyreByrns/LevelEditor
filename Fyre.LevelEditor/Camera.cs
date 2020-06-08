using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyre.LevelEditor {
    public class Camera {
        public int x, y, width = 70, height = 40;

        public Camera(int x, int y) {
            this.x = x;
            this.y = y;
        }
    }
}
