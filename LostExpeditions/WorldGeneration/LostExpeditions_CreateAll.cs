using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.World.Generation;
using ModLibsCore.Classes.Errors;
using ModLibsCore.Libraries.Debug;
using LostExpeditions.WorldGeneration.Presets;


namespace LostExpeditions.WorldGeneration {
	partial class LostExpeditionsGen : GenPass {
		private void CreateAllExpeditions( GenerationProgress progress, int count ) {
			var config = LostExpeditionsConfig.Instance;

			(int leftTileX, int nearFloorTileY)? expedition;
			IList<(int leftTileX, int nearFloorTileY)> existingExpeditions = new List<(int, int)>();

			//

			int totalCustomGens = LostExpeditionsMod.Instance.GenDefs
				.Sum( e => e.Count );
			float progUnit = 1f / (float)(totalCustomGens + count);

			//

			if( config.Get<bool>( nameof(config.CreateDefaultSurfaceExpeditions) ) ) {
				expedition = DefaultLostExpeditionGenDefs.DungeonGenDef.CreateExpedition();
				if( expedition.HasValue ) {
					existingExpeditions.Add( expedition.Value );
					progress.Value += progUnit;
					count--;
				} else {
					LogLibraries.Alert(
						"Could not gen expedition "
						+ DefaultLostExpeditionGenDefs.DungeonGenDef.Name
					);
				}

				expedition = DefaultLostExpeditionGenDefs.MidMapGenDef.CreateExpedition();
				if( expedition.HasValue ) {
					existingExpeditions.Add( expedition.Value );
					progress.Value += progUnit;
					count--;
				} else {
					LogLibraries.Alert(
						"Could not gen expedition "
						+DefaultLostExpeditionGenDefs.MidMapGenDef.Name
					);
				}

				expedition = DefaultLostExpeditionGenDefs.JungleOceanGenDef.CreateExpedition();
				if( expedition.HasValue ) {
					existingExpeditions.Add( expedition.Value );
					progress.Value += progUnit;
					count--;
				} else {
					LogLibraries.Alert(
						"Could not gen expedition "
						+ DefaultLostExpeditionGenDefs.JungleOceanGenDef.Name
					);
				}
			}

			//

			if( config.Get<bool>( nameof(config.CreateDefaultUndergroundExpeditions) ) ) {
				this.CreateDistributedExpeditions(
					genDef: DefaultLostExpeditionGenDefs.UndergroundGenDef,
					amount: count,
					progress: progress,
					progressUnit: progUnit,
					existingExpeditions: ref existingExpeditions
				);
			}

			//

			foreach( (LostExpeditionGenDef myGenDef, int myGenCount) in LostExpeditionsMod.Instance.GenDefs ) {
				this.CreateDistributedExpeditions(
					genDef: myGenDef,
					amount: myGenCount,
					progress: progress,
					progressUnit: progUnit,
					existingExpeditions: ref existingExpeditions
				);
			}
		}
	}
}
