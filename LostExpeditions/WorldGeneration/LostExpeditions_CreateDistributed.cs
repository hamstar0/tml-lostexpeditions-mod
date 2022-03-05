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
			var proposedExpeditions = new List<(int leftTileX, int nearFloorTileY)>();

			int retries = 0;
			
			for( int expedNum = 0; expedNum < amount; expedNum++ ) {
				(int leftTileX, int nearFloorTileY)? testExpedition = genDef.Finder(
					campWidth: genDef.TileWidth,
					mostCommonTileType: out int paveTileType
				);

				if( !testExpedition.HasValue ) {
					LogLibraries.Log(
						"Could not finish finding places to generate all 'lost expeditions' ("
						+(expedNum+1)+" of "+amount+")"
					);
					break;
				}

				//

				bool isNearOtherExpedition =
					this.IsNearAnotherExpedition( proposedExpeditions, testExpedition.Value ) ||
					this.IsNearAnotherExpedition( existingExpeditions, testExpedition.Value );

				if( isNearOtherExpedition ) {
					retries++;

					if( retries > 5000 ) {
						LogLibraries.Log(
							"Could not finish finding open places to generate all 'lost expeditions' ("
							+(expedNum+1)+" of "+amount+")"
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

				proposedExpeditions.Add(
					(testExpedition.Value.leftTileX, testExpedition.Value.nearFloorTileY)
				);
			}

			//

			int i = 0;

			foreach( (int leftTileX, int nearFloorTileY) in proposedExpeditions ) {
				bool isCreated = genDef.CreateExpeditionAt( leftTileX, nearFloorTileY, out string result );

				if( !isCreated ) {
					LogLibraries.Log(
						"Could not finish generating lost expedition at "+leftTileX+", "+nearFloorTileY
						+" ("+i+" of "+amount+"): "+result
					);

					//break;
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
