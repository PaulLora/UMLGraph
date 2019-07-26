using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMLGraph.Grupos.Grupo3.Figuras;
using UMLGraph.Grupos.Grupo3.Interfaz;

namespace UMLGraph.Grupos.Grupo3.Librerias
{
    public static class ControlCanvas
    {
        private static Panel CanvasPanel = new Panel();
        private static CanvasGR3 Canvas { get; set; }
        private static Dictionary<Panel, bool> relatables =
                   new Dictionary<Panel, bool>();
        public static Lista_Figuras Figuras { get; set; } = new Lista_Figuras();
        private static Figura fig { get; set; }
        public static bool Drawing { get; set; }
        public static bool PnlMvd { get; set; }
        public enum TipoRelacion
        {
            Asc,
            Agr,
            Gen,
            Cmp
        }

        public static void Relatable(this Panel panel, bool enable)
        {
            if (enable)
            {
                if (relatables.ContainsKey(panel))
                {
                    return;
                }
                relatables.Add(panel, false);

                panel.Click += PointForRelation;//Se guarda en los puntos para utilizarlos en relaciones
                panel.MouseClick += PnlMouseDown;
                panel.MouseMove += PnlMouseMove;
                panel.MouseUp += PnlMouseUp;
                
            }
            else
            {
                if (!relatables.ContainsKey(panel))
                {
                    return;
                }
                panel.Click -= PointForRelation;//Se guarda en los puntos para utilizarlos en relaciones
                panel.MouseClick -= PnlMouseDown;
                panel.MouseMove -= PnlMouseMove;
                panel.MouseUp -= PnlMouseUp;
                relatables.Remove(panel);
            }
        }

        public static void DefineOrigin(this Panel pan, CanvasGR3 canvas)
        {
            CanvasPanel = pan;
            Canvas = canvas;
            canvas.AddEvent += CreateDeleteEvents;
        }
        static void PointForRelation(object sender, EventArgs e)//cuando drawing esta activado carga las posiciones de los paneles al una lista
        {
            Panel pan = sender as Panel;

            //Figuras.Figuras[0].

            Figura_Relacion rel;
            if (Drawing)
            {
                rel = (Figura_Relacion)Figuras.Figuras.Last();
                Console.WriteLine(rel.FiguraNombre);
                if (!rel.isFull)
                {

                    if (rel.RelIni == null)
                    {
                        rel.RelIni = pan;
                    }
                    else if (rel.RelIni != null && rel.RelFin == null)
                    {
                        rel.RelFin = pan;
                        rel.isFull = true;
                        //rel.RelPuntos.Add(new Point(rel.RelIni.Location.X + rel.RelIni.Size.Width / 2, rel.RelIni.Location.Y + rel.RelIni.Size.Height / 2));
                        //rel.RelPuntos.Add(new Point(rel.RelFin.Location.X + rel.RelFin.Size.Width / 2, rel.RelFin.Location.Y + rel.RelFin.Size.Height / 2));
                    }
                }

                if (rel.isFull)
                {
                    if (rel.FiguraNombre.Substring(0, 3).Equals(TipoRelacion.Gen.ToString()))
                    {
                        Console.WriteLine("Herencia creara");
                        Figura_Generalizacion gen = new Figura_Generalizacion(rel);
                        gen.DibujarFigura();
                        Figuras.Figuras.Add(gen);
                        Figuras.CanvasSize = CanvasPanel.Size;
                        foreach (Control con in gen.Dibujador.RelLines)
                        {
                            CanvasPanel.Controls.Add(con);
                        }
                    }
                    else if (rel.FiguraNombre.Substring(0, 3).Equals(TipoRelacion.Agr.ToString()))
                    {
                        Console.WriteLine("Agregacion creara");
                        Figura_Agregacion gen = new Figura_Agregacion(rel);
                        gen.DibujarFigura();
                        Figuras.Figuras.Add(gen);
                        Figuras.CanvasSize = CanvasPanel.Size;


                        foreach (Control con in gen.Dibujador.RelLines)
                        {
                            CanvasPanel.Controls.Add(con);
                        }
                    }
                    else if (rel.FiguraNombre.Substring(0, 3).Equals(TipoRelacion.Asc.ToString()))
                    {
                        Console.WriteLine("Asociacion creara");
                        Figura_Asociacion gen = new Figura_Asociacion(rel);
                        gen.DibujarFigura();
                        Figuras.Figuras.Add(gen);
                        Figuras.CanvasSize = CanvasPanel.Size;


                        foreach (Control con in gen.Dibujador.RelLines)
                        {
                            CanvasPanel.Controls.Add(con);
                        }
                    }
                    else if (rel.FiguraNombre.Substring(0, 3).Equals(TipoRelacion.Cmp.ToString()))
                    {
                        Console.WriteLine("Generalizacion creara");
                        Figura_Composicion gen = new Figura_Composicion(rel);
                        gen.DibujarFigura();
                        Figuras.Figuras.Add(gen);
                        Figuras.CanvasSize = CanvasPanel.Size;
                        Console.WriteLine(gen.Dibujador.RelLines.Last().Size);

                        foreach (Control con in gen.Dibujador.RelLines)
                        {
                            CanvasPanel.Controls.Add(con);
                        }
                    }

                    //CanvasPanel.Controls.Add(GenArrow);
                    Drawing = false;
                }
            }
        }
        static void PnlMouseDown(object sender, EventArgs e)
        {
            PnlMvd = false;
        }
        static void PnlMouseMove(object sender, EventArgs e)
        {
            PnlMvd = true;
            //Console.WriteLine("Re-Dibujado");
        }
        static List<Figura_Relacion> ActualizarHerencias(Panel pan, String Order)
        {
            List<Figura_Relacion> toDelete = new List<Figura_Relacion>();
            foreach (Figura_Generalizacion rel in Figuras.Figuras.OfType<Figura_Generalizacion>())
            {
                
                if (rel.isFull && rel.Dibujador!=null)
                {
                    if (rel.RelIni.Name == pan.Name)
                    {
                        rel.RelIni = pan;

                        //rel.RelIni.Location = new Point(rel.RelIni.Location.X + 200, rel.RelIni.Location.Y);
                        //rel.RelPuntos[0] = new Point(rel.RelIni.Location.X + rel.RelIni.Size.Width / 2, rel.RelIni.Location.Y + rel.RelIni.Size.Height / 2);
                        foreach (Control con in rel.Dibujador.RelLines)
                        {
                            foreach (Control comp in CanvasPanel.Controls)
                            {
                                if (con == comp)
                                {
                                    CanvasPanel.Controls.Remove(con);
                                    toDelete.Add(rel);
                                }
                            }
                        }
                        if (Order.Equals("Actualizar"))
                        {
                            rel.DibujarFigura();
                            foreach (Control con in rel.Dibujador.RelLines)
                            {
                                CanvasPanel.Controls.Add(con);
                                //toDelete.Add(rel);
                            }
                        }
                        
                    }
                    else if (rel.RelFin.Name == pan.Name)
                    {

                        rel.RelFin = pan;
                        //rel.RelFin.Location = new Point(rel.RelFin.Location.X + 200, rel.RelFin.Location.Y);
                        foreach (Control con in rel.Dibujador.RelLines)
                        {
                            foreach (Control comp in CanvasPanel.Controls)
                            {
                                if (con == comp)
                                {
                                    CanvasPanel.Controls.Remove(con);
                                    toDelete.Add(rel);
                                }
                            }
                        }
                        if (Order.Equals("Actualizar"))
                        {
                            rel.DibujarFigura();
                            foreach (Control con in rel.Dibujador.RelLines)
                            {
                                CanvasPanel.Controls.Add(con);
                                //toDelete.Add(rel);
                            }
                        }
                        //rel.RelPuntos[1] = new Point(rel.RelFin.Location.X + rel.RelFin.Size.Width / 2, rel.RelFin.Location.Y + rel.RelFin.Size.Height / 2);
                    }
                }
                
                //Figuras.ActualizarFiguras();
                //CanvasPanel.BackgroundImage = Image.FromFile(Figuras.GetNewBackground());
            }
            return toDelete;
        }
        static List<Figura_Relacion> ActualizarComposiciones(Panel pan, String Order)
        {
            List<Figura_Relacion> toDelete = new List<Figura_Relacion>();
            foreach (Figura_Composicion rel in Figuras.Figuras.OfType<Figura_Composicion>())
            {
                if (rel.isFull && rel.Dibujador != null)
                {
                    if (rel.RelIni.Name == pan.Name)
                    {
                        rel.RelIni = pan;

                        //rel.RelIni.Location = new Point(rel.RelIni.Location.X + 200, rel.RelIni.Location.Y);
                        //rel.RelPuntos[0] = new Point(rel.RelIni.Location.X + rel.RelIni.Size.Width / 2, rel.RelIni.Location.Y + rel.RelIni.Size.Height / 2);
                        foreach (Control con in rel.Dibujador.RelLines)
                        {
                            foreach (Control comp in CanvasPanel.Controls)
                            {
                                if (con == comp)
                                {
                                    CanvasPanel.Controls.Remove(con);
                                    toDelete.Add(rel);
                                }
                            }
                        }
                        if (Order.Equals("Actualizar"))
                        {
                            rel.DibujarFigura();
                            foreach (Control con in rel.Dibujador.RelLines)
                            {
                                CanvasPanel.Controls.Add(con);
                            }
                        }
                    }
                    else if (rel.RelFin.Name == pan.Name)
                    {

                        rel.RelFin = pan;
                        //rel.RelFin.Location = new Point(rel.RelFin.Location.X + 200, rel.RelFin.Location.Y);
                        foreach (Control con in rel.Dibujador.RelLines)
                        {
                            foreach (Control comp in CanvasPanel.Controls)
                            {
                                if (con == comp)
                                {
                                    CanvasPanel.Controls.Remove(con);
                                    toDelete.Add(rel);
                                }
                            }
                        }
                        if (Order.Equals("Actualizar"))
                        {
                            rel.DibujarFigura();
                            foreach (Control con in rel.Dibujador.RelLines)
                            {
                                CanvasPanel.Controls.Add(con);
                            }
                        }
                        //rel.RelPuntos[1] = new Point(rel.RelFin.Location.X + rel.RelFin.Size.Width / 2, rel.RelFin.Location.Y + rel.RelFin.Size.Height / 2);
                    }
                }
                
                //Figuras.ActualizarFiguras();
                //CanvasPanel.BackgroundImage = Image.FromFile(Figuras.GetNewBackground());
            }
            return toDelete;
        }
        static List<Figura_Relacion> ActualizarAsociaciones(Panel pan, String Order)
        {
            List<Figura_Relacion> toDelete = new List<Figura_Relacion>();
            foreach (Figura_Asociacion rel in Figuras.Figuras.OfType<Figura_Asociacion>())
            {
                if (rel.isFull && rel.Dibujador != null)
                {
                    if (rel.RelIni.Name == pan.Name)
                    {
                        rel.RelIni = pan;

                        //rel.RelIni.Location = new Point(rel.RelIni.Location.X + 200, rel.RelIni.Location.Y);
                        //rel.RelPuntos[0] = new Point(rel.RelIni.Location.X + rel.RelIni.Size.Width / 2, rel.RelIni.Location.Y + rel.RelIni.Size.Height / 2);
                        foreach (Control con in rel.Dibujador.RelLines)
                        {
                            foreach (Control comp in CanvasPanel.Controls)
                            {
                                if (con == comp)
                                {
                                    CanvasPanel.Controls.Remove(con);
                                    toDelete.Add(rel);
                                }
                            }
                        }
                        if (Order.Equals("Actualizar"))
                        {
                            rel.DibujarFigura();
                            foreach (Control con in rel.Dibujador.RelLines)
                            {
                                CanvasPanel.Controls.Add(con);
                            }
                        }
                    }
                    else if (rel.RelFin.Name == pan.Name)
                    {

                        rel.RelFin = pan;
                        //rel.RelFin.Location = new Point(rel.RelFin.Location.X + 200, rel.RelFin.Location.Y);
                        foreach (Control con in rel.Dibujador.RelLines)
                        {
                            foreach (Control comp in CanvasPanel.Controls)
                            {
                                if (con == comp)
                                {
                                    CanvasPanel.Controls.Remove(con);
                                    toDelete.Add(rel);
                                }
                            }
                        }
                        if (Order.Equals("Actualizar"))
                        {
                            rel.DibujarFigura();
                            foreach (Control con in rel.Dibujador.RelLines)
                            {
                                CanvasPanel.Controls.Add(con);
                            }
                        }
                        //rel.RelPuntos[1] = new Point(rel.RelFin.Location.X + rel.RelFin.Size.Width / 2, rel.RelFin.Location.Y + rel.RelFin.Size.Height / 2);
                    }
                }
               
                //Figuras.ActualizarFiguras();
                //CanvasPanel.BackgroundImage = Image.FromFile(Figuras.GetNewBackground());
            }
            return toDelete;
        }
        static List<Figura_Relacion> ActualizarAgregaciones(Panel pan, String Order)
        {
            List<Figura_Relacion> toDelete = new List<Figura_Relacion>();
            foreach (Figura_Agregacion rel in Figuras.Figuras.OfType<Figura_Agregacion>())
            {
                if (rel.isFull && rel.Dibujador != null)
                {
                    if (rel.RelIni.Name == pan.Name)
                    {
                        rel.RelIni = pan;

                        //rel.RelIni.Location = new Point(rel.RelIni.Location.X + 200, rel.RelIni.Location.Y);
                        //rel.RelPuntos[0] = new Point(rel.RelIni.Location.X + rel.RelIni.Size.Width / 2, rel.RelIni.Location.Y + rel.RelIni.Size.Height / 2);
                        foreach (Control con in rel.Dibujador.RelLines)
                        {
                            foreach (Control comp in CanvasPanel.Controls)
                            {
                                if (con == comp)
                                {
                                    CanvasPanel.Controls.Remove(con);
                                    toDelete.Add(rel);
                                }
                            }
                        }
                        if (Order.Equals("Actualizar"))
                        {
                            rel.DibujarFigura();
                            foreach (Control con in rel.Dibujador.RelLines)
                            {
                                CanvasPanel.Controls.Add(con);
                            }
                        }
                    }
                    else if (rel.RelFin.Name == pan.Name)
                    {

                        rel.RelFin = pan;
                        //rel.RelFin.Location = new Point(rel.RelFin.Location.X + 200, rel.RelFin.Location.Y);
                        foreach (Control con in rel.Dibujador.RelLines)
                        {
                            foreach (Control comp in CanvasPanel.Controls)
                            {
                                if (con == comp)
                                {
                                    CanvasPanel.Controls.Remove(con);
                                    toDelete.Add(rel);
                                }
                            }
                        }
                        if (Order.Equals("Actualizar"))
                        {
                            rel.DibujarFigura();
                            foreach (Control con in rel.Dibujador.RelLines)
                            {
                                CanvasPanel.Controls.Add(con);
                            }
                        }
                        //rel.RelPuntos[1] = new Point(rel.RelFin.Location.X + rel.RelFin.Size.Width / 2, rel.RelFin.Location.Y + rel.RelFin.Size.Height / 2);
                    }
                }
                
                //Figuras.ActualizarFiguras();
                //CanvasPanel.BackgroundImage = Image.FromFile(Figuras.GetNewBackground());
            }
            return toDelete;
        }
        static void PnlMouseUp(object sender, EventArgs e)
        {
            Panel pan = sender as Panel;
            //Console.WriteLine("Re-Dibujado1");
            if (!PnlMvd)
            {
                //Console.WriteLine("Re-Dibujado2");
                ActualizarAgregaciones(pan, "Actualizar");
                ActualizarAsociaciones(pan, "Actualizar");
                ActualizarComposiciones(pan, "Actualizar");
                ActualizarHerencias(pan, "Actualizar");


            }

            //Console.WriteLine("Re-Dibujado2");
        }
        static void CreateDeleteEvents()
        {
            foreach(Figura_Clase fig in Figuras.Figuras.OfType<Figura_Clase>())
            {
                fig.DeleteEvent += BorrarClase;
            }
        }
        static void BorrarClase(object sender)
        {
            Panel pan = sender as Panel;
            foreach(Panel pnl in CanvasPanel.Controls.OfType<Panel>())
            {
                if(pnl.Name == pan.Name)
                {
                    CanvasPanel.Controls.Remove(pnl);
                }
            }
            List<Figura_Relacion> toDelete = new List<Figura_Relacion>();
            toDelete = ActualizarAgregaciones(pan, "");
            foreach (Figura_Relacion dlt in toDelete)
            {
                Figuras.Figuras.Remove(dlt);
            }
            toDelete=ActualizarAgregaciones(pan, "");
            foreach (Figura_Relacion dlt in toDelete)
            {
                Figuras.Figuras.Remove(dlt);
            }
            toDelete =ActualizarAsociaciones(pan, "");
            foreach (Figura_Relacion dlt in toDelete)
            {
                Figuras.Figuras.Remove(dlt);
            }
            toDelete =ActualizarComposiciones(pan, "");
            foreach (Figura_Relacion dlt in toDelete)
            {
                Figuras.Figuras.Remove(dlt);
            }
            toDelete =ActualizarHerencias(pan, "");
            foreach (Figura_Relacion dlt in toDelete)
            {
                Figuras.Figuras.Remove(dlt);
            }
            foreach (Figura_Relacion rel in Figuras.Figuras.OfType<Figura_Relacion>())
            {
                if (rel.RelIni.Name == pan.Name)
                {
                    foreach (Control con in rel.Dibujador.RelLines)
                    {
                        foreach (Control comp in CanvasPanel.Controls)
                        {
                            if (con == comp)
                            {
                                CanvasPanel.Controls.Remove(con);
                                toDelete.Add(rel);
                            }
                        }
                    }
                }
                else if (rel.RelFin.Name == pan.Name)
                {
                    foreach (Control con in rel.Dibujador.RelLines)
                    {
                        foreach (Control comp in CanvasPanel.Controls)
                        {
                            if (con == comp)
                            {
                                CanvasPanel.Controls.Remove(con);
                                toDelete.Add(rel);
                            }
                        }
                    }
                }

            }
            
        }
    }
    
}

