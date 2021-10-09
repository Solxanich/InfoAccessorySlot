using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InfoAccessorySlot
{
	public class InfoAccessorySlot : Mod
	{
	}

	public class InfoAccSlot : ModAccessorySlot
	{
		public override bool DrawDyeSlot => false;

		public override string VanityBackgroundTexture => "Terraria/Images/Inventory_Back7"; // pale blue
		public override string FunctionalBackgroundTexture => "Terraria/Images/Inventory_Back7"; // pale blue

		public override string VanityTexture => "Terraria/Images/Item_" + ItemID.GoldWatch;
		public override string FunctionalTexture => "Terraria/Images/Item_" + ItemID.GoldWatch;

		public override void OnMouseHover(AccessorySlotType context)
		{
			// We will modify the hover text while an item is not in the slot, so that it says "Info Accessory".
			switch (context)
			{
				case AccessorySlotType.FunctionalSlot:
					Main.hoverItemName = "Info Accessory 1"; //TODO: Localiztion?
					break;
				case AccessorySlotType.VanitySlot:
					Main.hoverItemName = "Info Accessory 2"; //TODO: Localiztion?
					break;
			}
		}

        public override void ApplyEquipEffects()
        {
			Item fI = FunctionalItem.Clone();
			fI.prefix = 0;
			Player.VanillaUpdateEquip(fI);
			Player.ApplyEquipFunctional(fI, false);

			Item vI = VanityItem.Clone();
			vI.prefix = 0;
			Player.VanillaUpdateEquip(vI);
			Player.ApplyEquipFunctional(vI, false);
        }

        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context)
        {
			return CheckIfInfoAccessory(checkItem);
        }

        public override bool ModifyDefaultSwapSlot(Item item, int accSlotToSwapTo)
		{
			return CheckIfInfoAccessory(item);	
		}

		public static List<int> InfoAccessoriesByType = new List<int>()
			{ 
			  ItemID.CopperWatch, ItemID.GoldWatch, ItemID.SilverWatch, ItemID.TinWatch, ItemID.TungstenWatch, ItemID.PlatinumWatch,
			  ItemID.DepthMeter, ItemID.GPS, ItemID.Compass, ItemID.FishFinder, ItemID.WeatherRadio, ItemID.Sextant,
			  ItemID.MetalDetector, ItemID.Stopwatch, ItemID.TallyCounter, ItemID.Radar, ItemID.LifeformAnalyzer,
			  ItemID.DPSMeter, ItemID.PDA, ItemID.GoblinTech, ItemID.REK
			};

		public static List<int> OtherItemsByType = new List<int>()
			{ 
			  ItemID.CellPhone, ItemID.WireKite, ItemID.MechanicalLens, ItemID.Ruler, ItemID.LaserRuler, ItemID.PaintSprayer, 
			  ItemID.ActuationAccessory, ItemID.DontHurtCrittersBook, ItemID.EncumberingStone, ItemID.ArchitectGizmoPack
			};


		internal bool CheckIfInfoAccessory(Item item)
        {
			return InfoAccessoriesByType.Contains(item.type) || OtherItemsByType.Contains(item.type);
		}
	}
}