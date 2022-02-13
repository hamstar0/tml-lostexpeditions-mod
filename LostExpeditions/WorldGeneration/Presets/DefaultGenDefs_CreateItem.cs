﻿using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ModLibsCore.Classes.Errors;
using ModLibsCore.Libraries.Debug;
using ReadableBooks.Items.ReadableBook;


namespace LostExpeditions.WorldGeneration.Presets {
	public partial class DefaultLostExpeditionGenDefs {
		private static IEnumerable<Item> CreateRandomOrbItems( int quantity ) {
			if( ModLoader.GetMod("Orbs") == null || quantity <= 0 ) {
				return new List<Item>( 0 );
			}

			//

			var items = new List<Item>( quantity );

			for( int i = 0; i < quantity; i++ ) {
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

		private static IEnumerable<Item> CreateDarkHeartPieceItems( int quantity ) {
			if( ModLoader.GetMod("LockedAbilities") == null || quantity <= 0 ) {
				return new List<Item>( 0 );
			}

			return DefaultLostExpeditionGenDefs.CreateDarkHeartPieceItems_WeakRef( quantity );
		}

		private static IEnumerable<Item> CreateDarkHeartPieceItems_WeakRef( int quantity ) {
			int darkHeartItemType = ModContent.ItemType<LockedAbilities.Items.Consumable.DarkHeartPieceItem>();
			var items = new List<Item>( quantity );

			for( int i = 0; i < quantity; i++ ) {
				var item = new Item();
				item.SetDefaults( darkHeartItemType, true );

				items.Add( item );
			}

			return items;
		}


		////

		private static IEnumerable<Item> CreateLoreNoteItems( int currentExpedId ) {
			int noteIdx = currentExpedId % DefaultLostExpeditionGenDefs.LoreNotes.Length;

			Item note = ReadableBookItem.CreateBook(
				DefaultLostExpeditionGenDefs.LoreNotes[noteIdx].title,
				DefaultLostExpeditionGenDefs.LoreNotes[noteIdx].pages
			);

			return new Item[] { note };
		}


		////

		private static IEnumerable<Item> CreateSpeedloaderItems( int quantity ) {
			if( ModLoader.GetMod("TheMadRanger") == null || quantity <= 0 ) {
				return new List<Item>( 0 );
			}
			return DefaultLostExpeditionGenDefs.CreateSpeedloaderItems_WeakRef( quantity );
		}

		private static IEnumerable<Item> CreateSpeedloaderItems_WeakRef( int quantity ) {
			var items = new List<Item>( quantity );
			int itemType = ModContent.ItemType<TheMadRanger.Items.SpeedloaderItem>();

			for( int i=0; i<quantity; i++ ) {
				var item = new Item();
				item.SetDefaults( itemType, true );

				items.Add( item );
			}

			return items;
		}


		////

		private static IEnumerable<Item> CreateWhiteOrbItems( int quantity ) {
			if( ModLoader.GetMod("Orbs") == null || quantity <= 0 ) {
				return new List<Item>( 0 );
			}
			return DefaultLostExpeditionGenDefs.CreateWhiteOrbItems_WeakRef( quantity );
		}
		
		private static IEnumerable<Item> CreateWhiteOrbItems_WeakRef( int quantity ) {
			var items = new List<Item>( quantity );
			int itemType = ModContent.ItemType<Orbs.Items.WhiteOrbItem>();

			for( int i = 0; i < quantity; i++ ) {
				var item = new Item();
				item.SetDefaults( itemType, true );

				items.Add( item );
			}

			return items;

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
		}


		////

		private static IEnumerable<Item> CreateCanopicJarItems( int quantity ) {
			if( ModLoader.GetMod("Necrotis") == null || quantity <= 0 ) {
				return new List<Item>( 0 );
			}
			return DefaultLostExpeditionGenDefs.CreateCanopicJarItems_WeakRef( quantity );
		}

		private static IEnumerable<Item> CreateCanopicJarItems_WeakRef( int quantity ) {
			var items = new List<Item>( quantity );
			int itemType = ModContent.ItemType<Necrotis.Items.EmptyCanopicJarItem>();

			for( int i = 0; i < quantity; i++ ) {
				var item = new Item();
				item.SetDefaults( itemType, true );

				items.Add( item );
			}

			return items;
		}

		////

		private static IEnumerable<Item> CreateElixirOfLifeItems( int quantity ) {
			if( ModLoader.GetMod("Necrotis") != null || quantity <= 0 ) {
				return new List<Item>( 0 );
			}
			return DefaultLostExpeditionGenDefs.CreateElixirOfLifeItems_WeakRef( quantity );
		}

		private static IEnumerable<Item> CreateElixirOfLifeItems_WeakRef( int quantity ) {
			var items = new List<Item>( quantity );
			int itemType = ModContent.ItemType<Necrotis.Items.ElixirOfLifeItem>();

			for( int i = 0; i < quantity; i++ ) {
				var item = new Item();
				item.SetDefaults( itemType, true );

				items.Add( item );
			}

			return items;
		}

		////

		private static IEnumerable<Item> CreateMountedMirrorItems( int quantity ) {
			if( ModLoader.GetMod("MountedMagicMirrors") == null || quantity <= 0 ) {
				return new List<Item>( 0 );
			}
			return DefaultLostExpeditionGenDefs.CreateMountedMirrorItems_WeakRef( quantity );
		}

		private static IEnumerable<Item> CreateMountedMirrorItems_WeakRef( int quantity ) {
			var items = new List<Item>( quantity );
			int itemType = ModContent.ItemType<MountedMagicMirrors.Items.MountableMagicMirrorTileItem>();

			for( int i = 0; i < quantity; i++ ) {
				var item = new Item();
				item.SetDefaults( itemType, true );

				items.Add( item );
			}

			return items;
		}

		////

		private static IEnumerable<Item> CreatePKEMeterItems( int meterCount ) {
			if( ModLoader.GetMod("PKEMeter") == null || meterCount <= 0 ) {
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

		private static IEnumerable<Item> CreateShadowMirrorItems( int quantity ) {
			if( ModLoader.GetMod("SpiritWalking") == null || quantity <= 0 ) {
				return new List<Item>( 0 );
			}
			return DefaultLostExpeditionGenDefs.CreateShadowMirrorItems_WeakRef( quantity );
		}

		private static IEnumerable<Item> CreateShadowMirrorItems_WeakRef( int quantity ) {
			var items = new List<Item>( quantity );
			int itemType = ModContent.ItemType<SpiritWalking.Items.ShadowMirrorItem>();

			for( int i = 0; i < quantity; i++ ) {
				var item = new Item();
				item.SetDefaults( itemType, true );

				items.Add( item );
			}

			return items;
		}
	}
}
