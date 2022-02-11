using System;
using Terraria;
using Terraria.World.Generation;
using ModLibsCore.Classes.Errors;
using ModLibsCore.Libraries.Debug;
using LostExpeditions.WorldGeneration.Presets;


namespace LostExpeditions.WorldGeneration {
	partial class LostExpeditionsGen : GenPass {
		private void CreateAllLEs( GenerationProgress progress, int count, int campWidth ) {
			var config = LostExpeditionsConfig.Instance;

			if( config.Get<bool>( nameof(config.GenDefaultSurfaceExpeditions) ) ) {
				this.CreateExpeditionFullyAt( DefaultLostExpeditionGenDefs.DungeonGenDef );
				progress.Value += 1f / ((float)count + 3f);
				count--;

				this.CreateAtMidMapLE( campWidth );
				progress.Value += 1f / ((float)count + 3f);
				count--;

				this.CreateJungleOceanLE( campWidth );
				progress.Value += 1f / ((float)count + 3f);
				count--;
			}

			if( config.Get<bool>( nameof(config.GenDefaultUndergroundExpeditions) ) ) {
				this.CreateAllUndergroundLEs( progress, count, campWidth );
			}

			foreach( var genDef in LostExpeditionsMod.Instance.GenDefs ) {
				genDef
			}
		}
	}
}
