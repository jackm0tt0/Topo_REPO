using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino;
using Eto;

namespace TopoRhinoPlugin
{
    public class DoubleClickMenu
    {

        public Eto.Forms.ContextMenu contextMenu;

        public DoubleClickMenu()
        {
            this.contextMenu = null;
            
        }

        public void toggle()
        {   
            if (this.contextMenu == null)
            {
                build_contextMenu();
            }
            this.contextMenu.Show();
        }

        private void build_contextMenu()
        {
            Eto.Forms.ContextMenu contextMenu = new Eto.Forms.ContextMenu();

            Eto.Forms.MenuItem b0 = new Eto.Forms.ButtonMenuItem();
            b0.Text = "secret button";
            contextMenu.Items.Add(b0);
            b0.Click += (sender, e) =>
            {
                RhinoApp.WriteLine("you found a secret button");
            };

            this.contextMenu = contextMenu;
        }
    }
}
