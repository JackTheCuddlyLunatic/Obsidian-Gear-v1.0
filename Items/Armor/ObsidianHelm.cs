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
	[AutoloadEquip(EquipType.Head)]
	class ObsidianHelm : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Obsidian Helm");
			Tooltip.SetDefault("+5% increased melee speed");
		}

		public override void SetDefaults()
		{
			item.width = 14;
			item.height = 14;
			item.value = Item.sellPrice(0, 0, 60, 0);
			item.rare = ItemRarityID.Green;
			item.defense = 7;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeSpeed += 0.05f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return head.type == ModContent.ItemType<ObsidianHelm>() && legs.type == ModContent.ItemType<ObsidianGreaves>();

		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ObsidianIngot>(), 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

	}
}
