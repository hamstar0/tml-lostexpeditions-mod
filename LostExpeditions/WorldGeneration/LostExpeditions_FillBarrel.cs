using System;
using Terraria;
using Terraria.World.Generation;
using Terraria.ModLoader;
using ModLibsCore.Libraries.Debug;


namespace LostExpeditions.WorldGeneration {
	partial class LostExpeditionsGen : GenPass {
		public static void FillExpeditionBarrel(
					int tileX,
					int tileY,
					int chestIdx,
					LostExpeditionGenDef.ItemGenDef[] itemGenDefs,
					int currentExpeditonID ) {
			if( chestIdx == -1 ) {
				LogLibraries.Warn( "Could not fill 'lost expedition' barrel at "+tileX+", "+tileY+"." );
				return;
			}

			Item[] chest = Main.chest[chestIdx].item;
			int itemIdx = 0;

			foreach( LostExpeditionGenDef.ItemGenDef itemGenDef in itemGenDefs ) {
				foreach( Item item in itemGenDef.Invoke(currentExpeditonID) ) {
					if( item != null ) {
						chest[ itemIdx++ ] = item;
					}
				}
			}


			/*if( hasLoreNote ) {
				Item newItem = LostExpeditionsGen.CreateLoreNoteItem( this.CurrentLE );
				if( newItem != null ) {
					chest[itemIdx++] = newItem;
				}
			}
			for( int i=0; i<speedloaderCount; i++ ) {
				Item newItem = LostExpeditionsGen.CreateSpeedloaderItem();
				if( newItem != null ) {
					chest[itemIdx++] = newItem;
				}
			}
			for( int i=0; i< randomOrbCount; i++ ) {
				Item newItem = LostExpeditionsGen.CreateRandomOrbItem();
				if( newItem != null ) {
					chest[itemIdx++] = newItem;
				}
			}
			for( int i=0; i<whiteOrbCount; i++ ) {
				Item newItem = LostExpeditionsGen.CreateWhiteOrbItem();
				if( newItem != null ) {
					chest[itemIdx++] = newItem;
				}
			}
			for( int i=0; i<canopicJarCount; i++ ) {
				Item newItem = LostExpeditionsGen.CreateCanopicJarItem();
				if( newItem != null ) {
					chest[itemIdx++] = newItem;
				}
			}
			for( int i=0; i<elixirCount; i++ ) {
				Item newItem = LostExpeditionsGen.CreateElixirOfLifeItem();
				if( newItem != null ) {
					chest[itemIdx++] = newItem;
				}
			}
			for( int i=0; i<mountedMirrorsCount; i++ ) {
				Item newItem = LostExpeditionsGen.CreateMountedMirrorItem();
				if( newItem != null ) {
					chest[itemIdx++] = newItem;
				}
			}
			for( int i = 0; i<PKEMeterCount; i++ ) {
				(Item meterItem, Item missionItem, Item manualItem)? pkeItems = LostExpeditionsGen.CreatePKEMeterItems();
				if( pkeItems.HasValue ) {
					chest[itemIdx++] = pkeItems.Value.meterItem;
					if( i == 0 ) {
						chest[itemIdx++] = pkeItems.Value.missionItem;
						chest[itemIdx++] = pkeItems.Value.manualItem;
					}
				}
			}
			if( hasOrbsBooklet ) {
				Item bookItem = LostExpeditionsGen.CreateOrbsBookletItem();
				if( bookItem != null ) {
					chest[itemIdx++] = bookItem;
				}
			}
			if( hasShadowMirror ) {
				Item mirrorItem = LostExpeditionsGen.CreateShadowMirrorItem();
				if( mirrorItem != null ) {
					chest[itemIdx++] = mirrorItem;
				}
			}
			for( int i=0; i< darkHeartPieceCount; i++ ) {
				Item newItem = LostExpeditionsGen.CreateDarkHeartPieceItem();
				if( newItem != null ) {
					chest[itemIdx++] = newItem;
				}
			}

			if( hasLoreNote ) {
				this.CurrentLE = (this.CurrentLE + 1) % LostExpeditionsGen.LoreNotes.Length;
			}*/
		}
	}
}
