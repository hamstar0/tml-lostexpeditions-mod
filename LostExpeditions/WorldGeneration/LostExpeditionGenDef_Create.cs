using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using ModLibsCore.Classes.Errors;
using ModLibsCore.Libraries.Debug;


namespace LostExpeditions.WorldGeneration {
	public partial class LostExpeditionGenDef {
		public (int leftTileX, int nearFloorTileY)? CreateExpedition() {
			(int x, int nearFloorY)? expedPointRaw;
			int x, nearFloorY;
			int paveTileType = TileID.Dirt;

			//

			expedPointRaw = this.Finder( this.TileWidth, out paveTileType );
			if( !expedPointRaw.HasValue ) {
				LogLibraries.Alert( "Could not find a place to generate "+this.Name+" 'lost expedition'" );

				return expedPointRaw;
			}

			//

			x = expedPointRaw.Value.x;
			nearFloorY = expedPointRaw.Value.nearFloorY;

			//

			if( !this.CreateExpeditionAt(this, x, nearFloorY, out string err ) ) {
				LogLibraries.Log( "Could not generate "+this.Name+" 'lost expedition': "+err );
			}

			return expedPointRaw;
		}


		////////////////

		private bool CreateExpeditionAt(
					LostExpeditionGenDef def,
					int leftTileX,
					int nearFloorTileY,
					out string result ) {
			int paveTileType = TileID.Dirt;
			int chestIdx;

			//

			bool createdCamp = LostExpeditionsGen.CreateExpeditionStructure(
				leftTileX: leftTileX,
				nearFloorTileY: nearFloorTileY,
				campWidth: def.TileWidth + 2,
				customTiles: def.CustomTileTypes,
				paveTileType: paveTileType,
				rememberLocation: def.RemembersLocation,
				chestIdx: out chestIdx,
				result: out result
			);

			if( createdCamp ) {
				LostExpeditionsGen.FillExpeditionBarrel(
					tileX: leftTileX,
					tileY: nearFloorTileY,
					chestIdx: chestIdx,
					itemGenDefs: def.BarrelItemGenerators
				);
			}

			return createdCamp;
		}
	}
}
