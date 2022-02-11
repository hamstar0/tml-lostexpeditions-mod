using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using ModLibsCore.Libraries.Debug;


namespace LostExpeditions {
	partial class LostExpeditionsPlayer : ModPlayer {
		public override bool CloneNewInstances => false;



		////////////////
		
		 private int _LEsDiscoveryRecheckTimer = 0;

		public override void PreUpdate() {
			if( this._LEsDiscoveryRecheckTimer-- <= 0 ) {
				this._LEsDiscoveryRecheckTimer = 15;

				this.DiscoverNearbyLEsIf();
			}
		}
	}
}
