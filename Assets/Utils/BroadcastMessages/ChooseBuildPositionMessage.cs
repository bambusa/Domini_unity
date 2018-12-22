using Domini.Buildings;

namespace Utils.BroadcastMessages
{
    public class ChooseBuildPositionMessage : BroadcastMessage
    {
        public BuildingData BuildingData;

        public ChooseBuildPositionMessage(BuildingData buildingData)
        {
            BuildingData = buildingData;
        }
    }
}