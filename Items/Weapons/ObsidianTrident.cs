using Microsoft.Xna.Framework;
using ObsidianGear.Items.Projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ObsidianGear.Items.Weapons
{
	class ObsidianTrident : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Reheated Trident");//Sets item name
			Tooltip.SetDefault("A Trident forgotten by time,\nits power partially restored from the heat of the forge");//Sets tooltip when hovering in inventory
		}
		public override void SetDefaults()
		{
			item.damage = 24;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 24;
			item.useTime = 24;
			item.shootSpeed = 2f;
			item.knockBack = 4.5f;
			item.width = 32;
			item.height = 32;
			item.scale = 1f;
			item.rare = ItemRarityID.Orange;
			item.value = Item.sellPrice(silver: 70);

			item.melee = true;
			item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
			item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
			item.autoReuse = false; // Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()

			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<ObsidianTridentProjectile>();
		}

		public override bool CanUseItem(Player player)
		{
			// Ensures no more than one spear can be thrown out, use this when using autoReuse
			return player.ownedProjectileCounts[item.shoot] < 1;
		}

		public override bool AltFunctionUse(Terraria.Player player)//You use this to allow the item to be right clicked
		{
			return true;
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 5 * 60);
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-15, 0);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Trident, 1);
			recipe.AddIngredient(ModContent.GetInstance<ObsidianIngot>(), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

		
