using System;
using Terraria;
using ModLibsCore.Libraries.Debug;


namespace LostExpeditions.WorldGeneration {
	public partial class LostExpeditionGenDef {
		public static (int tileX, int nearFloorTileY)? FindExpeditionFutureFloorArea(
					int tileX,
					int tileY,
					int maxTileY,
					int campWidth,
					int floorPavingDepth,
					int emptySpaceNeededAbove,
					bool permitDungeonWalls,
					out int mostCommonTileType ) {
			int nearFloorTileY;

			bool isValidFloor = LostExpeditionGenDef.FindValidNearFloorTileAt(
				tileX: tileX,
				topTileY: tileY,
				botTileY: maxTileY,
				neededEmptySpaceAbove: emptySpaceNeededAbove,
				permitDungeonWalls: permitDungeonWalls,
				nearFloorTileY: out nearFloorTileY
			);
			if( !isValidFloor ) {
				mostCommonTileType = -1;
				return null;
			}

			bool scan = LostExpeditionGenDef.ScanFromTileForCamp(
				tileX: tileX,
				nearFloorTileY: nearFloorTileY,
				campWidth: campWidth,
				floorPavingThickness: floorPavingDepth,
				neededEmptySpaceAbove: emptySpaceNeededAbove,
				permitDungeonWalls: permitDungeonWalls,
				campStartPos: out (int, int) scannedPosition,
				mostCommonTileType: out mostCommonTileType
			);

			if( !scan ) {
				mostCommonTileType = -1;
				return null;
			}
			
			return scannedPosition;
		}
	}
}
