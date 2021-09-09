using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ObsidianGear.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	class ObsidianGreaves : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Obsidian Greaves");
			Tooltip.SetDefault("+5% increased movement speed");
		}

		public override void SetDefaults()
		{
			item.width = 11;
			item.height = 9;
			item.value = Item.sellPrice(0, 0, 60, 0);
			item.rare = ItemRarityID.Green;
			item.defense = 6;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.05f;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return head.type == ModContent.ItemType<ObsidianHelm>() && legs.type == ModContent.ItemType<ObsidianGreaves>();

		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ObsidianIngot>(), 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
