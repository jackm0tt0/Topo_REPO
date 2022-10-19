using Rhino;
using System;
using System.Linq;

namespace TopoRhinoPlugin
{
    ///<summary>
    /// <para>Every RhinoCommon .rhp assembly must have one and only one PlugIn-derived
    /// class. DO NOT create instances of this class yourself. It is the
    /// responsibility of Rhino to create an instance of this class.</para>
    /// <para>To complete plug-in information, please also see all PlugInDescription
    /// attributes in AssemblyInfo.cs (you might need to click "Project" ->
    /// "Show All Files" to see it in the "Solution Explorer" window).</para>
    ///</summary>
    public class TopoRhinoPlugin : Rhino.PlugIns.PlugIn
    {
        public TopoRhinoPlugin()
        {
            Instance = this;
            this.topowindow = new TopoWindow();

            Rhino.RhinoDoc.SelectObjects += (sender, e) =>
            {
                var sel = this.doc.Objects.GetSelectedObjects(false, false);
                if (sel == null) 
                {
                    RhinoApp.WriteLine("Selection was null");
                    return; 
                }
                else if (!sel.Any())
                {
                    RhinoApp.WriteLine("Selection Does not have any elements");
                    return;
                }
                else
                {
                    using (Rhino.Input.Custom.GetObject obj_getter = new Rhino.Input.Custom.GetObject())
                    { 
                        obj_getter.EnablePreSelect(true, true);
                        obj_getter.GeometryFilter = Rhino.DocObjects.ObjectType.AnyObject;
                        obj_getter.SubObjectSelect = true;
                        obj_getter.GetMultiple(1,-1);
                        if (obj_getter.ObjectCount == 1)
                        {
                            this.topowindow.geom = obj_getter.Object(0).Geometry();
                            this.topowindow.update();
                        }
                    }
                }
                
            };
            
        }

        ///<summary>Gets the only instance of the TopoRhinoPlugin plug-in.</summary>
        public static TopoRhinoPlugin Instance { get; private set; }

        // You can override methods here to change the plug-in behavior on
        // loading and shut down, add options pages to the Rhino _Option command
        // and maintain plug-in wide options in a document.

        private RhinoDoc _doc;
        
        public RhinoDoc doc
        {
            get { return _doc; }
            set { _doc = value; }
        }
        
        
        private TopoWindow _topowindow;

        public TopoWindow topowindow
        {
            get { return _topowindow; }
            set { _topowindow = value; }
        }

        public static void display_topology(Rhino.Geometry.GeometryBase obj)
        {
            if (obj == null) { return; }
            Type ptype = obj.GetType();

            if (ptype == typeof(Rhino.DocObjects.BrepObject))
            {
                RhinoApp.WriteLine("its a brep");
                //element = get_obj.Object(0).Surface();
            }
            else if (ptype == typeof(Rhino.DocObjects.CurveObject))
            {
                RhinoApp.WriteLine("its a curve");
                //element = null;
            }
            else if (ptype == typeof(Rhino.DocObjects.PointObject))
            {
                RhinoApp.WriteLine("its a point");
                //element = null;
            }
            //else
            //{
            //    element = null;
            //}

            //RhinoApp.WriteLine(element.ToString());
            //RhinoApp.WriteLine(element.GetType().ToString());

            RhinoApp.WriteLine(obj.ToString());
            RhinoApp.WriteLine(obj.GetType().ToString());
        }
    }
}