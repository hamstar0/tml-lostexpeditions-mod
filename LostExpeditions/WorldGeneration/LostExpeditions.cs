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
			int count = 14;

			switch( WorldLibraries.GetSize() ) {
			case WorldSize.SubSmall:
				count = 11;
				break;
			case WorldSize.Small:
				count = 14;
				break;
			case WorldSize.Medium:
				count = 21;
				break;
			case WorldSize.Large:
				count = 28;
				break;
			case WorldSize.SuperLarge:
				count = 35;
				break;
			}

			this.CreateAllExpeditions( progress, count );
		}
	}
}
