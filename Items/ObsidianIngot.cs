using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;



namespace ObsidianGear.Items
{
	public class ObsidianIngot : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("A bar of pure obsidian.");  //The (English) text shown below your weapon's name
			DisplayName.SetDefault("Obsidian Bar");
		}

		public override void SetDefaults()
		{
			item.width = 15;
			item.height = 15;
			item.maxStack = 999;
			item.rare = ItemRarityID.Green;
			item.value = Item.sellPrice(0, 0, 27, 0);
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Obsidian, 4);
			recipe.AddTile(TileID.Furnaces);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
