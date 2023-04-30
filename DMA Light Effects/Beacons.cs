using UnityEngine;

namespace dmaLightEffects
{
    public class Beacons
    {
        private static LightEffect Beacon1;
        private static LightEffect Beacon1a;
        private static LightEffect Beacon2;
        private static LightEffect Beacon2a;
        private static LightEffect Beacon3;
        private static LightEffect Beacon3a;
        private static LightEffect Beacon4;
        private static LightEffect Beacon4a;
        private static MultiEffect AmberFlash1;
        public static bool BeaconAvailable = false;

        internal static void CreateBeacons()
        {
            var Snowplow1 = EffectCollection.FindEffect("Snowplow Light 1") as LightEffect;
            var Snowplow2 = EffectCollection.FindEffect("Snowplow Light 2") as LightEffect;
            if (Snowplow1 == null || Snowplow2 == null) return; else BeaconAvailable = true;
            var amberLight1 = Snowplow1.GetComponent<Light>().color;
            var amberLight2 = Snowplow2.GetComponent<Light>().color;

            var FireEmergency1 = EffectCollection.FindEffect("Fire Truck Emergency1") as MultiEffect;

            Beacon1 = EffectCollection.Instantiate(Snowplow1); Beacon1.transform.parent = Snowplow1.transform.parent;
            Beacon1a = EffectCollection.Instantiate(Snowplow1); Beacon1a.transform.parent = Snowplow1.transform.parent;
            Beacon2 = EffectCollection.Instantiate(Snowplow2); Beacon2.transform.parent = Snowplow2.transform.parent;
            Beacon2a = EffectCollection.Instantiate(Snowplow2); Beacon2a.transform.parent = Snowplow2.transform.parent;
            Beacon3 = EffectCollection.Instantiate(Snowplow1); Beacon3.transform.parent = Snowplow1.transform.parent;
            Beacon3a = EffectCollection.Instantiate(Snowplow1); Beacon3a.transform.parent = Snowplow1.transform.parent;
            Beacon4 = EffectCollection.Instantiate(Snowplow2); Beacon4.transform.parent = Snowplow2.transform.parent;
            Beacon4a = EffectCollection.Instantiate(Snowplow2); Beacon4a.transform.parent = Snowplow2.transform.parent;

            Beacon1.m_positionIndex = 2;
            Beacon1a.m_positionIndex = 2;
            Beacon2.m_positionIndex = 3; Beacon2.GetComponent<Light>().color = amberLight1;
            Beacon2a.m_positionIndex = 3; Beacon2a.GetComponent<Light>().color = amberLight1;
            Beacon3.m_positionIndex = 4; Beacon3.GetComponent<Light>().color = amberLight2;
            Beacon3a.m_positionIndex = 4; Beacon3a.GetComponent<Light>().color = amberLight2;
            Beacon4.m_positionIndex = 5;
            Beacon4a.m_positionIndex = 5;

            Beacon1.m_rotationSpeed =
                Beacon2.m_rotationSpeed =
                Beacon3.m_rotationSpeed =
                Beacon4.m_rotationSpeed = 85;

            Beacon1a.m_rotationSpeed =
                Beacon2a.m_rotationSpeed =
                Beacon3a.m_rotationSpeed =
                Beacon4a.m_rotationSpeed = 80;

            Beacon1.m_rotationAxis =
                Beacon1a.m_rotationAxis =
                Beacon2.m_rotationAxis =
                Beacon2a.m_rotationAxis =
                Beacon3.m_rotationAxis =
                Beacon3a.m_rotationAxis =
                Beacon4.m_rotationAxis =
                Beacon4a.m_rotationAxis = new Vector3 { x = 0, y = 1, z = 0 };

            Beacon1.name = "Orange Beacon 1"; Beacon1.InitializeEffect();
            Beacon1a.name = "Orange Beacon 1A"; Beacon1a.InitializeEffect();
            Beacon2.name = "Orange Beacon 2"; Beacon2.InitializeEffect();
            Beacon2a.name = "Orange Beacon 2A"; Beacon2.InitializeEffect();
            Beacon3.name = "Orange Beacon 3"; Beacon3.InitializeEffect();
            Beacon3a.name = "Orange Beacon 3A"; Beacon3.InitializeEffect();
            Beacon4.name = "Orange Beacon 4"; Beacon4.InitializeEffect();
            Beacon4a.name = "Orange Beacon 4A"; Beacon4a.InitializeEffect();

            AmberFlash1 = EffectCollection.Instantiate(FireEmergency1); AmberFlash1.transform.parent = FireEmergency1.transform.parent;

            // front lights
            var AmberL1 = EffectCollection.Instantiate(EffectCollection.FindEffect("Fire Truck Light Left") as LightEffect); AmberL1.name = "Orange Flash Left 1"; AmberL1.GetComponent<Light>().color = amberLight1; AmberL1.InitializeEffect();
            var AmberR1 = EffectCollection.Instantiate(EffectCollection.FindEffect("Fire Truck Light Right") as LightEffect); AmberR1.name = "Orange Flash Right 1"; AmberR1.GetComponent<Light>().color = amberLight2; AmberR1.InitializeEffect();
            // rear lights (reverse sides)
            var AmberL2 = EffectCollection.Instantiate(EffectCollection.FindEffect("Fire Truck Light Left2") as LightEffect); AmberL2.name = "Orange Flash Left 2"; AmberL2.GetComponent<Light>().color = amberLight2; AmberL2.InitializeEffect();
            var AmberR2 = EffectCollection.Instantiate(EffectCollection.FindEffect("Fire Truck Light Right2") as LightEffect); AmberR2.name = "Orange Flash Right 2"; AmberR2.GetComponent<Light>().color = amberLight1; AmberR2.InitializeEffect();

            AmberFlash1.m_effects[0].m_effect = AmberL1;
            AmberFlash1.m_effects[1].m_effect = AmberR1;
            AmberFlash1.m_effects[2].m_effect = AmberL2;
            AmberFlash1.m_effects[3].m_effect = AmberR2;

            AmberFlash1.name = "Orange Flash 1"; AmberFlash1.InitializeEffect();
        }

        internal static void UpgradeVehicles()
        {
            var truck = PrefabCollection<VehicleInfo>.FindLoaded("1476646740.Maintenance Truck_Data"); if (truck != null) AddBeacon(truck, Trucks.Unimog);

            truck = PrefabCollection<VehicleInfo>.FindLoaded("1236068461.2014 CimTrans Ram Maint Truck_Data"); if (truck != null) AddBeacon(truck, Trucks.CimTrans);

            truck = PrefabCollection<VehicleInfo>.FindLoaded("2848364572.Chevrolet K30 Sunset City DOT_Data"); if (truck != null) AddBeacon(truck, Trucks.Chevrolet);

            truck = PrefabCollection<VehicleInfo>.FindLoaded("1263742375.Škoda Yeti Airfield Operations_Data"); if (truck != null) AddBeacon(truck, Trucks.Airfield);

            truck = PrefabCollection<VehicleInfo>.FindLoaded("Engineering_Truck"); if (truck != null) AddBeacon(truck, Trucks.Vanilla);

            truck = PrefabCollection<VehicleInfo>.FindLoaded("2951563179.Ford Super Duty 2011 (Road)_Data"); if (truck != null) AddBeacon(truck, Trucks.VanillaWhite);

            truck = PrefabCollection<VehicleInfo>.FindLoaded("811508908.MBSprinter Road Maintenance_Data"); if (truck != null) AddBeacon(truck, Trucks.Mercedes);

            truck = PrefabCollection<VehicleInfo>.FindLoaded("534285441.DAF 75 CF garbage truck_Data"); if (truck != null) AddBeacon(truck, Trucks.DAF75);

            truck = PrefabCollection<VehicleInfo>.FindLoaded("2480652448.DAF XF Garbage Truck_Data"); if (truck != null) AddBeacon(truck, Trucks.DAFXF);

            truck = PrefabCollection<VehicleInfo>.FindLoaded("2480747959.DAF XF Recycle Truck_Data"); if (truck != null) AddBeacon(truck, Trucks.DAFXF);

            truck = PrefabCollection<VehicleInfo>.FindLoaded("2495137137.DAF XF Waste Truck_Data"); if (truck != null) AddBeacon(truck, Trucks.DAFXF);

            truck = PrefabCollection<VehicleInfo>.FindLoaded("Waste Transfer Truck"); if (truck != null) AddBeacon(truck, Trucks.WasteTruck);
            
            truck = PrefabCollection<VehicleInfo>.FindLoaded("2864978101.Park Ranger - VW Amarok_Data"); if (truck != null) AddBeacon(truck, Trucks.ParkRanger);
            
            truck = PrefabCollection<VehicleInfo>.FindLoaded("2864978101.Park Ranger - Toyota Hilux Tray_Data"); if (truck != null) AddBeacon(truck, Trucks.ParkRanger);
            
            truck = PrefabCollection<VehicleInfo>.FindLoaded("2864978101.Park Ranger - Toyota Hilux Roof_Data"); if (truck != null) AddBeacon(truck, Trucks.ParkRanger);
        }

        private static void AddBeacon(VehicleInfo truck, Trucks version)
        {
            EffectsUtil.RemoveEffect(truck, "Orange Flash 1");
            EffectsUtil.RemoveEffect(truck, "Orange Beacon 1");
            EffectsUtil.RemoveEffect(truck, "Orange Beacon 1A");
            EffectsUtil.RemoveEffect(truck, "Orange Beacon 2");
            EffectsUtil.RemoveEffect(truck, "Orange Beacon 2A");
            EffectsUtil.RemoveEffect(truck, "Orange Beacon 3");
            EffectsUtil.RemoveEffect(truck, "Orange Beacon 3A");
            EffectsUtil.RemoveEffect(truck, "Orange Beacon 4");
            EffectsUtil.RemoveEffect(truck, "Orange Beacon 4A");
            EffectsUtil.RemoveEffect(truck, "Snowplow Light 1");
            EffectsUtil.RemoveEffect(truck, "Snowplow Light 2");

            for (int f = truck.m_lightPositions.Length; f < 6; f++) AddLight(truck, f);

            float X1; float X2; float Y; float Z;
            switch (version)
            {
                case Trucks.Chevrolet:// chevrolet
                    X1 = -0.45f; X2 = -X1; Y = 0.15f; Z = 0.5f;
                    EffectsUtil.AddEffect(truck, Beacon1, Vehicle.Flags.Created);
                    EffectsUtil.AddEffect(truck, Beacon2, Vehicle.Flags.Created);
                    EffectsUtil.AddEffect(truck, Beacon3, Vehicle.Flags.Created);
                    EffectsUtil.AddEffect(truck, Beacon4, Vehicle.Flags.Created);
                    truck.m_lightPositions[2] = new Vector3(X1, Y, Z);
                    truck.m_lightPositions[3] = new Vector3(X1, Y, Z);
                    truck.m_lightPositions[4] = new Vector3(X2, Y, Z);
                    truck.m_lightPositions[5] = new Vector3(X2, Y, Z);
                    break;
                case Trucks.Unimog:// unimog
                    X1 = -0.8f; X2 = X1; Y = 0.25f; Z = 1.4f;
                    EffectsUtil.AddEffect(truck, Beacon1, Vehicle.Flags.Created);
                    EffectsUtil.AddEffect(truck, Beacon2, Vehicle.Flags.Created);
                    truck.m_lightPositions[2] = new Vector3(X1, Y, Z);
                    truck.m_lightPositions[3] = new Vector3(X1, Y, Z);
                    break;
                case Trucks.Vanilla:// vanilla
                    X1 = 0.45f; X2 = 0.35f; Y = 0f; Z = 0.5f;
                    EffectsUtil.AddEffect(truck, AmberFlash1, Vehicle.Flags.Created);
                    truck.m_lightPositions[2] = new Vector3(-X1, Y, 0.42f);
                    truck.m_lightPositions[3] = new Vector3(X1, Y, 0.42f);
                    truck.m_lightPositions[4] = new Vector3(X2, Y, Z);
                    truck.m_lightPositions[5] = new Vector3(-X2, Y, Z);
                    break;
                case Trucks.VanillaWhite:// Ford Super Duty 2011 (Road)
                    X1 = 0.55f; X2 = 0.3f; Y = 0.0f; Z = 0.45f;
                    EffectsUtil.AddEffect(truck, Beacon1, Vehicle.Flags.Created);
                    EffectsUtil.AddEffect(truck, Beacon2a, Vehicle.Flags.Created);
                    EffectsUtil.AddEffect(truck, Beacon3a, Vehicle.Flags.Created);
                    EffectsUtil.AddEffect(truck, Beacon4, Vehicle.Flags.Created);
                    truck.m_lightPositions[2] = new Vector3(X1, Y, Z);
                    truck.m_lightPositions[3] = new Vector3(X2, Y, Z);
                    truck.m_lightPositions[4] = new Vector3(-X2, Y, Z);
                    truck.m_lightPositions[5] = new Vector3(-X1, Y, Z);
                    break;
                case Trucks.CimTrans:// white cimtrans
                    X1 = 0.15f; X2 = X1; Y = 0.12f; Z = -0.12f;
                    EffectsUtil.AddEffect(truck, Beacon1, Vehicle.Flags.Created);
                    EffectsUtil.AddEffect(truck, Beacon2, Vehicle.Flags.Created);
                    EffectsUtil.AddEffect(truck, Beacon3, Vehicle.Flags.Created);
                    EffectsUtil.AddEffect(truck, Beacon4, Vehicle.Flags.Created);
                    truck.m_lightPositions[2] = new Vector3(-X1, Y, Z);
                    truck.m_lightPositions[3] = new Vector3(-X2, Y, Z);
                    truck.m_lightPositions[4] = new Vector3(X1, Y, Z);
                    truck.m_lightPositions[5] = new Vector3(X2, Y, Z);
                    break;
                case Trucks.Airfield:// škoda airfield
                    X1 = 0.3f; X2 = 0.3f; Y = 0.1f; Z = 0.15f;
                    EffectsUtil.AddEffect(truck, AmberFlash1, Vehicle.Flags.Created);
                    truck.m_lightPositions[2] = new Vector3(-X1, Y, 0.1f);
                    truck.m_lightPositions[3] = new Vector3(X1, Y, 0.1f);
                    truck.m_lightPositions[4] = new Vector3(X2, Y, Z);
                    truck.m_lightPositions[5] = new Vector3(-X2, Y, Z);
                    break;
                case Trucks.Mercedes:// mercedes
                    X1 = 0.45f; X2 = -X1; Y = 0.0f; Z = 0.35f;
                    EffectsUtil.AddEffect(truck, Beacon1, Vehicle.Flags.Created);
                    EffectsUtil.AddEffect(truck, Beacon2, Vehicle.Flags.Created);
                    EffectsUtil.AddEffect(truck, Beacon3a, Vehicle.Flags.Created);
                    EffectsUtil.AddEffect(truck, Beacon4a, Vehicle.Flags.Created);
                    truck.m_lightPositions[2] = new Vector3(X1, Y, Z);
                    truck.m_lightPositions[3] = new Vector3(X1, Y, Z);
                    truck.m_lightPositions[4] = new Vector3(X2, Y, Z);
                    truck.m_lightPositions[5] = new Vector3(X2, Y, Z);
                    break;
                case Trucks.DAF75:// DAF 75
                    X1 = 0.39f; X2 = -0.37f; Y = -0.52f; Z = 3.75f;
                    EffectsUtil.AddEffect(truck, Beacon1, Vehicle.Flags.Created);
                    EffectsUtil.AddEffect(truck, Beacon2, Vehicle.Flags.Created);
                    EffectsUtil.AddEffect(truck, Beacon3, Vehicle.Flags.Created);
                    EffectsUtil.AddEffect(truck, Beacon4, Vehicle.Flags.Created);
                    truck.m_lightPositions[2] = new Vector3(X1, Y, Z);
                    truck.m_lightPositions[3] = new Vector3(X1, Y, Z);
                    truck.m_lightPositions[4] = new Vector3(X2, Y, Z);
                    truck.m_lightPositions[5] = new Vector3(X2, Y, Z);
                    break;
                case Trucks.DAFXF:// DAF 2005 XF
                    X1 = 1.0f; X2 = -X1; Y = 0.0f; Z = 1.05f;
                    EffectsUtil.AddEffect(truck, Beacon1a, Vehicle.Flags.Created);
                    EffectsUtil.AddEffect(truck, Beacon2a, Vehicle.Flags.Created);
                    EffectsUtil.AddEffect(truck, Beacon3, Vehicle.Flags.Created);
                    EffectsUtil.AddEffect(truck, Beacon4, Vehicle.Flags.Created);
                    truck.m_lightPositions[2] = new Vector3(X1, Y, Z);
                    truck.m_lightPositions[3] = new Vector3(X1, Y, Z);
                    truck.m_lightPositions[4] = new Vector3(X2, Y, Z);
                    truck.m_lightPositions[5] = new Vector3(X2, Y, Z);
                    break;
                case Trucks.WasteTruck:// waste (vanilla?)
                    X1 = 0.7f; X2 = -X1; Y = -0.1f; Z = 2.5f;
                    EffectsUtil.AddEffect(truck, Beacon1, Vehicle.Flags.Created);
                    EffectsUtil.AddEffect(truck, Beacon2, Vehicle.Flags.Created);
                    EffectsUtil.AddEffect(truck, Beacon3a, Vehicle.Flags.Created);
                    EffectsUtil.AddEffect(truck, Beacon4a, Vehicle.Flags.Created);
                    truck.m_lightPositions[2] = new Vector3(X1, Y, Z);
                    truck.m_lightPositions[3] = new Vector3(X1, Y, Z);
                    truck.m_lightPositions[4] = new Vector3(X2, Y, Z);
                    truck.m_lightPositions[5] = new Vector3(X2, Y, Z);
                    break;
                case Trucks.ParkRanger:// park ranger (VW & Toyota)
                    X1 = 0.25f; X2 = 0.35f; Y = -0.1f; Z = -0.28f;
                    EffectsUtil.AddEffect(truck, AmberFlash1, Vehicle.Flags.Created);
                    truck.m_lightPositions[2] = new Vector3(-X1, Y, Z);
                    truck.m_lightPositions[3] = new Vector3(X1, Y, Z);
                    truck.m_lightPositions[4] = new Vector3(X2, Y, Z);
                    truck.m_lightPositions[5] = new Vector3(-X2, Y, Z);
                    break;
            }
        }

        private static void AddLight(VehicleInfo m_selectedVehicleInfo, int length)
        {
            if (m_selectedVehicleInfo != null)
            {
                string effectName = EffectsUtil.LightIndexToEffectName(m_selectedVehicleInfo, length);
                m_selectedVehicleInfo.m_lightPositions = EffectsUtil.LengthenArray<Vector3>(m_selectedVehicleInfo.m_lightPositions, Vector3.zero);
                if (effectName != null)
                {
                    EffectsUtil.AddEffect(m_selectedVehicleInfo, effectName, Vehicle.Flags.Created, Vehicle.Flags.Reversed | Vehicle.Flags.Inverted);
                    EffectsUtil.AddEffect(m_selectedVehicleInfo, effectName, Vehicle.Flags.Reversed | Vehicle.Flags.Inverted, ~(Vehicle.Flags.InsideBuilding | Vehicle.Flags.Transition | Vehicle.Flags.Underground | Vehicle.Flags.DummyTraffic | Vehicle.Flags.Congestion | Vehicle.Flags.WaitingLoading | Vehicle.Flags.OnGravel | Vehicle.Flags.CustomName | Vehicle.Flags.Parking | Vehicle.Flags.Exporting | Vehicle.Flags.Importing | Vehicle.Flags.WaitingTarget | Vehicle.Flags.GoingBack | Vehicle.Flags.WaitingCargo | Vehicle.Flags.WaitingSpace | Vehicle.Flags.Landing | Vehicle.Flags.Flying | Vehicle.Flags.TakingOff | Vehicle.Flags.Reversed | Vehicle.Flags.Arriving | Vehicle.Flags.Leaving | Vehicle.Flags.Stopped | Vehicle.Flags.WaitingPath | Vehicle.Flags.Emergency2 | Vehicle.Flags.Emergency1 | Vehicle.Flags.TransferToSource | Vehicle.Flags.TransferToTarget | Vehicle.Flags.Inverted | Vehicle.Flags.Spawned | Vehicle.Flags.Deleted | Vehicle.Flags.Created | Vehicle.Flags.LeftHandDrive));
                }
            }
        }

        private enum Trucks : int
        {
            Chevrolet = 1,
            Unimog = 2,
            Vanilla = 3,
            VanillaWhite = 31,
            CimTrans = 4,
            Airfield = 5,
            Mercedes = 6,
            DAF75 = 7,
            DAFXF = 8,
            WasteTruck = 9,
            ParkRanger = 11
        }

    }
}
