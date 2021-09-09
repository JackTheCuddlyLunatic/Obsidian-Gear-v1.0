using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ObsidianGear.Items.Tools
{
	public class ObsidianPickaxe : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Able to mine hellstone wihtout feeling gross.");
		}

		public override void SetDefaults() {
			item.damage = 14;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 22;
			item.useAnimation = 22;
			item.pick = 75;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 3.5f;
			Item.sellPrice(silver: 46);

            item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.crit = 4;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ObsidianIngot>(), 16);
			recipe.AddIngredient(ItemID.Wood, 2);
			recipe.anyWood = true;
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		
		}
	}
