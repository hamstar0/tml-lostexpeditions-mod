using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ModLibsCore.Classes.Errors;
using ModLibsCore.Libraries.Debug;
using ModLibsUtilityContent.Tiles;


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

		public static LostExpeditionGenDef MidMapGenDef => new LostExpeditionGenDef(
			name: "mid world",
			tileWidth: 12,
			customTileTypes: new int[] { ModContent.TileType<FallenCyborgTile>() },
			finder: DefaultLostExpeditionGenDefs.FindMiddleSurfaceExpeditionLocation,
			barrelItemGenerators: new LostExpeditionGenDef.ItemGenDef[] {
				() => DefaultLostExpeditionGenDefs.CreatePKEMeterItems( 2 )
			},
			remembersLocation: true
		);

		public static LostExpeditionGenDef JungleOceanGenDef => new LostExpeditionGenDef(
			name: "jungle ocean",
			tileWidth: 12,
			customTileTypes: new int[0],
			finder: DefaultLostExpeditionGenDefs.FindJungleSideBeachExpeditionLocation,
			barrelItemGenerators: new LostExpeditionGenDef.ItemGenDef[] {
				() => DefaultLostExpeditionGenDefs.CreatePKEMeterItems( 2 )f
			},
			remembersLocation: true
		);
		//hasLoreNote: true,
		//speedloaderCount: WorldGen.genRand.NextFloat() < (2f/3f) ? 1 : 0,
		//randomOrbCount: 0,
		//whiteOrbCount: WorldGen.genRand.Next( 1, 4 ),
		//canopicJarCount: WorldGen.genRand.Next( 1, 3 ),
		//elixirCount: WorldGen.genRand.Next( 1, 3 ),
		//mountedMirrorsCount: 0,
		//PKEMeterCount: 0,
		//hasOrbsBooklet: false,
		//hasShadowMirror: false,
		//darkHeartPieceCount: 1

		public static LostExpeditionGenDef UndergroundGenDef => new LostExpeditionGenDef(
			name: "underground",
			tileWidth: 12,
			customTileTypes: new int[0],
			finder: DefaultLostExpeditionGenDefs.FindUndergroundExpeditionLocation,
			barrelItemGenerators: new LostExpeditionGenDef.ItemGenDef[] {
				() => DefaultLostExpeditionGenDefs.CreatePKEMeterItems( 2 )f
			},
			remembersLocation: true
		);
		//hasLoreNote: true,
		//speedloaderCount: WorldGen.genRand.NextFloat() < (2f / 3f) ? 1 : 0,
		//randomOrbCount: 0,
		//whiteOrbCount: WorldGen.genRand.Next( 1, 4 ),
		//canopicJarCount: WorldGen.genRand.Next( 1, 3 ),
		//elixirCount: WorldGen.genRand.Next( -1, 2 ),
		//mountedMirrorsCount: WorldGen.genRand.Next( -1, 2 ),
		//PKEMeterCount: 0,
		//hasOrbsBooklet: false,
		//hasShadowMirror: WorldGen.genRand.NextBool(),
		//darkHeartPieceCount: WorldGen.genRand.Next( -1, 2 )
	}
}
