using System.Collections.Generic;

namespace Hybrid
{
    public class Mesh
    {
        public Texture texture;
        public Point[] vertices;
        public Color[] colors;
        public Point[] uvs;
        public int[] indices;

        public Mesh(Texture texture, Point[] vertices, Color[] colors, Point[] uvs, int[] indices)
        {
            this.texture = texture;
            this.vertices = vertices;
            this.indices = indices;
            this.colors = colors;
            this.uvs = uvs;
        }
    }
}