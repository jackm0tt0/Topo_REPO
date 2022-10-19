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

        private Rhino.Geometry.GeometryBase _geom;

        public Rhino.Geometry.GeometryBase geom
        {
            get { return _geom; }
            set { _geom = value; }
        }

        private event EventHandler event_update;

        public TopoWindow()
        {
            this.build_window();
        }

        public void update()
        {
            event_update?.Invoke(this, EventArgs.Empty);
        }

        private void build_window()
        {
            Form window = new Form();
            // Main VStack
            Eto.Forms.StackLayout vstack = new Eto.Forms.StackLayout();


            Eto.Forms.Label l_object = new Eto.Forms.Label();
            l_object.Text = "Object: ";
            vstack.Items.Add(l_object);
            this.event_update += (sender, e) =>
            {
                l_object.Text = "Object: " + this.geom.ToString();
            };


            Eto.Forms.Label l_guid = new Eto.Forms.Label();
            l_guid.Text = "GUID: ";
            vstack.Items.Add(l_guid);
            this.event_update += (sender, e) =>
            {
                l_guid.Text = "Object: " + this.geom.ToString();
            };

            Eto.Forms.Label l_type = new Eto.Forms.Label();
            l_type.Text = "Type: ";
            vstack.Items.Add(l_type);
            this.event_update += (sender, e) =>
            {
                l_type.Text = "Object: " + this.geom.GetType().ToString();
            };

            //// First Item
            //Eto.Forms.Button b1 = new Eto.Forms.Button();
            //b1.Text = "click me";
            //b1.Click += (sender, e) =>
            //{
            //    RhinoApp.WriteLine("I clicked a button");
            //    b1.BackgroundColor = Eto.Drawing.Color.FromRgb(0xff10ff);
            //    b1.Image = Eto.Drawing.Bitmap.FromResource("TopoRhinoPlugin.EmbeddedResources.smile.bmp");
            //};
            //vstack.Items.Add(b1);

            //Eto.Forms.Slider slider_1 = new Eto.Forms.Slider();
            //slider_1.MinValue = 0;
            //slider_1.MaxValue = 100;
            //slider_1.BackgroundColor = Eto.Drawing.Color.FromRgb(0xffff50);

            //Eto.Forms.Label slider_1_value = new Eto.Forms.Label();
            //slider_1_value.Text = "Value: 0";
            //slider_1.ValueChanged += (sender, e) =>
            //{
            //    slider_1_value.Text = "Value: " + slider_1.Value.ToString();
            //};


            //vstack.Items.Add(slider_1);
            //vstack.Items.Add(slider_1_value);


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
