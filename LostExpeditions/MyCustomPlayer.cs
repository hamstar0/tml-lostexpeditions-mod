using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ModLibsCore.Classes.PlayerData;
using ModLibsCore.Libraries.Debug;
using ModLibsCore.Libraries.DotNET.Extensions;
using ModLibsMaps.Services.Maps;


namespace LostExpeditions {
	partial class LostExpeditionsCustomPlayer : CustomPlayerData {
		protected override void OnEnter( bool isCurrentPlayer, object data ) {
			if( isCurrentPlayer ) {
				if( LostExpeditionsConfig.Instance.DebugModeLostExpeditionsReveal ) {
					this.LoadLostExpeditionMapMarkers();
				}
			}
		}

		private void LoadLostExpeditionMapMarkers() {
			var myworld = ModContent.GetInstance<LostExpeditionsWorld>();

			int i = 0;
			foreach( ((int x, int y) tile, bool found) in myworld.LostExpeditions ) {
				if( found ) {
					continue;
				}

				if( MapMarkersAPI.TryGetFullScreenMapMarker("AMLExpedition_" + i, out _) ) {
					continue;
				}

				MapMarkersAPI.SetFullScreenMapMarker(
					id: "AMLExpedition_" + i,
					tileX: tile.x,
					tileY: tile.y,
					icon: Main.itemTexture[ ItemID.Skull ],
					scale: 1f
				);

				i++;
			}
		}
	}
}
