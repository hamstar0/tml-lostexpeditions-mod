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
				(id) => DefaultLostExpeditionGenDefs.CreateRandomColoredOrbItems_If( 4 ),
				(id) => DefaultLostExpeditionGenDefs.CreateOrbsBookletItems_If(),
				(id) => DefaultLostExpeditionGenDefs.CreateModItems_If( "Orbs", "WhiteOrbItem", 4 ),
				//(id) => DefaultLostExpeditionGenDefs.CreateModItems( "LockedAbilities", "DarkHeartPieceItem", 1 )
			},
			remembersLocation: true
		);

		public static LostExpeditionGenDef MidMapGenDef => new LostExpeditionGenDef(
			name: "mid world",
			tileWidth: 12,
			customTileTypes: new int[] { ModContent.TileType<FallenCyborgTile>() },
			finder: DefaultLostExpeditionGenDefs.FindMiddleSurfaceExpeditionLocation,
			barrelItemGenerators: new LostExpeditionGenDef.ItemGenDef[] {
				(id) => DefaultLostExpeditionGenDefs.CreatePKEMeterItems_If( 4 ),
				(id) => DefaultLostExpeditionGenDefs.CreateModItems_If( "Orbs", "WhiteOrbItem", 4 ),
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
				(id) => DefaultLostExpeditionGenDefs.CreateModItems_If(
					"TheMadRanger", "SpeedloaderItem",
					Math.Min( 1, WorldGen.genRand.Next(0, 3) )
				),
				(id) => DefaultLostExpeditionGenDefs.CreateModItems_If(
					"Orbs", "WhiteOrbItem",
					Math.Min( 2, WorldGen.genRand.Next(2, 6) )
				),
				(id) => DefaultLostExpeditionGenDefs.CreateModItems_If(
					"Necrotis", "EmptyCanopicJarItem",
					WorldGen.genRand.Next(1, 2)	//(1, 3)
				),
				(id) => DefaultLostExpeditionGenDefs.CreateModItems_If(
					"Necrotis", "ElixirOfLifeItem",
					WorldGen.genRand.Next(2, 3)	//(1, 3)
				),
				(id) => DefaultLostExpeditionGenDefs.CreateModItems_If( "LockedAbilities", "DarkHeartPieceItem", 1 ),
				(id) => DefaultLostExpeditionGenDefs.CreateModItems_If( "SteampunkArsenal", "SteamBallItem", 1 )
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
				(id) => DefaultLostExpeditionGenDefs.CreateModItems_If(
					"TheMadRanger", "SpeedloaderItem",
					Math.Min( 1, WorldGen.genRand.Next(0, 3) )
				),
				(id) => DefaultLostExpeditionGenDefs.CreateModItems_If(
					"Orbs", "WhiteOrbItem",
					Math.Min( 2, WorldGen.genRand.Next(0, 4) )
				),
				(id) => DefaultLostExpeditionGenDefs.CreateModItems_If(
					"Necrotis", "EmptyCanopicJarItem",
					Math.Min( 2, WorldGen.genRand.Next(1, 4) )
				),
				(id) => DefaultLostExpeditionGenDefs.CreateModItems_If(
					"Necrotis", "ElixirOfLifeItem",
					WorldGen.genRand.Next(0, 3)
				),
				(id) => DefaultLostExpeditionGenDefs.CreateModItems_If(
					"MountedMagicMirrors", "MountableMagicMirrorTileItem",
					WorldGen.genRand.Next(-1, 2)
				),
				(id) => DefaultLostExpeditionGenDefs.CreateModItems_If(
					"SpiritWalking", "ShadowMirrorItem",
					WorldGen.genRand.NextBool() ? 1 : 0
				),
				(id) => DefaultLostExpeditionGenDefs.CreateModItems_If(
					"LockedAbilities", "DarkHeartPieceItem",
					Math.Min( 1, WorldGen.genRand.Next(0, 3) )
				),
				(id) => DefaultLostExpeditionGenDefs.CreateModItems_If(
					"SteampunkArsenal", "SteamBallItem",
					WorldGen.genRand.Next(-1, 1)
				)
			},
			remembersLocation: true
		);
	}
}
