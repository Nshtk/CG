using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpGL;

/*gl.Color(0.5, 0.0, 0.0);
gl.Vertex(-2, -0.4, 1);
gl.Vertex(-2, 1.6, 1);
gl.Vertex(-2, 2, 0);
gl.Vertex(-1.7, 0, -1);
gl.Vertex(-1.7, -2, -1);
gl.Vertex(-2, -2, 0);

// грань сзади
gl.Color(0.5, 0.0, 0.0);
gl.Vertex(-2, -0.4, 1);
gl.Vertex(-2, 1.6, 1);
gl.Vertex(2, 2.7, 0.3);
gl.Vertex(2, -2, 0.3);
//gl.Vertex(-2, -0.4, 1); //доп

// грань сверху дальняя
gl.Color(0.0, 1.0, 0.0);
gl.Vertex(-2, 1.6, 1);
gl.Vertex(-2, 2, 0);
gl.Vertex(2, 2.7, 0.3);

// грань справа
gl.Color(0.0, 0.5, 0.0);
gl.Vertex(2, 2.7, 0.3);
gl.Vertex(2.5, -0.3, -0.9);
gl.Vertex(2, -2, 0.3);

// грань сверху ближняя
gl.Color(0.0, 0.0, 1.0);
gl.Vertex(2, 2.7, 0.3);
gl.Vertex(-2, 2, 0);
gl.Vertex(-1.7, 0, -1);
gl.Vertex(2.5, -0.3, -0.9);

// грань спереди
gl.Color(0.0, 0.0, 0.5);
gl.Vertex(-1.7, -2, -1);
gl.Vertex(-1.7, 0, -1);
gl.Vertex(2.5, -0.3, -0.9);

// грань снизу ближняя
gl.Color(0.5, 0.5, 0.0);
gl.Vertex(-1.7, -2, -1);
gl.Vertex(2.5, -0.3, -0.9);
gl.Vertex(2, -2, 0.3);
gl.Vertex(-2, -2, 0);

// грань снизу дальняя
gl.Color(1.0, 0.0, 1.0);
gl.Vertex(-2, -0.4, 1);
gl.Vertex(2, -2, 0.3);
gl.Vertex(-2, -2, 0);*/
namespace CompGraph6
{
    public partial class Form1 : Form
    {
        private enum Animation
        {
            Enabled,
            Disabled
        }
        private Shape[] Shapes;
        private OpenGL gl = new OpenGL();
        private int selected_index;
        private double rotation_angle = 0.0f;
        private double delta = 4.0f;
        private Animation animation = Animation.Disabled;
        private double[][] vertices_hexagon = new double[][]{
            new double[] { -1, -3, 0, 1}, //1
            new double[] { -2, -1, -1, 1}, //2
            new double[] { -2, 1, -1, 1}, //3
            new double[] { -1, 2, 0, 1}, //4
            new double[] { 0, 0, 1, 1}, //5
            new double[] { 0, -2, 1, 1}, //6
        };
        private double[][] vertices_triangle = new double[][]{
            new double[] { -2, 1, -1, 1}, //1 //3
            new double[] { -1, 2, 0, 1}, //2 //4
            new double[] { 3, 2.5, -1, 1}, //3
        };
        private double[][] vertices_trapeze = new double[][]{
            new double[] { 3, -3, -1, 1}, //1
            new double[] { -2, -1, -1, 1}, //2 //2
            new double[] { -2, 1, -1, 1}, //3  //3
            new double[] { 3, 2.5, -1, 1}, //4 //3tr
        };
        private double[][] vertices_triangle_right = new double[][]{
            new double[] { 3, 2.5, -1, 1}, //1 //3tr
            new double[] { 4, 0, 1, 1}, //2
            new double[] { 3, -3, -1, 1}, //3 //1 peze
        };
        private double[][] vertices_trapeze_front = new double[][]{
            new double[] { 4, 0, 1, 1}, //1 //2trr
            new double[] { 0, 0, 1, 1}, //3 //5
            new double[] { -1, 2, 0, 1}, //2 //4
            new double[] { 3, 2.5, -1, 1}, //1 //3tr
        };
        private double[][] vertices_triangle_front = new double[][]{
            new double[] { 0, -2, 1, 1}, //1 //6
            new double[] { 0, 0, 1, 1}, //2 //5
            new double[] { 4, 0, 1, 1}, //3 //2trr
        };
        private double[][] vertices_trapeze_down = new double[][]{
            new double[] { 3, -3, -1, 1}, //1 //1 peze
            new double[] { -1, -3, 0, 1}, //2
            new double[] { 0, -2, 1, 1}, //3
            new double[] { 4, 0, 1, 1}, //4 //2 trr
        };
        private double[][] vertices_triangle_back = new double[][]{
            new double[] { -1, -3, 0, 1}, //1 //1
            new double[] { -2, -1, -1, 1}, //2 //2
            new double[] { 3, -3, -1, 1}, //3 //1 peze
        };

        public Form1()
		{
			InitializeComponent();
            Shapes = new Shape[] {
                new ShapeHexagon(vertices_hexagon, 0.5, 0.0, 0.0, gl),
                new ShapeTriangle(vertices_triangle, 0.0, 0.5, 0.0, gl),
                new ShapeTrapeze(vertices_trapeze, 0.0, 0.0, 0.5, gl),
                new ShapeTriangle(vertices_triangle_right, 0.5, 0.0, 0.5, gl),
                new ShapeTrapeze(vertices_trapeze_front, 0.5, 0.5, 0.5, gl),
                new ShapeTriangle(vertices_triangle_front, 1.0, 0.5, 0.2, gl),
                new ShapeTrapeze(vertices_trapeze_down, 0.0, 1.0, 1.0, gl),
                new ShapeTriangle(vertices_triangle_back, 1.0, 1.0, 0.0, gl)
            };
            comboBox1.SelectedIndex = 0;
		}

        /*private void drawHexagon(in double[][] vertices)
        {
            if (vertices.Length != 6)
                return;
            gl.Vertex(vertices[0]);
            gl.Vertex(vertices[1]);
            gl.Vertex(vertices[2]);
            gl.Vertex(vertices[3]);
            gl.Vertex(vertices[3]);
            gl.Vertex(vertices[4]);
            gl.Vertex(vertices[5]);
            gl.Vertex(vertices[0]);
        }
        private void drawTrapeze(in double[][] vertices)
        {
            if (vertices.Length != 4)
                return;
            gl.Vertex(vertices[0]);
            gl.Vertex(vertices[1]);
            gl.Vertex(vertices[2]);
            gl.Vertex(vertices[3]);
        }
        private void drawTriangle(in double[][] vertices)
        {
            if (vertices.Length != 3)
                return;
            gl.Vertex(vertices[0]);
            gl.Vertex(vertices[1]);
            gl.Vertex(vertices[2]);
            gl.Vertex(vertices[0]);
        }*/

        public void drawShape()
		{
            gl.Begin(OpenGL.GL_QUADS);
            rotation_angle += delta;

            foreach(var shape in Shapes)
            {
                shape.draw();
			}

            /*gl.Color(0.5, 0.0, 0.0);
            drawHexagon(in vertices_hexagon);

            gl.Color(0.0, 0.5, 0.0);
            drawTriangle(in vertices_triangle);

            gl.Color(0.0, 0.0, 0.5);
            drawTrapeze(in vertices_trapeze);

            gl.Color(0.5, 0.0, 0.5);
            drawTriangle(in vertices_triangle_right);

            gl.Color(0.5, 0.5, 0.5);
            drawTrapeze(in vertices_trapeze_front);

            gl.Color(1.0, 0.5, 0.2);
            drawTriangle(in vertices_triangle_front);

            gl.Color(0.0, 1.0, 1.0);
            drawTrapeze(in vertices_trapeze_down);

            gl.Color(1.0, 1.0, 0.0);
            drawTriangle(in vertices_triangle_back);*/

            gl.End();
            gl.Flush();
        }

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
            selected_index = comboBox1.SelectedIndex;
		}
		private void openGLControl1_OpenGLDraw(object sender, RenderEventArgs args)
		{
            if (animation == Animation.Disabled)
                return;

            OpenGL gl_control = openGLControl1.OpenGL;

            gl_control.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl_control.LoadIdentity();
            gl_control.Translate(0.0, 0.0, -8.0);

            switch (selected_index)
            {
                case 0:
                    gl_control.Rotate(rotation_angle, 1.0, 0.0, 0.0);
                    break;
                case 1:
                    gl_control.Rotate(rotation_angle, 0.0, 1.0, 0.0);
                    break;
                case 2:
                    gl_control.Rotate(rotation_angle, 0.0, 0.0, 1.0);
                    break;
                default:
                    break;
            }
            drawShape();
        }

		private void button1_Click(object sender, EventArgs e)
		{
            if (animation==Animation.Enabled)
                animation=Animation.Disabled;
            else
                animation = Animation.Enabled;
        }
	}
    public class Shape
    {
        protected OpenGL gl;
        protected double[][] vertices;
        protected double[] color = new double[3];

        protected Shape(double[][] vertices, double r, double g, double b, OpenGL gl)
        {
            this.vertices = vertices;
            this.gl = gl;
            color[0] = r; color[1] = g; color[2] = b;
        }

        public virtual void draw()
        {}
    }
    public class ShapeHexagon : Shape
    {
        public ShapeHexagon(double[][] vertices, double r, double g, double b, OpenGL gl) : base(vertices, r, g, b, gl)
        {}

        public override void draw()
        {
            if (vertices.Length != 6)
                return;
            gl.Color(color[0], color[1], color[2]);
            gl.Vertex(vertices[0]);
            gl.Vertex(vertices[1]);
            gl.Vertex(vertices[2]);
            gl.Vertex(vertices[3]);
            gl.Vertex(vertices[3]);
            gl.Vertex(vertices[4]);
            gl.Vertex(vertices[5]);
            gl.Vertex(vertices[0]);
        }
    }
    public class ShapeTrapeze : Shape
    {
        public ShapeTrapeze(double[][] vertices, double r, double g, double b, OpenGL gl) : base(vertices, r, g, b, gl)
        {}

        public override void draw()
        {
            if (vertices.Length != 4)
                return;
            gl.Color(color[0], color[1], color[2]);
            gl.Vertex(vertices[0]);
            gl.Vertex(vertices[1]);
            gl.Vertex(vertices[2]);
            gl.Vertex(vertices[3]);
        }
    }
    public class ShapeTriangle : Shape
    {
        public ShapeTriangle(double[][] vertices, double r, double g, double b, OpenGL gl) : base(vertices, r, g, b, gl)
        {}

        public override void draw()
        {
            if (vertices.Length != 3)
                return;
            gl.Color(color[0], color[1], color[2]);
            gl.Vertex(vertices[0]);
            gl.Vertex(vertices[1]);
            gl.Vertex(vertices[2]);
            gl.Vertex(vertices[0]);
        }
    }
}
