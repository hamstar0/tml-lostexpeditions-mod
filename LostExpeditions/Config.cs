using System;
using System.ComponentModel;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;


namespace LostExpeditions {
	public partial class LostExpeditionsConfig : ModConfig {
		public static LostExpeditionsConfig Instance => ModContent.GetInstance<LostExpeditionsConfig>();



		////////////////

		public override ConfigScope Mode => ConfigScope.ServerSide;


		////////////////

		public bool DebugModeMiscInfo { get; set; } = false;

		public bool DebugModeLostExpeditionsReveal { get; set; } = false;

		////

		[Range(-1, 4048)]
		[DefaultValue( 256 )]
		public int LostExpeditionDetectionTileRangeMax { get; set; } = 256;

		[Range(0, 4048)]
		[DefaultValue( 160 )]
		public int MinimumTileDistanceBetweenLostExpeditions { get; set; } = 160;



		////////////////

		public override ModConfig Clone() {
			var clone = (LostExpeditionsConfig)this.MemberwiseClone();

			clone.CloneOverrides( this );

			return clone;
		}
	}
}
