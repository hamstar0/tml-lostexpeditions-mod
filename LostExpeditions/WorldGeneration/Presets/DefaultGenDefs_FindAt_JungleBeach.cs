﻿using System;
using Terraria;
using Terraria.World.Generation;
using ModLibsCore.Libraries.Debug;
using ModLibsGeneral.Libraries.World;


namespace LostExpeditions.WorldGeneration.Presets {
	public partial class DefaultLostExpeditionGenDefs {
		private static (int tileX, int nearFloorTileY)? FindJungleSideBeachExpeditionLocation(
					int campWidth,
					out int mostCommonTileType ) {
			(int, int)? scanPos;
			int dir = 0;
			int tileX = 1;
			int minTileY = WorldLocationLibraries.SkyLayerBottomTileY + 1;
			int maxTileY = WorldLocationLibraries.DirtLayerTopTileY - 1;
			int tileY = minTileY;

			if( Main.dungeonX > (Main.maxTilesX / 2) ) {
				tileX = 40;
				dir = 1;
			} else {
				tileX = Main.maxTilesX - 40;
				dir = -1;
			}

			int maxX = Main.maxTilesX / 2;

			// Clear any islands
			for( ; tileY < maxTileY; tileY++ ) {
				if( !Framing.GetTileSafely( maxX, tileY ).active() ) {
					break;
				}
			}

			for( int i=0; i<maxX; i++ ) {
				int x = tileX + (i * dir);

				scanPos = LostExpeditionsGen.FindExpeditionFutureFloorArea(
					tileX: x,
					tileY: tileY,
					maxTileY: maxTileY,
					campWidth: campWidth,
					floorPavingDepth: 8,
					emptySpaceNeededAbove: 3,
					permitDungeonWalls: false,
					mostCommonTileType: out mostCommonTileType
				);
				if( scanPos != null ) {
					return scanPos;
				}
			}

			mostCommonTileType = -1;
			return null;
		}
	}
}
