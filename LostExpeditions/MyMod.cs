using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ModLibsCore.Libraries.Debug;
using LostExpeditions.WorldGeneration;


namespace LostExpeditions {
	public partial class LostExpeditionsMod : Mod {
		public static string GithubUserName => "hamstar0";
		public static string GithubProjectName => "tml-lostexpeditions-mod";


		////////////////

		public static LostExpeditionsMod Instance { get; private set; }



		////////////////

		internal IList<LostExpeditionGenDef> GenDefs = new List<LostExpeditionGenDef>();



		////////////////

		public override void Load() {
			LostExpeditionsMod.Instance = this;
		}

		public override void Unload() {
			LostExpeditionsMod.Instance = null;
		}


		////////////////

		public override void PostUpdateEverything() {
			if( Main.gameMenu ) {
				return;
			}
			if( Main.netMode == NetmodeID.Server ) {
				return;
			}
		}
	}
}