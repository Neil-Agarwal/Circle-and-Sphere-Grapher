using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Object_Orientation_Programming
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Variables
        Circle c1 = new Circle();
        Circle c2 = new Circle();
        Sphere s1 = new Sphere();
        Sphere s2 = new Sphere();

        //Circle Class (Parent)
        public class Circle
        {
            //Variables
            protected int centerX;
            protected int centerY;
            protected int rad;
            public Color col;

            //Intializes variables
            public void Initialize(int x, int y, int r, Color colour)
            {
                SetX(x);
                SetY(y);
                SetR(r);
                this.col = colour;
            }

            //Constructor-Sets default values 
            public Circle()
            {
                Initialize(0, 0, 1, Color.White);
            }
            //Constructor- Sets values as specified by user
            public Circle(int x, int y, int r, Color colour)
            {
                Initialize(x, y, r, colour);
            }
            //Constructor- Sets another circle with the same member values
            public Circle(Circle other)
            {
                Initialize(other.centerX, other.centerY, other.rad, other.col);
            }
            //Sets value of X Coordinate
            public void SetX(Int32 X)
            {
                if (centerX < 0)
                    centerX = -centerX;
                this.centerX = X;
            }
            //Sets value of Y Coordinate
            public void SetY(Int32 Y)
            {
                if (centerY < 0)
                    centerY = -centerY;
                this.centerY = Y;
            }
            //Sets value of Radius
            public void SetR(Int32 R)
            {
                if (rad < 0)
                    rad = rad * -1;
                this.rad = R;
            }
            //Gets value of X Coordinate
            public Int32 GetX()
            {
                return this.centerX;
            }
            //Gets value of Y Coordinate
            public Int32 GetY()
            {
                return this.centerY;
            }
            //Gets value of Radius
            public Int32 GetR()
            {
                return this.rad;
            }
            //Draw Circle in Picturebox
            public void DrawCircle(Graphics e)
            {
                Pen myPen = new Pen(col, 1);
                e.DrawEllipse(myPen, centerX - rad, centerY - rad, 2 * rad, 2 * rad);
            }
            //Find the Area of Circle and Display it in a MessageBox
            public double FindArea()
            {
                double A = Math.PI * Math.Pow(rad, 2);
                A = Math.Round(A, 2);
                return A;
            }
            //Find the Perimeter of Circle and Display it in a MessageBox
            public double FindPeri()
            {
                double P = (2 * Math.PI) * rad;
                P = Math.Round(P, 2);
                return P;
            }
            //Calculates whether or not specified point is within circle using 1 parameter
            public int IsInside(Point point)
            {
                double length = ((Math.Sqrt(Math.Pow(point.X - centerX, 2) + (Math.Pow(point.Y - centerY, 2)))));
                if (length == rad)
                    return 0;
                else if (length > rad)
                    return 1;
                else
                    return -1;
            }
            //Calculates whether or not specified point is within circle using 2 parameters
            public int IsInside(int PointX, int PointY)
            {
                double length = ((Math.Sqrt(Math.Pow(PointX - centerX, 2) + (Math.Pow(PointY - centerY, 2)))));
                if (length == rad)
                    return 0;
                else if (length > rad)
                    return 1;
                else
                    return -1;
            }
            //Compares 2 circles using the radius
            public int Compare(Circle other)
            {
                if (this.rad > other.rad)
                    return 1;
                else if (this.rad < other.rad)
                    return -1;
                else
                    return 0;
            }
            //Overloads == operator
            public static bool operator ==(Circle cL, Circle cR)
            {
                if (cL.rad == cR.rad)
                    return true;
                else
                    return false;
            }
            //Overloads != operator
            public static bool operator !=(Circle cL, Circle cR)
            {
                if (cL.rad != cR.rad)
                    return true;
                else
                    return false;
            }
            //Overloads > operator
            public static bool operator >(Circle cL, Circle cR)
            {
                if (cL.rad > cR.rad)
                    return true;
                else
                    return false;
            }
            //Overloads < operator
            public static bool operator <(Circle cL, Circle cR)
            {
                if (cL.rad < cR.rad)
                    return true;
                else
                    return false;
            }

        }
        //Sphere Class (Child)
        public class Sphere : Circle
        {
            //Declare protected variable
            protected int z;
            //Recognize Circle as Parent Class
            public Sphere()
                : base()
            {
                z = 0;
            }
            public Sphere(int centerX, int centerY, int rad, Color col, Graphics e, int centerZ)
                : base(centerX, centerY, rad, col)
            {
                z = centerZ;
            }
            //Get Z
            public Int32 GetZ()
            {
                return this.z;
            }
            //Set Z
            public void SetZ(Int32 centerZ)
            {
                if (centerZ < 0)
                    centerZ = -centerZ;
                this.z = centerZ;
            }
            //Draw Sphere in Picturebox
            public void DrawSphere(Graphics e)
            {
                SolidBrush mySphereBrush = new SolidBrush(col);
                e.FillEllipse(mySphereBrush, centerX - rad, centerY - rad, 2 * rad, 2 * rad);

                Pen myPen = new Pen(Color.FromArgb(255 - col.R, 255 - col.G, 255 - col.B));
                e.DrawLine(myPen, centerX, centerY, centerX + rad, centerY);
                myPen.DashStyle = DashStyle.Dash;
                e.DrawEllipse(myPen, centerX - rad, centerY - (rad / 4), 2 * rad, rad / 2);
            }
           //Throw exception for being asked to find the perimeter of a sphere
            public new double FindPeri()
            {
                throw new System.ArgumentException("Error: Cannot find perimeter of a sphere. Try Volume instead.");
            }
            //Find Surface Area of Sphere
            public double FindSA()
            {
                double SA = 4 * Math.PI * Math.Pow(rad, 2);
                SA = Math.Round(SA, 2);
                return SA;
            }
            //Find Volume of Sphere
            public double FindVol()
            {
                double Vol = (4 / 3) * Math.PI * Math.Pow(rad, 3);
                Vol = Math.Round(Vol, 2);
                return Vol;
            }
            //Calculates whether or not the specified point is on the sphere
            public int IsInsideSphere(int pointX, int pointY, int pointZ)
            {
                double length = Math.Sqrt((Math.Pow(pointX - centerX, 2)) + (Math.Pow(pointY - centerY, 2)) + (Math.Pow(pointZ - z, 2)));
                if (length == rad)
                    return 0;
                else if (length > rad)
                    return 1;
                else
                    return -1;
            }
        }
        //Draws Circle 1
        private void btnCircle1Draw_Click_1(object sender, EventArgs e)
        {
            colorDlg.ShowDialog();
            Color colour = colorDlg.Color;
            c1.Initialize(Convert.ToInt32(numCircle1X.Value), Convert.ToInt32(numCircle1Y.Value), Convert.ToInt32(numCircle1R.Value), colour);
            pbxImage.Invalidate();
        }
        //Draws Circle 2
        private void btnCircle2Draw_Click(object sender, EventArgs e)
        {
            colorDlg.ShowDialog();
            Color colour = colorDlg.Color;
            c2.Initialize(Convert.ToInt32(numCircle2X.Value), Convert.ToInt32(numCircle2Y.Value), Convert.ToInt32(numCircle2R.Value), colour);
            pbxImage.Invalidate();
        }
        //Draws Sphere 1
        private void btnSphere1Draw_Click(object sender, EventArgs e)
        {
            colorDlg.ShowDialog();
            Color colour = colorDlg.Color;
            s1.Initialize(Convert.ToInt32(numSphere1X.Value), Convert.ToInt32(numSphere1Y.Value), Convert.ToInt32(numSphere1R.Value), colour);
            pbxImage.Invalidate();
        }
        //Draws Sphere 2
        private void btnSphere2Draw_Click(object sender, EventArgs e)
        {
            colorDlg.ShowDialog();
            Color colour = colorDlg.Color;
            s2.Initialize(Convert.ToInt32(numSphere2X.Value), Convert.ToInt32(numSphere2Y.Value), Convert.ToInt32(numSphere2R.Value), colour);
            pbxImage.Invalidate();
        }
        //Find Area of Circle
        private void btnArea_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(c1.FindArea().ToString());
        }
        //Find Area of Circle 2
        private void btnArea2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(c2.FindArea().ToString());
        }
        //Find Surface Area of Sphere 1 
        private void btnSphere1Area_Click(object sender, EventArgs e)
        {
            MessageBox.Show(s1.FindSA().ToString());
        }
        //Find Surface Area of Sphere 2
        private void btnSphere2Area_Click(object sender, EventArgs e)
        {
            MessageBox.Show(s2.FindSA().ToString());
        }
        //Find Perimeter of Circle 1
        private void btnPeri_Click(object sender, EventArgs e)
        {
            MessageBox.Show(c1.FindPeri().ToString());
        }
        //Find Perimeter of Circle 2
        private void btnPerimeter2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(c2.FindPeri().ToString());
        }
        //Find Volume of Sphere 1
        private void btnSphere1Vol_Click(object sender, EventArgs e)
        {
            MessageBox.Show(s1.FindVol().ToString());
        }
        //Find Volume of Sphere 2
        private void btnSphere2Vol_Click(object sender, EventArgs e)
        {
            MessageBox.Show(s2.FindVol().ToString());
        }
        //Displays message to user concerning whether or not specified point is inside Circle 1
        private void btnIsInside_Click_1(object sender, EventArgs e)
        {
            Point point = new Point((Int32)numCircle1PointX.Value, (Int32)numCircle1PointY.Value);
            if (c1.IsInside(point) == 0)
                MessageBox.Show("The specified point lies on the circle.");
            else if (c1.IsInside(point) == 1)
                MessageBox.Show("The specified point lies outside the circle.");
            else
                MessageBox.Show("The specified point lies inside the circle.");
        }
        //Displays message to user concerning whether or not specified point is inside Circle 2
        private void btnIsInsideR_Click(object sender, EventArgs e)
        {
            Point point = new Point((Int32)numCircle2PointX.Value, (Int32)numCircle2PointY.Value);
            if (c2.IsInside(point) == 0)
                MessageBox.Show("The specified point lies on the circle.");
            else if (c2.IsInside(point) == 1)
                MessageBox.Show("The specified point lies outside the circle.");
            else
                MessageBox.Show("The specified point lies inside the circle.");
        }
        //Displays message to user concerning whether or not specified point is inside Sphere 1
        private void btnSphere1Inside_Click(object sender, EventArgs e)
        {
            if (s1.IsInsideSphere((Int32)numSphere1PointX.Value, (Int32)numSphere1PointY.Value, (Int32)numSphere1PointZ.Value) == 0)
                MessageBox.Show("The specified point lies on the border sphere.");
            else if (s1.IsInsideSphere((Int32)numSphere1PointX.Value, (Int32)numSphere1PointY.Value, (Int32)numSphere1PointZ.Value) == 1)
                MessageBox.Show("The specified point lies outside the sphere.");
            else
                MessageBox.Show("The specified point lies inside the sphere.");
        }
        //Displays message to user concerning whether or not specified point is inside Sphere 2
        private void btnSphere2Inside_Click(object sender, EventArgs e)
        {
            if (s2.IsInsideSphere((Int32)numSphere2PointX.Value, (Int32)numSphere2PointY.Value, (Int32)numSphere2PointZ.Value) == 0)
                MessageBox.Show("The specified point lies on the border sphere.");
            else if (s2.IsInsideSphere((Int32)numSphere2PointX.Value, (Int32)numSphere2PointY.Value, (Int32)numSphere2PointZ.Value) == 1)
                MessageBox.Show("The specified point lies outside the sphere.");
            else
                MessageBox.Show("The specified point lies inside the sphere.");
        }
        //Displays message to user about which Circle is bigger after comparison
        private void btnCompare_Click(object sender, EventArgs e)
        {
            if (c1.Compare(c2) == 1)
                MessageBox.Show("Circle 1 is bigger than Circle 2");
            else if (c1.Compare(c2) == -1)
                MessageBox.Show("The Circle 2 is bigger than Circle 1");
            else
                MessageBox.Show("The circles are the same size.");
        }
        //Displays message to user about which Sphere is bigger after comparison
        private void btnCompareSpheres_Click(object sender, EventArgs e)
        {
            if (s1.Compare(s2) == 1)
                MessageBox.Show("Sphere 1 is bigger than Sphere 2");
            else if (s1.Compare(s2) == -1)
                MessageBox.Show("Sphere 2 is bigger than Sphere 1");
            else
                MessageBox.Show("The spheres are the same size.");
        }
        //Updates Picturebox
        private void pbxImage_Paint_1(object sender, PaintEventArgs e)
        {
            c1.DrawCircle(e.Graphics);
            c2.DrawCircle(e.Graphics);
            s1.DrawSphere(e.Graphics);
            s2.DrawSphere(e.Graphics);
        }
    }
}