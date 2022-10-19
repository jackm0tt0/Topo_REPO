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

        private Rhino.DocObjects.ObjRef _obj_ref;

        public Rhino.DocObjects.ObjRef obj_ref
        {
            get { return _obj_ref; }
            set { _obj_ref = value; }
        }

        private DoubleClickMenu _doubleclickmenu;

        public DoubleClickMenu doubleclickmenu
        {
            get { return _doubleclickmenu; }
            set { _doubleclickmenu = value; }
        }

        private event EventHandler event_update;

        public TopoWindow()
        {
            this.build_window();
            this.doubleclickmenu = new DoubleClickMenu();

            this.window.MouseDoubleClick += (sender, e) =>
            {
                this.doubleclickmenu.toggle();
            };
        }

        public void update()
        {
            event_update?.Invoke(this, EventArgs.Empty);
        }

        private void build_window()
        {
            Form window = new Form();
            window.Icon = Eto.Drawing.Icon.FromResource("TopoRhinoPlugin.EmbeddedResources.smile.bmp");
            window.Title = "Manatee";
            window.Padding = 10;
            window.Width = 800;
            window.Height = 800;

            build_menu(window);

            build_header(window);

            build_body(window);

            window.Closed += (sender, e) =>
            {
                RhinoApp.WriteLine("window was closed");
                this.window = null;
            };

            this.window = window;
        }

        private void build_menu(Eto.Forms.Window window)
        {
            Eto.Forms.MenuBar mainmenu = new Eto.Forms.MenuBar();
            window.Menu = mainmenu;

            Eto.Forms.ContextMenu sub_file = new Eto.Forms.ContextMenu();
            Eto.Forms.MenuItem menu_file = new Eto.Forms.ButtonMenuItem();
            menu_file.Text = "File";
            menu_file.Click += (sender, e) =>
            {
                RhinoApp.WriteLine("You Clicked File");
                sub_file.Show();
            };

            Eto.Forms.MenuItem file_e1 = new Eto.Forms.ButtonMenuItem();
            file_e1.Text = "element_1";
            sub_file.Items.Add(file_e1);

            window.Menu.Items.Add(menu_file);

            Eto.Forms.MenuItem menu_edit = new Eto.Forms.ButtonMenuItem();
            menu_edit.Text = "Edit";
            menu_edit.Click += (sender, e) =>
            {
                RhinoApp.WriteLine("You Clicked Edit");
            };
            window.Menu.Items.Add(menu_edit);
        }

        private void build_header(Eto.Forms.Window window)
        {
            return;
        }

        private void build_body(Eto.Forms.Window window)
        {
            Eto.Forms.StackLayout mainstack = new Eto.Forms.StackLayout();

            Eto.Forms.Label l_type = new Eto.Forms.Label();
            l_type.Text = "Type: ";
            mainstack.Items.Add(l_type);
            this.event_update += (sender, e) =>
            {
                if (this.obj_ref == null) { 
                    l_type.Text = "Type: ";
                    return;
                }
                else if (this.obj_ref.GeometryComponentIndex.Index == -1)
                {
                    l_type.Text = "Type: " + this.obj_ref.Geometry().GetType().ToString();
                }
                else
                {
                    l_type.Text = "Type: " + this.obj_ref.GeometryComponentIndex.ComponentIndexType.ToString();
                }
                
            };

            window.Content = mainstack;

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
        }

        public void toggle()
        {
            if (this.window == null) { this.build_window(); }
            if (this.window.Visible) { this.window.BringToFront(); }
            if (! this.window.Visible) { this.window.Show(); }
        }

    }
}
