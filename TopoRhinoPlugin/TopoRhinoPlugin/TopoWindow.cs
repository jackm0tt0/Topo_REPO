using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using Eto.Forms;
using Rhino;

namespace TopoRhinoPlugin
{
    public class TopoWindow
    {

        private Eto.Forms.Form _window;

        public Eto.Forms.Form window
        {
            get { return _window; }
            set { _window = value; }
        }
        public TopoWindow()
        {
            this.build_window();
        }

        private void build_window()
        {
            Form window = new Form();
            Eto.Forms.StackLayout vstack = new Eto.Forms.StackLayout();
            Eto.Forms.Button b1 = new Eto.Forms.Button();
            b1.Text = "click me";
            b1.Click += (sender, e) =>
            {
                RhinoApp.WriteLine("I clicked a button");
            };
            vstack.Items.Add(b1);
            window.Content = vstack;

            window.Closed += (sender, e) =>
            {
                RhinoApp.WriteLine("window was closed");
                this.window = null;
            };

            this.window =  window;
        }

        public void toggle()
        {
            if (this.window == null) { this.build_window(); }
            if (this.window.Visible) { this.window.BringToFront(); }
            if (! this.window.Visible) { this.window.Show(); }
        }
    }
}
