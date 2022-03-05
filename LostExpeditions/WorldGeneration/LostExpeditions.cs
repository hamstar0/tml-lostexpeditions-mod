using System;
using Terraria;
using Terraria.World.Generation;
using ModLibsCore.Libraries.Debug;
using ModLibsGeneral.Libraries.World;


namespace LostExpeditions.WorldGeneration {
	partial class LostExpeditionsGen : GenPass {
		public LostExpeditionsGen() : base( "Lost Expeditions", 1f ) { }


		////

		public override void Apply( GenerationProgress progress ) {
			int count = 16;

			switch( WorldLibraries.GetSize() ) {
			case WorldSize.SubSmall:
				count = 11;
				break;
			case WorldSize.Small:
				count = 16;
				break;
			case WorldSize.Medium:
				count = 23;
				break;
			case WorldSize.Large:
				count = 30;
				break;
			case WorldSize.SuperLarge:
				count = 37;
				break;
			}

			this.CreateAllExpeditions( progress, count );
		}
	}
}
