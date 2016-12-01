using ICities;
using UnityEngine;

namespace JapaneseTrafficLights
{
    public class LoadingExtension : LoadingExtensionBase
    {

        public override void OnLevelLoaded(LoadMode mode)
        {
            base.OnLevelLoaded(mode);
            if (mode != LoadMode.LoadGame && mode != LoadMode.NewGame)
            {
                return;
            }
			var mainLight = PrefabCollection<PropInfo>.FindLoaded("809633246.JapaneseTrafficLightMain_Data");
			var walkLight = PrefabCollection<PropInfo>.FindLoaded("809633246.JapaneseTrafficLightWalk_Data");
			var walkLight2 = PrefabCollection<PropInfo>.FindLoaded("809633246.JapaneseTrafficLightWalk2_Data");
			if (mainLight == null || walkLight == null || walkLight2 == null)
			{
				return;
            }
            var roads = Resources.FindObjectsOfTypeAll<NetInfo>();
            foreach (var road in roads)
            {
                if (road.m_lanes == null)
                {
                    return;
                }
                foreach (var lane in road.m_lanes)
                {
                    if (lane?.m_laneProps?.m_props == null)
                    {
                        continue;
                    }
                    foreach (var laneProp in lane.m_laneProps.m_props)
                    {
                        var prop = laneProp.m_finalProp;
                        if (prop == null)
                        {
                            continue;
                        }
                        var name = prop.name;

						switch(name)
						{
							case "Traffic Light 01":
							case "Traffic Light European 01":
								laneProp.m_finalProp = walkLight2;
								laneProp.m_prop = walkLight2;
								break;

							case "Traffic Light 01 Mirror":
							case "Traffic Light European 01 Mirror":
								laneProp.m_finalProp = walkLight;
								laneProp.m_prop = walkLight;
								break;
							
							case "Traffic Light 02":
							case "Traffic Light European 02":
								laneProp.m_finalProp = walkLight;
								laneProp.m_prop = walkLight;
								break;

							case "Traffic Light 02 Mirror":
							case "Traffic Light European 02 Mirror":
								laneProp.m_finalProp = mainLight;
								laneProp.m_prop = mainLight;
								break;

							case "Traffic Light Pedestrian":
							case "Traffic Light Pedestrian European":
								laneProp.m_finalProp = walkLight2;
								laneProp.m_prop = walkLight2;
								break;
							
							
						}
					}
                }
            }
        }
    }
}