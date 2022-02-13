using System;
using Terraria;
using ModLibsCore.Libraries.Debug;
using ModLibsGeneral.Libraries.World;


namespace LostExpeditions.WorldGeneration.Presets {
	public partial class DefaultLostExpeditionGenDefs {
		private static (int x, int y)? FindUndergroundExpeditionLocation( int campWidth, out int mostCommonTileType ) {
			int maxTileY = WorldLocationLibraries.RockLayerBottomTileY;

			for( int i=0; i<2000; i++ ) {
				int tileX = WorldGen.genRand.Next( WorldLocationLibraries.BeachWestTileX, WorldLocationLibraries.BeachEastTileX );
				int tileY = WorldGen.genRand.Next( WorldLocationLibraries.DirtLayerTopTileY, maxTileY );

				(int, int)? scanPos = LostExpeditionGenDef.FindExpeditionFutureFloorArea(
					tileX: tileX,
					tileY: tileY,
					maxTileY: maxTileY,
					campWidth: campWidth,
					floorPavingDepth: 6,
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
