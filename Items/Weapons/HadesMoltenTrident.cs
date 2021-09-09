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
	class HadesMoltenTrident : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hades' Molten Trident");//Sets item name
			Tooltip.SetDefault("An ancient trident wielded by Hades, Lord of the Underworld.\nIt was made in a feeble attempt to imitate the glory of his brother, Poseidon.");//Sets tooltip when hovering in inventory
		}
		public override void SetDefaults()
		{
			item.damage = 75;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 24;
			item.useTime = 28;
			item.shootSpeed = 2f;
			item.knockBack = 5.2f;
			item.width = 32;
			item.height = 32;
			item.scale = 1f;
			item.rare = ItemRarityID.Orange;
			item.value = Item.sellPrice(gold: 18);

			item.melee = true;
			item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
			item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
			item.autoReuse = false; // Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()

			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<HadesMoltenTridentProjectile>();
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
			target.AddBuff(BuffID.OnFire, 12 * 60);
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-15, 0);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.GetInstance<ObsidianTrident>(), 1);
			recipe.AddIngredient(ItemID.TitaniumTrident, 1);
			recipe.AddIngredient(ItemID.SoulofMight, 5);
			recipe.AddIngredient(ItemID.SoulofFright, 5);
			recipe.AddIngredient(ItemID.SoulofSight, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();

			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(ModContent.GetInstance<ObsidianTrident>(), 1);
			modRecipe.AddIngredient(ItemID.AdamantiteGlaive, 1);
			modRecipe.AddIngredient(ItemID.SoulofMight, 5);
			modRecipe.AddIngredient(ItemID.SoulofFright, 5);
			modRecipe.AddIngredient(ItemID.SoulofSight, 5);
			modRecipe.AddTile(TileID.MythrilAnvil);
			modRecipe.SetResult(this);
			modRecipe.AddRecipe();

			ModRecipe newRecipe = new ModRecipe(mod);
			newRecipe.AddIngredient(ItemID.ObsidianSwordfish, 1);
			newRecipe.AddIngredient(ItemID.HallowedBar, 5);
			newRecipe.AddIngredient(ItemID.SoulofMight, 5);
			newRecipe.AddIngredient(ItemID.SoulofFright, 5);
			newRecipe.AddIngredient(ItemID.SoulofSight, 5);
			newRecipe.AddTile(TileID.MythrilAnvil);
			modRecipe.SetResult(this);
			modRecipe.AddRecipe();
		}
	}
}
    

