using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using ModLibsCore.Libraries.DotNET.Extensions;
using LostExpeditions.WorldGeneration;


namespace LostExpeditions {
	public class LostExpeditionsAPI {
		public static (int chestTileX, int nearFloorTileY)[] GetLostExpeditionLocations() {
			var myworld = ModContent.GetInstance<LostExpeditionsWorld>();
			return myworld.LostExpeditions
				.Keys.ToArray();
		}

		public static bool? IsLostExpeditionFound( int chestTileX, int nearFloorTileY ) {
			var myworld = ModContent.GetInstance<LostExpeditionsWorld>();
			return myworld.LostExpeditions
				.GetOrDefault( (chestTileX, nearFloorTileY) );
		}


		////////////////
		
		public static void AddGenDefinition( LostExpeditionGenDef def, int quantity ) {
			LostExpeditionsMod.Instance
				.GenDefs
				.Add( (def, quantity) );
		}


		////////////////

		public static float? GaugeUnexploredExpeditionsNear(
					Vector2 worldPos,
					out (int tileX, int tileY) nearestFEPos ) {
			return LostExpeditionsWorld.GaugeUnexploredExpeditionsNear( worldPos, out nearestFEPos );
		}
	}
}
