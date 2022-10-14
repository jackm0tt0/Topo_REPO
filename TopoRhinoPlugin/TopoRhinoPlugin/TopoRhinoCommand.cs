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

            // this method will show my pluggin window

            TopoRhinoPlugin.Instance.topowindow.toggle();

            
            //using (GetObject get_obj = new GetObject())
            //{
            //    Rhino.Geometry.GeometryBase element;
            //    get_obj.SetCommandPrompt("Select An Element");
            //    get_obj.SubObjectSelect = true;
            //    if (get_obj.Get() != GetResult.Object)
            //    {
            //        RhinoApp.WriteLine("You forgot to select an object");
            //        return get_obj.CommandResult();
            //    }
            //    Rhino.DocObjects.RhinoObject parent = get_obj.Object(0).Object();
            //    Type ptype = parent.GetType();

            //    if (ptype == typeof(Rhino.DocObjects.BrepObject))
            //    {
            //        RhinoApp.WriteLine("its a brep");
            //        element = get_obj.Object(0).Surface();
            //    }
            //    else if (ptype == typeof(Rhino.DocObjects.CurveObject))
            //    {
            //        RhinoApp.WriteLine("its a curve");
            //        element = null;
            //    }
            //    else if (ptype == typeof(Rhino.DocObjects.PointObject))
            //    {
            //        RhinoApp.WriteLine("its a point");
            //        element = null;
            //    }
            //    else
            //    {
            //        element = null;
            //    }

            //    RhinoApp.WriteLine(element.ToString());
            //    RhinoApp.WriteLine(element.GetType().ToString());

            //    RhinoApp.WriteLine(parent.ToString());
            //    RhinoApp.WriteLine(parent.GetType().ToString());
            //}

            //Point3d pt0;
            //using (GetPoint getPointAction = new GetPoint())
            //{
            //    getPointAction.SetCommandPrompt("Please select the start point");
            //    if (getPointAction.Get() != GetResult.Point)
            //    {
            //        RhinoApp.WriteLine("No start point was selected.");
            //        return getPointAction.CommandResult();
            //    }
            //    pt0 = getPointAction.Point();
            //}

            //Point3d pt1;
            //using (GetPoint getPointAction = new GetPoint())
            //{
            //    getPointAction.SetCommandPrompt("Please select the end point");
            //    getPointAction.SetBasePoint(pt0, true);
            //    getPointAction.DynamicDraw +=
            //      (sender, e) => e.Display.DrawLine(pt0, e.CurrentPoint, System.Drawing.Color.DarkRed);
            //    if (getPointAction.Get() != GetResult.Point)
            //    {
            //        RhinoApp.WriteLine("No end point was selected.");
            //        return getPointAction.CommandResult();
            //    }
            //    pt1 = getPointAction.Point();
            //}

            //doc.Objects.AddLine(pt0, pt1);
            //doc.Views.Redraw();
            //RhinoApp.WriteLine("The {0} command added one line to the document.", EnglishName);

            // ---
            return Result.Success;
        }
    }
}
