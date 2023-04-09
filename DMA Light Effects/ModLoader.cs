using ICities;

namespace dmaLightEffects
{
    public class ModLoader : LoadingExtensionBase
    {
        public override void OnCreated(ILoading loading)
        {
            base.OnCreated(loading);
        }

        public override void OnLevelLoaded(LoadMode mode)
        {
            base.OnLevelLoaded(mode);
            if (mode == LoadMode.LoadGame || mode == LoadMode.NewGame || mode == LoadMode.LoadMap || mode == LoadMode.NewMap)
            {
                Beacons.CreateBeacons();
                if (Beacons.BeaconAvailable) Beacons.UpgradeVehicles();
            }
        }

    }
}
