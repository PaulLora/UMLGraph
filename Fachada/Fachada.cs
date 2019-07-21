﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMLGraph.Grupos.Grupo3.Interfaz;

namespace UMLGraph
{
    class Fachada
    {
        public Panel EjecutarEnunciado1(Panel panel)
        {
            panel.Dispose();
            return panel;
        }
        public void EjecutarEnunciado2()
        {



        }
        public Panel EjecutarEnunciado3(ref Panel panel)
        {

            CanvasGR3 gr3;
            gr3 = new CanvasGR3(new Size(panel.Width * 3, panel.Height * 3));
            panel.Dispose();
            return gr3.CanvasPanel;

        }
        public Panel EjecutarEnunciado4(ref Panel panel)
        {
            panel.Dispose();
            panel = new Panel();
            GraficaGrupo4 graph4 = new GraficaGrupo4(panel);
            panel = graph4.dibujar();
            return panel;
            
        }
        public void EjecutarEnunciado5()
        {

        }
        public void EjecutarEnunciado6()
        {

        }

    }
}
