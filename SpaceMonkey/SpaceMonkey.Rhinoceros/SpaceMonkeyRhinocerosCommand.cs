using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Rhino;
using Rhino.Commands;
using Rhino.DocObjects;
using Rhino.Geometry;
using Rhino.Input;
using Rhino.Input.Custom;
using SpaceMonkey.IO.EventArguments;
using SpaceMonkey.IO.Schemas;
using SpaceMonkey.Rhinoceros.ViewModels;
using SpaceMonkey.Rhinoceros.Views;
using SpaceMonkey.ViewModels.Main;

namespace SpaceMonkey.Rhinoceros
{
    [Guid("48ace548-297f-4782-9ea1-0f2a6eb1b1a9")]
    public class SpaceMonkeyPanelHost : RhinoWindows.Controls.WpfElementHost
    {
        public SpaceMonkeyPanelHost(uint docSn)
            :base(new SpaceMonkeyDocPanel(docSn), null)
        {
            SpaceMonkeyCoreViewModel.Instance.BakeTriggered += CoreViewModel_BakeTriggered;
        }

        private void CoreViewModel_BakeTriggered(object sender, EventArgs e)
        {
            BakeTriggeredEventArgs args = e as BakeTriggeredEventArgs;
            this.Bake(args.Satellites);
        }

        private Point3d SatToPoint(SmSatellite sat)
        {
            double scale = SpaceMonkeyCoreViewModel.Instance.ScaleFactor;

            Point3d basePt = new Point3d(0, 0, 0);
            Transform transform = Transform.Translation(new Vector3d(-6378.137 * scale, 0, 0)); // Radius of Earth in km at sea level
            basePt.Transform(transform); // Move point from origin to prime meridian

            Point3d satPt = new Point3d(basePt.X, basePt.Y, basePt.Z);
            Transform altitudeTranslation = Transform.Translation(new Vector3d(-(sat.SatAlt * scale), 0, 0));
            satPt.Transform(altitudeTranslation);
            Point3d newVectDir = new Point3d(satPt.X, satPt.Y, satPt.Z);

            double horizRadians = (Math.PI / 180) * sat.SatLng;
            double horizAxisRadians = (Math.PI / 180) * (sat.SatLng - 90);
            double vertRadians = (Math.PI / 180) * sat.SatLat;

            Transform horizRotation = Transform.Rotation(horizRadians, Vector3d.ZAxis, new Point3d(0, 0, 0));
            satPt.Transform(horizRotation);
            Transform horizAxisRotation = Transform.Rotation(horizAxisRadians, Vector3d.ZAxis, new Point3d(0, 0, 0));
            newVectDir.Transform(horizAxisRotation);

            Transform vertRotation = Transform.Rotation(vertRadians, new Vector3d(newVectDir), new Point3d(0, 0, 0));
            satPt.Transform(vertRotation);
            return satPt;
        }

        private void Bake(List<SmSatellite> sats)
        {
            Rhino.DocObjects.Tables.ObjectTable ot = Rhino.RhinoDoc.ActiveDoc.Objects;

            // Bake Earth
            double scale = SpaceMonkeyCoreViewModel.Instance.ScaleFactor;
            Sphere earth = new Sphere(new Point3d(0, 0, 0), 6378.137 * scale);
            ot.AddSphere(earth);

            foreach (SmSatellite s in sats)
            {
                Point3d pt = SatToPoint(s);
                ObjectAttributes attr = new ObjectAttributes();
                attr.SetUserString(nameof(SmSatellite.SatId), s.SatId.ToString());
                attr.SetUserString(nameof(SmSatellite.SatName), s.SatName);
                attr.SetUserString(nameof(SmSatellite.IntDesignator), s.IntDesignator);
                attr.SetUserString(nameof(SmSatellite.LaunchDate), s.LaunchDate);
                attr.SetUserString(nameof(SmSatellite.SatLat), s.SatLat.ToString());
                attr.SetUserString(nameof(SmSatellite.SatLng), s.SatLng.ToString());
                attr.SetUserString(nameof(SmSatellite.SatAlt), s.SatAlt.ToString());
                ot.AddPoint(pt, attr);
            }

            foreach (var view in Rhino.RhinoDoc.ActiveDoc.Views)
            {
                view.Redraw();
            }
        }
        
    }


    public class SpaceMonkeyRhinocerosCommand : Command
    {
        public SpaceMonkeyRhinocerosCommand()
        {
            // Rhino only creates one instance of each command class defined in a
            // plug-in, so it is safe to store a refence in a static property.
            Instance = this;
            Rhino.UI.Panels.RegisterPanel(SpaceMonkeyRhinocerosPlugIn.Instance, typeof(SpaceMonkeyPanelHost), "SpaceMonkey", null);
        }

        ///<summary>The only instance of this command.</summary>
        public static SpaceMonkeyRhinocerosCommand Instance
        {
            get; private set;
        }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName
        {
            get { return "SpaceMonkey"; }
        }

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            RhinoApp.WriteLine("Launching the SpaceMonkey");
            this.LaunchSpaceMonkey();
            return Result.Success;
        }

        public void LaunchSpaceMonkey()
        {
            var panelId = typeof(SpaceMonkeyPanelHost).GUID;
            var panelVisible = Rhino.UI.Panels.IsPanelVisible(panelId);

            if (!panelVisible)
            {
                Rhino.UI.Panels.OpenPanel(panelId);
            }
        }
    }
}
