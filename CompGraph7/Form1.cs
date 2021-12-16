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
using SharpGL.SceneGraph.Assets;

namespace CompGraph7
{
    public partial class Form1 : Form
	{
        public enum Animation
        {
            Enabled,
            Disabled
        }
        public enum Lighting
        {
            Enabled,
            Disabled
        }
        public enum Texturing
        {
            Enabled,
            Disabled
        }
        public OpenGL gl = new OpenGL();
        public int selected_index;
        public float rotation_angle = 0.0f;
        public float delta = 4.0f;
        public bool    lighting = false;
        public Color   modelColor = Color.LightSeaGreen;
        public Color   lightColor = Color.Purple;
        public Texture texture = null;
        public Animation animation = Animation.Disabled;
        

        public Shape[] Shapes;

        public Form1()
		{
			InitializeComponent();
			InitializeScene();
		}
        public void InitializeScene()
        {
            gl = openGLControl1.OpenGL;
            double[][] vertices_hexagon = new double[][]{
            new double[] { -1, -3, 0, 1}, //1
            new double[] { -2, -1, -1, 1}, //2
            new double[] { -2, 1, -1, 1}, //3
            new double[] { -1, 2, 0, 1}, //4
            new double[] { 0, 0, 1, 1}, //5
            new double[] { 0, -2, 1, 1}, //6
        };
        double[][] vertices_triangle = new double[][]{
            new double[] { -2, 1, -1, 1}, //1 //3
            new double[] { -1, 2, 0, 1}, //2 //4
            new double[] { 3, 2.5, -1, 1}, //3
        };
        double[][] vertices_trapeze = new double[][]{
            new double[] { 3, -3, -1, 1}, //1
            new double[] { -2, -1, -1, 1}, //2 //2
            new double[] { -2, 1, -1, 1}, //3  //3
            new double[] { 3, 2.5, -1, 1}, //4 //3tr
        };
        double[][] vertices_triangle_right = new double[][]{
            new double[] { 3, 2.5, -1, 1}, //1 //3tr
            new double[] { 4, 0, 1, 1}, //2
            new double[] { 3, -3, -1, 1}, //3 //1 peze
        };
        double[][] vertices_trapeze_front = new double[][]{
            new double[] { 4, 0, 1, 1}, //1 //2trr
            new double[] { 0, 0, 1, 1}, //3 //5
            new double[] { -1, 2, 0, 1}, //2 //4
            new double[] { 3, 2.5, -1, 1}, //1 //3tr
        };
        double[][] vertices_triangle_front = new double[][]{
            new double[] { 0, -2, 1, 1}, //1 //6
            new double[] { 0, 0, 1, 1}, //2 //5
            new double[] { 4, 0, 1, 1}, //3 //2trr
        };
        double[][] vertices_trapeze_down = new double[][]{
            new double[] { 3, -3, -1, 1}, //1 //1 peze
            new double[] { -1, -3, 0, 1}, //2
            new double[] { 0, -2, 1, 1}, //3
            new double[] { 4, 0, 1, 1}, //4 //2 trr
        };
        double[][] vertices_triangle_back = new double[][]{
            new double[] { -1, -3, 0, 1}, //1 //1
            new double[] { -2, -1, -1, 1}, //2 //2
            new double[] { 3, -3, -1, 1}, //3 //1 peze
        };
        Shapes = new Shape[] {
                new ShapeHexagon(vertices_hexagon, gl),
                new ShapeTriangle(vertices_triangle, gl),
                new ShapeTrapeze(vertices_trapeze, gl),
                new ShapeTriangle(vertices_triangle_right, gl),
                new ShapeTrapeze(vertices_trapeze_front, gl),
                new ShapeTriangle(vertices_triangle_front, gl),
                new ShapeTrapeze(vertices_trapeze_down, gl),
                new ShapeTriangle(vertices_triangle_back, gl)
            };
        }
        public void openGLControl1_OpenGLDraw(object sender, RenderEventArgs args)
        {
            gl.LoadIdentity();
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            //glLightningDefauls();
            glRotation();
            modelColor = colorDialog1.Color;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    //gl.Disable(OpenGL.GL_LIGHTING);
                    //gl.Disable(OpenGL.GL_LIGHT0);
                    if (comboBox2.SelectedIndex==0)
                        drawShape(modelColor, OpenGL.GL_QUADS, texture);
                    else
                        drawShape(modelColor, OpenGL.GL_LINE_LOOP, texture);
                    break;
                case 1:
                    gl.Enable(OpenGL.GL_LIGHTING);
                    gl.Enable(OpenGL.GL_LIGHT0);
                    if (comboBox2.SelectedIndex == 0)
                        glDrawTeaPot(modelColor, OpenGL.GL_FILL, texture);
                    else
                        glDrawTeaPot(modelColor, OpenGL.GL_LINE, texture);
                    break;
                default:
                    break;
            }
        }
        public void glLightningDefauls()
        {
            if (this.lighting == true)
            {
                this.lightColor = colorDialog2.Color;
                float[] global_ambient = { 0.5f, 0.5f, 0.5f, 1.0f };
                float[] light0pos = { -1.0f, 1.0f, 1.0f, 0.0f };
                float[] light0ambient = {(float)(colorDialog1.Color.R / 255.0), (float)(colorDialog1.Color.G / 255.0), (float)(colorDialog1.Color.B / 255.0), 1.0f};
                float[] light0diffuse = { (float)(lightColor.R / 255.0), (float)(lightColor.G / 255.0), (float)(lightColor.B / 255.0), 1.0f };
                float[] light0specular = { 0.8f, 0.8f, 0.8f, 1.0f };
                float[] lmodel_ambient = { 0.2f, 0.2f, 0.2f, 1.0f };

                gl.Enable(OpenGL.GL_DEPTH_TEST);
                gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, lmodel_ambient);
                gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, global_ambient);
                gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, light0pos);
                gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_AMBIENT, light0ambient);
                gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_DIFFUSE, light0diffuse);
                gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_SPECULAR, light0specular);
                gl.ShadeModel(OpenGL.GL_SMOOTH);
            }
            else
            {
                lightColor = colorDialog2.Color;
                float[] global_ambient = { 0.5f, 0.5f, 0.5f, 1.0f };
                float[] light0pos = { -1.0f, 1.0f, 1.0f, 0.0f };
                float[] light0ambient = { (float)(colorDialog1.Color.R / 255.0), (float)(colorDialog1.Color.G / 255.0), (float)(colorDialog1.Color.B / 255.0), 1.0f};
                float[] light0diffuse = { (float)(colorDialog1.Color.R / 255.0), (float)(colorDialog1.Color.G / 255.0), (float)(colorDialog1.Color.B / 255.0), 1.0f};
                float[] light0specular = { 0.8f, 0.8f, 0.8f, 1.0f };
                float[] lmodel_ambient = { 0.2f, 0.2f, 0.2f, 1.0f };

                gl.Enable(OpenGL.GL_DEPTH_TEST);
                gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, lmodel_ambient);
                gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, global_ambient);
                gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, light0pos);
                gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_AMBIENT, light0ambient);
                gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_DIFFUSE, light0diffuse);
                gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_SPECULAR, light0specular);
                gl.ShadeModel(OpenGL.GL_SMOOTH);
            }
        }

        public void glRotation()
        {
            gl.Translate(0.0, 0.0, -7.0);
            switch(comboBox3.SelectedIndex)
            {
                case 0:
                    gl.Rotate(rotation_angle, 0.0f, 0.0f);
                    break;
                case 1:
                    gl.Rotate(0.0f, rotation_angle, 0.0f);
                    break;
                case 2:
                    gl.Rotate(0.0f, 0.0f, rotation_angle);
                    break;
            }

            rotation_angle += delta;
        }

        public void drawShape(Color color, uint type, Texture texture)
        {
            gl.Begin(type);
            rotation_angle += delta;

            foreach (var shape in Shapes)
            {
                shape.draw(0.5, 0.0, 0.5);
			}

            /*if (texture == null)
            {
                for (int i = 0; i < 6; ++i)
                {
                    gl.Begin(type);
                    if (lighting == true)
                        gl.Color((float)(colorDialog2.Color.R / 255.0), (float)(colorDialog2.Color.G / 255.0), (float)(colorDialog2.Color.B / 255.0));
                    else
                        gl.Color(color.R / 255.0 * 0.5, color.G / 255.0 * 0.5, color.B / 255.0 * 0.5);

                    gl.Vertex(points[i, 0, 0], points[i, 0, 1], points[i, 0, 2]);
                    gl.Vertex(points[i, 1, 0], points[i, 1, 1], points[i, 1, 2]);

                    gl.Color(color.R, color.G, color.B);
                    gl.Vertex(points[i, 2, 0], points[i, 2, 1], points[i, 2, 2]);
                    gl.Vertex(points[i, 3, 0], points[i, 3, 1], points[i, 3, 2]);
                    gl.End();
                }
                gl.Flush();
            }
            else
            {
                texture.Create(gl, Project7.Properties.Resources.texture);
                gl.TexEnv(OpenGL.GL_TEXTURE_ENV, OpenGL.GL_TEXTURE_ENV_MODE, (float)OpenGL.GL_REPLACE);
                gl.Enable(OpenGL.GL_TEXTURE_2D);
                gl.Begin(type);
                for (int i = 0; i < 6; ++i)
                {
                    gl.TexCoord(0, 0);
                    gl.Vertex(points[i, 0, 0], points[i, 0, 1], points[i, 0, 2]);
                    gl.TexCoord(0, 1);
                    gl.Vertex(points[i, 1, 0], points[i, 1, 1], points[i, 1, 2]);
                    gl.TexCoord(1, 0);
                    gl.Vertex(points[i, 2, 0], points[i, 2, 1], points[i, 2, 2]);
                    gl.TexCoord(1, 1);
                    gl.Vertex(points[i, 3, 0], points[i, 3, 1], points[i, 3, 2]);
                }
                gl.End();
                gl.Flush();
                gl.Disable(OpenGL.GL_TEXTURE_2D);
            }

            gl.End();
            gl.Flush();*/
        }

        /*public void glDrawCube(ref SharpGL.OpenGL gl, Color color, uint type, Texture texture)
        {
            double[,,] points = {
                {{ -1.0, -1.0, 1.0 },
                { -1.0, 1.0, 1.0 },
                { 1.0, 1.0, 1.0 },
                { 1.0, -1.0, 1.0 } },

                {{ 1.0, 1.0, -1.0 },
                { 1.0, -1.0, -1.0 },
                { -1.0, -1.0, -1.0 },
                { -1.0, 1.0, -1.0 } },

                {{ -1.0, 1.0, -1.0 },
                { 1.0, 1.0, -1.0 },
                { 1.0, 1.0, 1.0 },
                 { -1.0, 1.0, 1.0 } },

                {{ -1.0, -1.0, -1.0 },
                { 1.0, -1.0, -1.0 },
                { 1.0, -1.0, 1.0 },
                { -1.0, -1.0, 1.0 } },

                {{ 1.0, 1.0, 1.0 },
                { 1.0, -1.0, 1.0 },
                { 1.0, -1.0, -1.0 },
                { 1.0, 1.0, -1.0 } },

                {{ -1.0, -1.0, -1.0 },
                { -1.0, 1.0, -1.0 },
                { -1.0, 1.0, 1.0 },
                { -1.0, -1.0, 1.0 } },
            };

            if (texture == null)
            {
                for (int i = 0; i < 6; ++i)
                {
                    gl.Begin(type);
                    if (this.lighting == true)
                        gl.Color(
                            (float)(colorDialog2.Color.R / 255.0),
                            (float)(colorDialog2.Color.G / 255.0),
                            (float)(colorDialog2.Color.B / 255.0));
                    else
                        gl.Color(color.R / 255.0 * 0.5, color.G / 255.0 * 0.5, color.B / 255.0 * 0.5);

                    gl.Vertex(points[i, 0, 0], points[i, 0, 1], points[i, 0, 2]);
                    gl.Vertex(points[i, 1, 0], points[i, 1, 1], points[i, 1, 2]);

                    gl.Color(color.R, color.G, color.B);
                    gl.Vertex(points[i, 2, 0], points[i, 2, 1], points[i, 2, 2]);
                    gl.Vertex(points[i, 3, 0], points[i, 3, 1], points[i, 3, 2]);
                    gl.End();
                }
                gl.Flush();
            }
            else
            {
                texture.Create(gl, Project7.Properties.Resources.texture);
                gl.TexEnv(OpenGL.GL_TEXTURE_ENV, OpenGL.GL_TEXTURE_ENV_MODE, (float)OpenGL.GL_REPLACE);
                gl.Enable(OpenGL.GL_TEXTURE_2D);
                gl.Begin(type);
                for (int i = 0; i < 6; ++i)
                {
                    gl.TexCoord(0, 0);
                    gl.Vertex(points[i, 0, 0], points[i, 0, 1], points[i, 0, 2]);
                    gl.TexCoord(0, 1);
                    gl.Vertex(points[i, 1, 0], points[i, 1, 1], points[i, 1, 2]);
                    gl.TexCoord(1, 0);
                    gl.Vertex(points[i, 2, 0], points[i, 2, 1], points[i, 2, 2]);
                    gl.TexCoord(1, 1);
                    gl.Vertex(points[i, 3, 0], points[i, 3, 1], points[i, 3, 2]);
                }
                gl.End();
                gl.Flush();
                gl.Disable(OpenGL.GL_TEXTURE_2D);
            }
        }*/

        public void glDrawTeaPot(Color color, uint type, Texture texture)
        {
            SharpGL.SceneGraph.Primitives.Teapot teaPot = new SharpGL.SceneGraph.Primitives.Teapot();

            if (texture == null)
            {
                gl.Disable(OpenGL.GL_BLEND);
                gl.Color(color.R, color.G, color.B);
                teaPot.Draw(gl, 4, 1, type);
            }
            else
            {
                //texture.Create(gl, Properties.Resources.texture);
                gl.TexEnv(OpenGL.GL_TEXTURE_ENV, OpenGL.GL_TEXTURE_ENV_MODE, (float)OpenGL.GL_REPLACE);
                gl.Enable(OpenGL.GL_TEXTURE_2D);
                teaPot.Draw(gl, 4, 1, OpenGL.GL_FILL);
                gl.Disable(OpenGL.GL_TEXTURE_2D);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            this.texture = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog2.ShowDialog();
            this.texture = null;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked == true)
            {
                this.texture = new Texture();
            }
            else
            {
                this.texture = null;
            }
        }

        public void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox2.Checked == true)
            {
                this.lighting = true;
            }
            else
            {
                this.lighting = false;
            }
        }
    }
    public class Shape
    {
        protected OpenGL gl;
        protected double[][] vertices;

        protected Shape(double[][] vertices, OpenGL gl)
        {
            this.vertices = vertices;
            this.gl = gl;
        }

        public virtual void draw(double r, double g, double b)
        { }
    }
    public class ShapeHexagon : Shape
    {
        public ShapeHexagon(double[][] vertices, OpenGL gl) : base(vertices, gl)
        { }

        public override void draw(double r, double g, double b)
        {
            if (vertices.Length != 6)
                return;
            gl.Color(r, g, b);
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
        public ShapeTrapeze(double[][] vertices, OpenGL gl) : base(vertices, gl)
        { }

        public override void draw(double r, double g, double b)
        {
            if (vertices.Length != 4)
                return;
            gl.Color(r, g, b);
            gl.Vertex(vertices[0]);
            gl.Vertex(vertices[1]);
            gl.Vertex(vertices[2]);
            gl.Vertex(vertices[3]);
        }
    }
    public class ShapeTriangle : Shape
    {
        public ShapeTriangle(double[][] vertices, OpenGL gl) : base(vertices, gl)
        { }

        public override void draw(double r, double g, double b)
        {
            if (vertices.Length != 3)
                return;
            gl.Color(r, g, b);
            gl.Vertex(vertices[0]);
            gl.Vertex(vertices[1]);
            gl.Vertex(vertices[2]);
            gl.Vertex(vertices[0]);
        }
    }
}
