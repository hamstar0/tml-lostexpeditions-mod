using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using ModLibsCore.Classes.Errors;
using ModLibsCore.Libraries.Debug;


namespace LostExpeditions.WorldGeneration.Presets {
	public partial class DefaultLostExpeditionGenDefs {
		public static LostExpeditionGenDef DungeonGenDef => new LostExpeditionGenDef(
			name: "dungeon",
			tileWidth: 12,
			customTileTypes: new int[0],
			finder: DefaultLostExpeditionGenDefs.FindDungeonExpeditionLocation,
			barrelItemGenerators: new LostExpeditionGenDef.ItemGenDef[] {
				() => DefaultLostExpeditionGenDefs.CreateRandomOrbItems( 4 ),
				() => DefaultLostExpeditionGenDefs.CreateOrbsBookletItems(),
				() => DefaultLostExpeditionGenDefs.CreateDarkHeartPieceItems( 1 )
			},
			remembersLocation: true
		);

		/*public static LostExpeditionGenDef MidMapGenDef => new LostExpeditionGenDef(
			name: "mid world",
			tileWidth: 12,
			customTileTypes: new int[] { ModContent.TileType<FallenCyborgTile>() },
			finder: DefaultLostExpeditionGenDefs.FindDungeonExpeditionLocation,
			barrelItemGenerators: new LostExpeditionGenDef.ItemGenDef[] {
				() => DefaultLostExpeditionGenDefs.CreateRandomOrbItems( 4 ),
				() => DefaultLostExpeditionGenDefs.CreateOrbsBookletItems(),
				() => DefaultLostExpeditionGenDefs.CreateDarkHeartPieceItems( 1 )
			},
			remembersLocation: true
		);*/
	}
}
