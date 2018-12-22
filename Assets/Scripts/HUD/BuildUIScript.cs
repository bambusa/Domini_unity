using Domini.Buildings;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using Utils.BroadcastMessages;

namespace HUD
{
    public class BuildUIScript : MessengerMember
    {
        public Transform ErrorText;
        public Transform BuildButton;
        
        // Use this for initialization
        protected override void Start()
        {
            base.Start();
            InitGameManager(UpdateBuildMenu);
        }

        private void UpdateBuildMenu()
        {
            var buildingDatas = _gameManager.BuildingManager.GetAvailableBuildings();
            foreach (var buildingData in buildingDatas)
            {
                var button = Instantiate(BuildButton);
                button.SetParent(transform, false);
                button.name = $"{Constants.BuildButtonPrefix} {buildingData.BuildingType}";
                button.gameObject.GetComponent<Button>().onClick.AddListener(() => 
                    BuildButtonClicked(buildingData));
                var buttonText = button.Find("BuildButtonText");
                buttonText.gameObject.GetComponent<Text>().text = buildingData.Name;
            }
        }

        private void BuildButtonClicked(BuildingData buildingData)
        {
            if (_gameManager.ResourceManager.ResourceStorage.AreResourcesAvailable(buildingData.BuildingCosts))
            {
                Messenger.Send();
            }
            else
            {
                Messenger.Send(new ErrorMessage("Not enough resources"));
            }
        }
    }
}