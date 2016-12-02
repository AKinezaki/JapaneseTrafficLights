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

		var TL1 = PrefabCollection<PropInfo>.FindLoaded("809633246.JPTLped_Data");
		var TL1m = PrefabCollection<PropInfo>.FindLoaded("809633246.JPTLped2_Data");
		var TL2 = PrefabCollection<PropInfo>.FindLoaded("809633246.JPTLped2_Data");
		var TL2m = PrefabCollection<PropInfo>.FindLoaded("809633246.JPTLmain_Data");
		var TLped = PrefabCollection<PropInfo>.FindLoaded("809633246.JPTLped_Data");

		if (TL1 == null || TL1m == null || TL2 == null || TL2m == null || TLped == null)
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
						laneProp.m_finalProp = TL1;
						laneProp.m_prop = TL1;
						break;

					case "Traffic Light 01 Mirror":
					case "Traffic Light European 01 Mirror":
						laneProp.m_finalProp = TL1m;
						laneProp.m_prop = TL1m;
						break;
							
					case "Traffic Light 02":
					case "Traffic Light European 02":
						laneProp.m_finalProp = TL2;
						laneProp.m_prop = TL2;
						break;

					case "Traffic Light 02 Mirror":
					case "Traffic Light European 02 Mirror":
						laneProp.m_finalProp = TL2m;
						laneProp.m_prop = TL2m;
						break;

					case "Traffic Light Pedestrian":
					case "Traffic Light Pedestrian European":
						laneProp.m_finalProp = TLped;
						laneProp.m_prop = TLped;
						break;

					default:
						break;
                   	}
                    }
                }
            }
        }
    }
}