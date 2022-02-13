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
				(id) => DefaultLostExpeditionGenDefs.CreateRandomOrbItems( 4 ),
				(id) => DefaultLostExpeditionGenDefs.CreateOrbsBookletItems(),
				(id) => DefaultLostExpeditionGenDefs.CreateDarkHeartPieceItems( 1 )
			},
			remembersLocation: true
		);

		public static LostExpeditionGenDef MidMapGenDef => new LostExpeditionGenDef(
			name: "mid world",
			tileWidth: 12,
			customTileTypes: new int[] { ModContent.TileType<FallenCyborgTile>() },
			finder: DefaultLostExpeditionGenDefs.FindMiddleSurfaceExpeditionLocation,
			barrelItemGenerators: new LostExpeditionGenDef.ItemGenDef[] {
				(id) => DefaultLostExpeditionGenDefs.CreatePKEMeterItems( 2 )
			},
			remembersLocation: true
		);

		public static LostExpeditionGenDef JungleOceanGenDef => new LostExpeditionGenDef(
			name: "jungle ocean",
			tileWidth: 12,
			customTileTypes: new int[0],
			finder: DefaultLostExpeditionGenDefs.FindJungleSideBeachExpeditionLocation,
			barrelItemGenerators: new LostExpeditionGenDef.ItemGenDef[] {
				(id) => DefaultLostExpeditionGenDefs.CreateLoreNoteItems( id ),
				(id) => DefaultLostExpeditionGenDefs.CreateSpeedloaderItems(
					WorldGen.genRand.NextFloat() < (2f/3f) ? 1 : 0 ),
				(id) => DefaultLostExpeditionGenDefs.CreateWhiteOrbItems( WorldGen.genRand.Next(1, 4) ),
				(id) => DefaultLostExpeditionGenDefs.CreateCanopicJarItems( WorldGen.genRand.Next(1, 3) ),
				(id) => DefaultLostExpeditionGenDefs.CreateElixirOfLifeItems( WorldGen.genRand.Next(1, 3) ),
				(id) => DefaultLostExpeditionGenDefs.CreateDarkHeartPieceItems( 1 )
			},
			remembersLocation: true
		);

		public static LostExpeditionGenDef UndergroundGenDef => new LostExpeditionGenDef(
			name: "underground",
			tileWidth: 12,
			customTileTypes: new int[0],
			finder: DefaultLostExpeditionGenDefs.FindUndergroundExpeditionLocation,
			barrelItemGenerators: new LostExpeditionGenDef.ItemGenDef[] {
				(id) => DefaultLostExpeditionGenDefs.CreateLoreNoteItems( id ),
				(id) => DefaultLostExpeditionGenDefs.CreateSpeedloaderItems(
					WorldGen.genRand.NextFloat() < (2f / 3f) ? 1 : 0 ),
				(id) => DefaultLostExpeditionGenDefs.CreateWhiteOrbItems( WorldGen.genRand.Next(1, 4) ),
				(id) => DefaultLostExpeditionGenDefs.CreateCanopicJarItems( WorldGen.genRand.Next(1, 3) ),
				(id) => DefaultLostExpeditionGenDefs.CreateElixirOfLifeItems( WorldGen.genRand.Next(-1, 2) ),
				(id) => DefaultLostExpeditionGenDefs.CreateMountedMirrorItems( WorldGen.genRand.Next(-1, 2) ),
				(id) => DefaultLostExpeditionGenDefs.CreateShadowMirrorItems(
					WorldGen.genRand.NextBool() ? 1 : 0 ),
				(id) => DefaultLostExpeditionGenDefs.CreateDarkHeartPieceItems( WorldGen.genRand.Next(-1, 2) )
			},
			remembersLocation: true
		);
	}
}
