using System;
using System.Collections.Generic;
using Terraria;
using Terraria.World.Generation;
using ModLibsCore.Classes.Errors;
using ModLibsCore.Libraries.Debug;


namespace LostExpeditions.WorldGeneration {
	partial class LostExpeditionsGen : GenPass {
		private void CreateDistributedExpeditions(
					LostExpeditionGenDef genDef,
					int amount,
					GenerationProgress progress,
					float progressUnit,
					ref IList<(int leftTileX, int nearFloorTileY)> existingExpeditions ) {
			int retries = 0;

			for( int expedNum = 1; expedNum < amount; expedNum++ ) {
				(int leftTileX, int nearFloorTileY)? expedPointRaw = genDef.Finder(
					campWidth: genDef.TileWidth,
					mostCommonTileType: out int paveTileType
				);

				if( !expedPointRaw.HasValue ) {
					LogLibraries.Log(
						"Could not finish finding places to generate all 'lost expeditions' ("
						+expedNum+" of "+amount+")"
					);
					break;
				}

				//
				
				if( this.IsNearAnotherExpedition(existingExpeditions, expedPointRaw.Value) ) {
					retries++;

					if( retries > 1000 ) {
						LogLibraries.Log(
							"Could not finish finding open places to generate all 'lost expeditions' ("
							+expedNum+" of "+amount+")"
						);

						break;	// give up
					} else {
						expedNum--;

						continue;	// repeat current finder iteration
					}
				} else {
					retries = 0;
				}

				//

				existingExpeditions.Add( (expedPointRaw.Value.leftTileX, expedPointRaw.Value.nearFloorTileY) );
			}

			//

			int i = 0;

			foreach( (int leftTileX, int nearFloorTileY) in existingExpeditions ) {
				if( !genDef.CreateExpeditionAt(leftTileX, nearFloorTileY, out string result) ) {
					LogLibraries.Log(
						"Could not finish generating all 'lost expeditions' "
						+"("+i+" of "+existingExpeditions.Count+"): "+result
					);

					break;
				}

				//

				i++;
				progress.Value += progressUnit;
			}
		}


		////////////////

		private bool IsNearAnotherExpedition(
					IList<(int leftTileX, int nearFloorTileY)> existingExpeditions,
					(int tileX, int tileY) proposed ) {
			var config = LostExpeditionsConfig.Instance;
			int minDist = config.Get<int>( nameof(config.MinimumTileDistanceBetweenLostExpeditions) );
			int minDistSqr = minDist * minDist;

			foreach( (int tileX, int tileY) in existingExpeditions ) {
				int xDiff = proposed.tileX - tileX;
				int yDiff = proposed.tileY - tileY;
				int distSqr = (xDiff * xDiff) + (yDiff * yDiff);

				if( distSqr < minDistSqr ) {
					return true;
				}
			}
			return false;
		}
	}
}
