using Rhino;
using Rhino.Commands;
using Rhino.Geometry;
using Rhino.Input;
using Rhino.Input.Custom;
using Rhino.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Linq.Expressions;
using Eto.Forms;
using Eto.Drawing;


namespace TopoRhinoPlugin
{
    public class TopoRhinoCommand : Rhino.Commands.Command
    {
        public TopoRhinoCommand()
        {
            // Rhino only creates one instance of each command class defined in a
            // plug-in, so it is safe to store a refence in a static property.
            Instance = this;
        }

        ///<summary>The only instance of this command.</summary>
        public static TopoRhinoCommand Instance { get; private set; }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName => "TopoRhinoCommand";

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            // TODO: start here modifying the behaviour of your command.
            // ---

            RhinoApp.WriteLine("Welcome to MySuperCoolPluggin");
            TopoRhinoPlugin.Instance.topowindow.toggle();
            TopoRhinoPlugin.Instance.doc = doc;

            // ---
            return Result.Success;
        }
    }
}
