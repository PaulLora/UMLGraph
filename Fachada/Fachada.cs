    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using UMLGraph.Grupos.Grupo5;
    using UMLGraph.Grupos.Grupo3.Interfaz;
    using UMLGraph.Grupos.Grupo6.Vista;
    using NClass.GUI;
    using UMLGraph.Grupos;
    using UMLGraph.Grupos.Grupo6.Vista;

    namespace UMLGraph
    {
        //Esta es la clase fachada desde la cual cada método direcciona a cada subsitema del grupo que corresponda
        class Fachada
        {
        
            public Panel EjecutarEnunciado1(Panel panel)
            {
                new UMLGraph.Grupos.Grupo1.GUI1().Show();
                return panel;
            }

            public Panel EjecutarEnunciado2(ref Panel panel) //Este método referencia al subsistema del grupo 2 (Gaby)
            {
                MainForm project = new MainForm();
                project.TopLevel = false;
                project.AutoScroll = true;
                project.Width = 1500;//panel.Width;
                project.Height = 900;//panel.Height;
                panel.Controls.Add(project);
                project.Show();
                return panel;
            }
            public Panel EjecutarEnunciado3(ref Panel panel)
            {

                panel.Controls.Clear();
                CanvasGR3 gr3;
                gr3 = new CanvasGR3(new Size(panel.Width * 3, panel.Height * 3));
                return gr3.CanvasPanel;

            }
            public Panel EjecutarEnunciado4(Panel panel) //Este método referencia al subsistema del grupo 4 (Paúl), el método recibe el pnlDibujar y se devolverá el mismo panel con los controles llenos.
            {
                panel.Controls.Clear(); //Limpia el pnlDibujar. Sirve para el cambio de grupo a grupo.
                GraficaGrupo4 graph4 = new GraficaGrupo4(panel); 
                panel = graph4.dibujar(); //Llena el panel con todos los controles
                return panel;      
            }
            public Panel EjecutarEnunciado5(Panel panel)
            {       
                GraficaGrupo5 graph5 = new GraficaGrupo5(panel);
                  return panel;           
            }

            public Panel EjecutarEnunciado6(Panel areaTrabajo)
            {

                PantallaTrabajoGr6 gr6 = new PantallaTrabajoGr6(areaTrabajo);
                areaTrabajo = gr6.dibujarPnl_areaTrabajo();
                return areaTrabajo;
            }

        }
    }
