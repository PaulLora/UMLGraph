using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMLGraph.Grupos.Grupo3.Librerias
{
    public class Dibujador_Relacion
    {
        public Point RelIni { get; set; }
        public Point RelFin { get; set; }
        public Point ConPoint { get; set; }
        public List<Control> RelLines { get; set; }
        public List<Movement> RelMoves { get; set; }
        public LineOrientation DetermineOrientation()
        {
            if (RelIni.X == RelFin.X)
            {
                return LineOrientation.Vertical;
            }
            else if (RelIni.Y == RelFin.Y)
            {
                return LineOrientation.Horizontal;
            }
            else
            {
                return LineOrientation.DiagonalDown;
            }
        }
        public Movement DetermineWeightMovement(int alpha, int beta)
        {
            if(beta - alpha < 0)
            {
                return Movement.Left;
            }
            else
            {
                return Movement.Right;
            }
        }
        public Movement DetermineHeightMovement(int alpha, int beta)
        {
            if (beta - alpha < 0)
            {
                return Movement.Up;
            }
            else
            {
                return Movement.Down;
            }
        }
        public void DetermineMovement()
        {

            RelMoves = new List<Movement>();
            RelMoves.Add(DetermineHeightMovement(RelIni.Y, RelFin.Y));
            RelMoves.Add(DetermineWeightMovement(RelIni.X, RelFin.X));
        }
        public void OrdenarPuntos()
        {
            if (RelFin.Y < RelIni.Y && RelFin.X < RelIni.X)
            {
                //if(RelFin.Y < RelIni.Y)
                //{
                Point tmp = RelIni;
                RelIni = RelFin;
                RelFin = tmp;
                //}
            }
            else if(RelFin.Y == RelIni.Y)
            {
                if(RelFin.X < RelIni.X)
                {
                    Point tmp = RelIni;
                    RelIni = RelFin;
                    RelFin = tmp;
                }
            }
        }
        public Line UpLine()
        {
            Line temp = new Line
            {
                Location = new Point(RelIni.X, RelFin.Y),
                Orientation = LineOrientation.Vertical,
                Height = Math.Abs(RelIni.Y - RelFin.Y)
            };
            ConPoint = temp.Location;
            return temp;
        }
        public Line DownLine()
        {
            Line temp = new Line
            {
                Location = RelIni,
                Orientation = LineOrientation.Vertical,
                Height = Math.Abs(RelIni.Y - RelFin.Y)
            };
            ConPoint = new Point(temp.Location.X, temp.Location.Y + temp.Height);
            return temp;
        }
        public Line LeftLine()
        {
            //Console.WriteLine("Izquiera");
            Line temp = new Line
            {
                Orientation = LineOrientation.Horizontal,
                Location = new Point(ConPoint.X - RelIni.X + RelFin.X, ConPoint.Y),
                Width = Math.Abs(RelIni.X - RelFin.X)
            };
            ConPoint = new Point(temp.Location.X, temp.Location.Y);
            return temp;
            
        }
        public Line RightLine()
        {
            Line temp = new Line
            {
                Orientation = LineOrientation.Horizontal,
                Location = new Point(ConPoint.X, ConPoint.Y),
                Width = Math.Abs(RelIni.X - RelFin.X)
            };
            ConPoint = new Point(temp.Location.X + temp.Width, temp.Location.Y);
            return temp;

        }
        public void CrearLineas()
        {
            OrdenarPuntos();
            Line temp = new Line();
            temp.Location = RelIni;
            
            if (DetermineOrientation() == LineOrientation.Vertical)
            {
                temp.Orientation = DetermineOrientation();
                temp.Height = Math.Abs(RelIni.Y - RelFin.Y);
                RelLines.Add(temp);
                
            }
            else if (DetermineOrientation() == LineOrientation.Horizontal)
            {
                temp.Orientation = DetermineOrientation();
                temp.Width = Math.Abs(RelIni.X - RelFin.X);
                RelLines.Add(temp);
            }
            else
            {
                DetermineMovement();
                if (RelMoves[0] == Movement.Up)
                {
                    temp = UpLine();
                    //Console.WriteLine("UP draw");
                    RelLines.Add(temp);
                    if (RelMoves[1] == Movement.Right)
                    {
                        temp = RightLine();
                        RelLines.Add(temp);
                    }
                    else
                    {
                        temp = LeftLine();
                        RelLines.Add(temp);
                    }
                }
                else
                {
                    temp = DownLine();
                    RelLines.Add(temp);
                    if (RelMoves[1] == Movement.Right)
                    {
                        temp = RightLine();
                        RelLines.Add(temp);
                    }
                    else
                    {
                        temp = LeftLine();
                        RelLines.Add(temp);
                    }
                }
                
                
            }

            //temp
        }
        public Dibujador_Relacion()
        {
            RelLines = new List<Control>();
        }
        public enum Movement
        {
            Up,
            Down,
            Left,
            Right
        }
    }
}
