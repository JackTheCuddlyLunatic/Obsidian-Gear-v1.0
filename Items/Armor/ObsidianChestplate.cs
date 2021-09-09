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
    [AutoloadEquip(EquipType.Body)]
    public class ObsidianChestplate : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Obsidian Breastplate");
			Tooltip.SetDefault("+5% increased melee damage");
		}

		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 10;
			item.value = Item.sellPrice(0,  0, 60, 0);
			item.rare = ItemRarityID.Green;
			item.defense = 8;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.05f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return head.type == ModContent.ItemType<ObsidianHelm>() && legs.type == ModContent.ItemType<ObsidianGreaves>();

		}
        public override void UpdateArmorSet(Player player)
		{
			
			player.buffImmune [BuffID.Burning] = true;
			player.lavaImmune = true;
			player.rangedDamage += 0.05f;
			player.meleeDamage += 0.05f;
			player.magicDamage += 0.05f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ObsidianIngot>(), 24);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

	}
}
