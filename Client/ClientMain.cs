using System;
using System.Collections.Generic;
using CitizenFX.Core;
using CitizenFX.Core.UI;
using ImperialLibrary.Utils;
using SharpConfig;
using static CitizenFX.Core.Native.API;

namespace ImperialTablet.Client
{
    public class ClientMain : BaseScript
    {
        #region Variables

        private readonly string communityId;
        private readonly bool restrictTabletUse;

        #endregion

        #region Constructor

        public ClientMain()
        {
            RegisterKeyMapping("tablet", "Open / close your tablet.", "keyboard", "RBRACKET");
            RegisterNuiCallback("closeTablet", new Action<IDictionary<string, object>, CallbackDelegate>(CloseTablet));

            try
            {
                string data = LoadResourceFile(GetCurrentResourceName(), "Config.ini");
                Configuration loaded = Configuration.LoadFromString(data);

                communityId = GlobalState["imperial_community_id"] ?? GetConvar("imperial_community_id", null);

                if (!bool.TryParse(loaded["Imperial-Tablet"]["MustBeInCruiser"].StringValue, out restrictTabletUse))
                {
                    Logger.Log("[Imperial-Tablet] Settings default value for: MustBeInCruiser", LogLevel.Verbose);
                    restrictTabletUse = true;
                }

                SetCommunityId();
            }
            catch (Exception ex)
            {
                Logger.Log($"[Imperial-Tablet] Error loading 'config.ini': {ex.Message}", LogLevel.Error);
            }
        }

        #endregion

        #region Methods

        private async void SetCommunityId()
        {
            await Delay(1000);
            SendNuiMessage(Json.Stringify(new
            {
                type = "SET_COMMUNITY_ID",
                communityId
            }));
        }

        private void CloseTablet(IDictionary<string, object> data, CallbackDelegate result)
        {
            SetNuiFocus(false, false);
            result(new { success = true, message = "Closed successfully" });
        }

        #endregion

        #region Commands

        [Command("tablet")]
        private void OnTabletCommand()
        {
            if ((restrictTabletUse && Game.PlayerPed.CurrentVehicle?.ClassType != VehicleClass.Emergency) || (restrictTabletUse && Game.PlayerPed.SeatIndex is not VehicleSeat.Driver or VehicleSeat.Passenger))
            {
                Screen.ShowNotification("~o~~h~Tablet~h~~s~: You're only able to access your Tablet from your cruiser.", true);
                return;
            }

            SetNuiFocus(true, true);
            SendNuiMessage(Json.Stringify(new
            {
                type = "DISPLAY_TABLET"
            }));
        }

        #endregion
    }
}