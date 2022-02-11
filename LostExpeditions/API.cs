using System;
using LostExpeditions.WorldGeneration;


namespace LostExpeditions {
	public class LostExpeditionsAPI {
		public static void AddGenDefinition( LostExpeditionGenDef def ) {
			LostExpeditionsMod.Instance.GenDefs.Add( def );
		}
	}
}
