using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ObsidianGear.Items.Weapons
{
	public class ObsidianShot : ModItem
	{
        

        public override void SetDefaults() {
			item.damage = 10;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = 3.5f;
			item.value = Item.sellPrice(0, 0, 0, 5);
			item.rare = ItemRarityID.Blue;
			item.shoot = ProjectileID.Bullet;   //The projectile shoot when your weapon using this ammo
			item.shootSpeed = 5;                  //The speed of the projectile
			item.ammo = AmmoID.Bullet;              //The ammo class this ammo belongs to.
		}

        


		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MusketBall, 70);
			recipe.AddIngredient(ModContent.GetInstance<ObsidianIngot>(), 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 70);
			recipe.AddRecipe();
		}
	}
}
