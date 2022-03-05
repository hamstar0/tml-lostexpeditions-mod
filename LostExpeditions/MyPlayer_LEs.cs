using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using ModLibsCore.Libraries.Debug;


namespace LostExpeditions {
	partial class LostExpeditionsPlayer : ModPlayer {
		private void DiscoverNearbyLEsIf() {
			(int tileX, int tileY) nearestFEPos;
			float? unexploredNear = LostExpeditionsWorld.GaugeUnexploredExpeditionsNear(
				worldPos: this.player.MountedCenter,
				nearestFEPos: out nearestFEPos
			);
			if( !unexploredNear.HasValue ) {
				return;
			}

			//

			int minTileDist = 6;
			int minTileDistSqr = minTileDist * minTileDist;

			int xDiff = nearestFEPos.tileX - ((int)this.player.MountedCenter.X / 16);
			int yDiff = nearestFEPos.tileY - ((int)this.player.MountedCenter.Y / 16);
			int distSqr = (xDiff * xDiff) + (yDiff * yDiff);

			if( distSqr <= minTileDistSqr ) {
				if( this.player.whoAmI == Main.myPlayer ) {
					Main.NewText( "You discovered a lost expedition!", Color.Lime );
				} else {
					Main.NewText( "Lost expedition discovered!", Color.Lime );
				}

				LostExpeditionsWorld.RevealExpeditionAt( nearestFEPos.tileX, nearestFEPos.tileY );
			}
		}
	}
}
