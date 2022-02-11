using System;
using Terraria;
using Terraria.ID;
using Terraria.World.Generation;
using ModLibsCore.Classes.Errors;
using ModLibsCore.Libraries.Debug;


namespace LostExpeditions.WorldGeneration {
	partial class LostExpeditionsGen : GenPass {
		private void CreateExpeditionFullyAt( LostExpeditionGenDef def ) {
			(int x, int nearFloorY)? expedPointRaw;
			int x, nearFloorY;
			int paveTileType = TileID.Dirt;
			int chestIdx;
			string err;

			//

			expedPointRaw = this.FindDungeonExpeditionLocation( def.TileWidth, out paveTileType );
			if( !expedPointRaw.HasValue ) {
				throw new ModLibsException( "Could not find a place to generate "+def.Name+" 'lost expedition'" );
			}

			//

			x = expedPointRaw.Value.x;
			nearFloorY = expedPointRaw.Value.nearFloorY;

			bool createdCamp = this.CreateExpeditionAt(
				leftTileX: x,
				nearFloorTileY: nearFloorY,
				campWidth: def.TileWidth + 2,
				customTiles: def.CustomTileTypes,
				paveTileType: paveTileType,
				rememberLocation: def.RemembersLocation,
				chestIdx: out chestIdx,
				result: out err
			);
			if( !createdCamp ) {
				LogLibraries.Log( "Could not generate "+def.Name+" 'lost expedition': " + err );
				return;
			}

			//

			this.FillExpeditionBarrel(
				tileX: expedPointRaw.Value.x,
				nearFloorTileY: expedPointRaw.Value.nearFloorY,
				chestIdx: chestIdx,
				itemGenDefs: def.BarrelItemGenerators
			);
		}
	}
}
