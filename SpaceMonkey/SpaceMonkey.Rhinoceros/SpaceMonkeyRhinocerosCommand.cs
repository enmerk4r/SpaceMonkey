using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Rhino;
using Rhino.Commands;
using Rhino.Geometry;
using Rhino.Input;
using Rhino.Input.Custom;
using SpaceMonkey.Rhinoceros.Views;

namespace SpaceMonkey.Rhinoceros
{
    [Guid("48ace548-297f-4782-9ea1-0f2a6eb1b1a9")]
    public class SpaceMonkeyPanelHost : RhinoWindows.Controls.WpfElementHost
    {
        public SpaceMonkeyPanelHost(uint docSn)
            :base(new SpaceMonkeyDocPanel(docSn), null)
        {
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
