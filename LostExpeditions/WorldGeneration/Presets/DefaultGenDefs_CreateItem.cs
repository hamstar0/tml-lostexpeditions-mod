using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ModLibsCore.Classes.Errors;
using ModLibsCore.Libraries.Debug;
using ReadableBooks.Items.ReadableBook;


namespace LostExpeditions.WorldGeneration.Presets {
	public partial class DefaultLostExpeditionGenDefs {
		private static IList<Item> CreateRandomOrbItems( int count ) {
			if( ModLoader.GetMod("Orbs") == null ) {
				return new List<Item>( 0 );
			}

			//

			var items = new List<Item>( count );

			for( int i = 0; i < count; i++ ) {
				Item newItem = DefaultLostExpeditionGenDefs.CreateRandomOrbItem_WeakRef();
				if( newItem != null ) {
					items.Add( newItem );
				}
			}

			return items;
		}
		
		private static Item CreateRandomOrbItem_WeakRef() {
			var item = new Item();
			switch( WorldGen.genRand.Next(8) ) {
			case 0:
				item.SetDefaults( ModContent.ItemType<Orbs.Items.BlueOrbItem>(), true );
				break;
			case 1:
				item.SetDefaults( ModContent.ItemType<Orbs.Items.BrownOrbItem>(), true );
				break;
			case 2:
				item.SetDefaults( ModContent.ItemType<Orbs.Items.CyanOrbItem>(), true );
				break;
			case 3:
				item.SetDefaults( ModContent.ItemType<Orbs.Items.GreenOrbItem>(), true );
				break;
			case 4:
				item.SetDefaults( ModContent.ItemType<Orbs.Items.PinkOrbItem>(), true );
				break;
			case 5:
				item.SetDefaults( ModContent.ItemType<Orbs.Items.PurpleOrbItem>(), true );
				break;
			case 6:
				item.SetDefaults( ModContent.ItemType<Orbs.Items.RedOrbItem>(), true );
				break;
			case 7:
				item.SetDefaults( ModContent.ItemType<Orbs.Items.YellowOrbItem>(), true );
				break;
			//case 8:
			//	item.SetDefaults( ModContent.ItemType<Orbs.Items.WhiteOrbItem>(), true );
			//	break;
			}

			return item;
		}


		////

		private static IList<Item> CreateOrbsBookletItems() {
			if( ModLoader.GetMod("Orbs") == null ) {
				return new List<Item>( 0 );
			}

			Item orbsBookletItem = ReadableBookItem.CreateBook(
				"Guide To Orbs",
				new string[] {
					"Also known as Spirit Orbs or Geo-Resonant Orbs, these spheres contain spiritual energy"
					+"\nparticularly attuned to the land itself. An orb's color indicates the nature of its"
					+"\nresonance; certain methods exist to find matchingly-resonant patches of terrain.",
					"An orb can be directly applied to these areas to cause them to disperse, creating voids"
					+"\nthat may allow one to access what lies beneath. Though consumed on use, this is the"
					+"\nonly known means to obtain access to many of Terraria's buried secrets.",
					"The ancient inhabitants of this land locked away their dead and their secrets within"
					+"\nthe ground with such magics that merely digging or blasting them out is of no avail."
				}
			);

			return new List<Item> { orbsBookletItem };
		}


		////

		private static IList<Item> CreateDarkHeartPieceItems( int count ) {
			if( ModLoader.GetMod("LockedAbilities") == null ) {
				return new List<Item>( 0 );
			}

			//

			var items = new List<Item>( count );

			for( int i = 0; i < count; i++ ) {
				Item newItem = DefaultLostExpeditionGenDefs.CreateDarkHeartPieceItem_WeakRef();
				if( newItem != null ) {
					items.Add( newItem );
				}
			}

			return items;
		}

		private static Item CreateDarkHeartPieceItem_WeakRef() {
			var item = new Item();
			int darkHeartItemType = ModContent.ItemType<LockedAbilities.Items.Consumable.DarkHeartPieceItem>();

			item.SetDefaults( darkHeartItemType, true );

			return item;
		}


		////

		private static IEnumerable<Item> CreateLoreNoteItems( int currentExpedId ) {
			int noteIdx = currentExpedId % LostExpeditionsGen.LoreNotes.Length;

			Item note = ReadableBookItem.CreateBook(
				LostExpeditionsGen.LoreNotes[noteIdx].title,
				LostExpeditionsGen.LoreNotes[noteIdx].pages
			);

			return new Item[] { note };
		}


		////

		private static Item CreateSpeedloaderItem() {
			if( ModLoader.GetMod("TheMadRanger") != null ) {
				return DefaultLostExpeditionGenDefs.CreateSpeedloaderItem_WeakRef();
			}
			return default;
		}

		private static Item CreateSpeedloaderItem_WeakRef() {
			var item = new Item();
			item.SetDefaults( ModContent.ItemType<TheMadRanger.Items.SpeedloaderItem>(), true );

			return item;
		}


		////

		private static Item CreateWhiteOrbItem() {
			if( ModLoader.GetMod("Orbs") != null ) {
				return DefaultLostExpeditionGenDefs.CreateWhiteOrbItem_WeakRef();
			}
			return default;
		}
		
		private static Item CreateWhiteOrbItem_WeakRef() {
			var item = new Item();
			/*switch( WorldGen.genRand.Next(8) ) {
			case 0:
				item.SetDefaults( ModContent.ItemType<Orbs.Items.BlueOrbItem>(), true );
				break;
			case 1:
				item.SetDefaults( ModContent.ItemType<Orbs.Items.BrownOrbItem>(), true );
				break;
			case 2:
				item.SetDefaults( ModContent.ItemType<Orbs.Items.CyanOrbItem>(), true );
				break;
			case 3:
				item.SetDefaults( ModContent.ItemType<Orbs.Items.GreenOrbItem>(), true );
				break;
			case 4:
				item.SetDefaults( ModContent.ItemType<Orbs.Items.PinkOrbItem>(), true );
				break;
			case 5:
				item.SetDefaults( ModContent.ItemType<Orbs.Items.PurpleOrbItem>(), true );
				break;
			case 6:
				item.SetDefaults( ModContent.ItemType<Orbs.Items.RedOrbItem>(), true );
				break;
			case 7:
				item.SetDefaults( ModContent.ItemType<Orbs.Items.YellowOrbItem>(), true );
				break;
			}*/
			item.SetDefaults( ModContent.ItemType<Orbs.Items.WhiteOrbItem>(), true );

			return item;
		}


		////

		private static Item CreateCanopicJarItem() {
			if( ModLoader.GetMod("Necrotis") != null ) {
				return DefaultLostExpeditionGenDefs.CreateCanopicJarItem_WeakRef();
			}
			return default;
		}

		private static Item CreateCanopicJarItem_WeakRef() {
			var item = new Item();
			item.SetDefaults( ModContent.ItemType<Necrotis.Items.EmptyCanopicJarItem>(), true );

			return item;
		}

		////

		private static Item CreateElixirOfLifeItem() {
			if( ModLoader.GetMod("Necrotis") != null ) {
				return DefaultLostExpeditionGenDefs.CreateElixirOfLifeItem_WeakRef();
			}
			return default;
		}

		private static Item CreateElixirOfLifeItem_WeakRef() {
			var item = new Item();
			item.SetDefaults( ModContent.ItemType<Necrotis.Items.ElixirOfLifeItem>(), true );

			return item;
		}

		////

		private static Item CreateMountedMirrorItem() {
			if( ModLoader.GetMod("MountedMagicMirrors") != null ) {
				return DefaultLostExpeditionGenDefs.CreateMountedMirrorItem_WeakRef();
			}
			return default;
		}

		private static Item CreateMountedMirrorItem_WeakRef() {
			var item = new Item();
			item.SetDefaults( ModContent.ItemType<MountedMagicMirrors.Items.MountableMagicMirrorTileItem>(), true );

			return item;
		}

		////

		private static IEnumerable<Item> CreatePKEMeterItems( int meterCount ) {
			if( ModLoader.GetMod("PKEMeter") == null ) {
				return new List<Item>( 0 );
			}

			(Item[] i1, Item i2, Item i3) items = DefaultLostExpeditionGenDefs.CreatePKEMeterItems_WeakRef( meterCount );
			var list = new List<Item>( items.i1 );
			list.Add( items.i2 );
			list.Add( items.i3 );
			return list;
		}

		private static (Item[] meterItems, Item missionItem, Item manualItem) CreatePKEMeterItems_WeakRef(
					int meterCount ) {
			var meterItems = new Item[meterCount];

			for( int i=0; i<meterCount; i++ ) {
				var meterItem = new Item();
				meterItem.SetDefaults( ModContent.ItemType<PKEMeter.Items.PKEMeterItem>(), true );

				meterItems[i] = meterItem;
			}

			//

			Item missionItem = ReadableBookItem.CreateBook(
				DefaultLostExpeditionGenDefs.MissionBriefingBookInfo.title,
				DefaultLostExpeditionGenDefs.MissionBriefingBookInfo.pages
			);

			Item manualItem = ReadableBookItem.CreateBook(
				DefaultLostExpeditionGenDefs.PKEBookInfo.title,
				DefaultLostExpeditionGenDefs.PKEBookInfo.pages
			);

			return (meterItems, missionItem, manualItem);
		}


		////

		private static Item CreateShadowMirrorItem() {
			if( ModLoader.GetMod("SpiritWalking") != null ) {
				return DefaultLostExpeditionGenDefs.CreateShadowMirrorItem_WeakRef();
			}
			return default;
		}

		private static Item CreateShadowMirrorItem_WeakRef() {
			var mirrorItem = new Item();
			int itemType = ModContent.ItemType<SpiritWalking.Items.ShadowMirrorItem>();

			mirrorItem.SetDefaults( itemType, true );

			return mirrorItem;
		}
	}
}
