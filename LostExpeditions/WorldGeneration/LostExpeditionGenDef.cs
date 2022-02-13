﻿using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using ModLibsCore.Classes.Errors;
using ModLibsCore.Libraries.Debug;


namespace LostExpeditions.WorldGeneration {
	public partial class LostExpeditionGenDef {
		public delegate IEnumerable<Item> ItemGenDef( int currentExpeditonID );

		public delegate (int leftTileX, int nearFloorTileY)? FindLocation( int campWidth, out int mostCommonTileType );



		////////////////

		public static int CurrentExpeditonID = 0;



		////////////////

		public string Name;

		////

		public int TileWidth;
		public int[] CustomTileTypes;

		////

		public FindLocation Finder;

		////

		public ItemGenDef[] BarrelItemGenerators;

		////

		public bool RemembersLocation;



		////////////////

		public LostExpeditionGenDef(
					string name,
					int tileWidth,
					int[] customTileTypes,
					FindLocation finder,
					ItemGenDef[] barrelItemGenerators,
					bool remembersLocation ) {
			this.Name = name;
			this.TileWidth = tileWidth;
			this.CustomTileTypes = customTileTypes;
			this.Finder = finder;
			this.BarrelItemGenerators = barrelItemGenerators;
			this.RemembersLocation = remembersLocation;
		}
	}
}
