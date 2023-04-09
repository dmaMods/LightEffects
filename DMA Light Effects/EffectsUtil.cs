using System;
using System.Collections.Generic;

namespace dmaLightEffects
{
    public static class EffectsUtil
    {
        private static Dictionary<System.Type, Dictionary<int, string>> m_lightEffectDict = new Dictionary<System.Type, Dictionary<int, string>>();
        private static bool m_initialized;

        public static bool AddEffect(VehicleInfo info, string effectName, Vehicle.Flags flagsRequired, Vehicle.Flags flagsForbidden = 0)
        {
            bool flag2;
            EffectInfo info2 = EffectCollection.FindEffect(effectName);
            if (info2 == null)
            {
                flag2 = false;
            }
            else
            {
                int num = (info.m_effects != null) ? (info.m_effects.Length + 1) : 1;
                VehicleInfo.Effect[] destinationArray = new VehicleInfo.Effect[num];
                if (num > 1)
                {
                    Array.Copy(info.m_effects, destinationArray, (int)(num - 1));
                }
                VehicleInfo.Effect effect = new VehicleInfo.Effect
                {
                    m_effect = info2,
                    m_parkedFlagsForbidden = VehicleParked.Flags.Created,
                    m_parkedFlagsRequired = VehicleParked.Flags.None,
                    m_vehicleFlagsForbidden = flagsForbidden,
                    m_vehicleFlagsRequired = flagsRequired
                };
                destinationArray[num - 1] = effect;
                info.m_effects = destinationArray;
                flag2 = true;
            }
            return flag2;
        }

        public static bool AddEffect(VehicleInfo info, EffectInfo info2, Vehicle.Flags flagsRequired, Vehicle.Flags flagsForbidden = 0)
        {
            bool flag2;
            if (info2 == null)
            {
                flag2 = false;
            }
            else
            {
                int num = (info.m_effects != null) ? (info.m_effects.Length + 1) : 1;
                VehicleInfo.Effect[] destinationArray = new VehicleInfo.Effect[num];
                if (num > 1)
                {
                    Array.Copy(info.m_effects, destinationArray, (int)(num - 1));
                }
                VehicleInfo.Effect effect = new VehicleInfo.Effect
                {
                    m_effect = info2,
                    m_parkedFlagsForbidden = VehicleParked.Flags.Created,
                    m_parkedFlagsRequired = VehicleParked.Flags.None,
                    m_vehicleFlagsForbidden = flagsForbidden,
                    m_vehicleFlagsRequired = flagsRequired
                };
                destinationArray[num - 1] = effect;
                info.m_effects = destinationArray;
                flag2 = true;
            }
            return flag2;
        }

        public static int GetEffectIndex(VehicleInfo info, string effectName)
        {
            try
            {
                if (((info != null) && !string.IsNullOrEmpty(effectName)) && (info.m_effects != null))
                {
                    int index = 0;
                    while (true)
                    {
                        if (index >= info.m_effects.Length)
                        {
                            break;
                        }
                        if (info.m_effects[index].m_effect.name != effectName)
                        {
                            index++;
                            continue;
                        }
                        return index;
                    }
                }
            }
            catch { }
            return -1;
        }

        private static void Initialize()
        {
            m_initialized = true;
            Dictionary<int, string> dictionary = new Dictionary<int, string> { { 0, "Train Light Left" }, { 1, "Train Light Right" }, { 2, "Train Light Center" } };
            m_lightEffectDict.Add(typeof(PassengerTrainAI), dictionary);
            m_lightEffectDict.Add(typeof(CargoTrainAI), dictionary);
        }

        public static T[] LengthenArray<T>(T[] array, T newItem)
        {
            List<T> list = new List<T>();
            list.AddRange(array);
            list.Add(newItem);
            return list.ToArray();
        }

        public static string LightIndexToEffectName(VehicleInfo info, int index)
        {
            Dictionary<int, string> dictionary;
            if (!m_initialized)
            {
                Initialize();
            }
            string str = null;
            m_lightEffectDict.TryGetValue(info.m_vehicleAI.GetType(), out dictionary);
            if (dictionary != null)
            {
                dictionary.TryGetValue(index, out str);
            }
            return str;
        }

        public static bool RemoveEffect(VehicleInfo info, int index)
        {
            try
            {
                bool flag2;
                if (((info.m_effects == null) || (index < 0)) || (index >= info.m_effects.Length))
                {
                    flag2 = false;
                }
                else
                {
                    List<VehicleInfo.Effect> list = new List<VehicleInfo.Effect>();
                    list.AddRange(info.m_effects);
                    list.RemoveAt(index);
                    info.m_effects = list.ToArray();
                    flag2 = true;
                }
                return flag2;
            }
            catch { }
            return false;
        }

        public static void RemoveEffect(VehicleInfo info, string effectName)
        {
            try
            {
                while (true)
                {
                    int effectIndex = GetEffectIndex(info, effectName);
                    RemoveEffect(info, effectIndex);
                    if (effectIndex < 0)
                    {
                        return;
                    }
                }
            }
            catch { }
        }

    }
}

