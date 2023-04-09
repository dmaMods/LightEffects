using ICities;
using System.Reflection;

namespace dmaLightEffects
{
    public class DMALightEffects : IUserMod
    {

        public string Name
        {
            get { return "DMA Light Effects"; }
        }

        public string Description
        {
            get
            {
                var version = Assembly.GetExecutingAssembly().GetName().Version;
                return "Orange beacons for maintenance vehicles, ver." + string.Format("{0}.{1:00}.{2:000}  rev.{3}", version.Major, version.Minor, version.Build, version.Revision);
            }
        }

        public void OnEnabled() { }

    }
}

