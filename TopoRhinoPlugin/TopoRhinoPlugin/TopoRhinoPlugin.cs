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
                //else if (!sel.Any())
                //{
                //    RhinoApp.WriteLine("Selection Does not have any elements");
                //    return;
                // }
                else
                {
                    using (Rhino.Input.Custom.GetObject obj_getter = new Rhino.Input.Custom.GetObject())
                    { 
                        obj_getter.EnablePreSelect(true, true);
                        obj_getter.GeometryFilter = Rhino.DocObjects.ObjectType.AnyObject;
                        obj_getter.SubObjectSelect = true;
                        obj_getter.GetMultiple(1,0);
                        if (obj_getter.CommandResult() != Rhino.Commands.Result.Success){return;}
                            
                        if (obj_getter.ObjectCount == 1)
                        {
                            Rhino.DocObjects.ObjRef obj_ref =  obj_getter.Object(0);
                            this.topowindow.obj_ref = obj_ref;
                            this.topowindow.update();
                        }
                        else
                        {
                            this.topowindow.obj_ref = null;
                            this.topowindow.update();
                        }
                    }
                }
                
            };

            RhinoDoc.DeselectAllObjects += (sender, e) =>
            {
                this.topowindow.obj_ref = null;
                this.topowindow.update();
            };
            
        }

        ///<summary>Gets the only instance of the TopoRhinoPlugin plug-in.</summary>
        public static TopoRhinoPlugin Instance { get; private set; }

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
    }
}