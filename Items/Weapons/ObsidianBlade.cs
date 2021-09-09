using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;



namespace ObsidianGear.Items.Weapons
{
	public class ObsidianBlade : ModItem
	{
		

		public override void SetDefaults()
		{
			item.damage = 35; // The damage your item deals
			item.melee = true; // Whether your item is part of the melee class
			item.width = 40; // The item texture's width
			item.height = 40; // The item texture's height
			item.useTime = 35; // The time span of using the weapon. Remember in terraria, 60 frames is a second.
			item.useAnimation = 35; // The time span of the using animation of the weapon, suggest setting it the same as useTime.
			item.knockBack = 5.5f; // The force of knockback of the weapon. Maximum is 20
			item.value = Item.sellPrice(silver: 54); // The value of the weapon in copper coins
			item.rare = ItemRarityID.Green; // The rarity of the weapon, from -1 to 13. You can also use ItemRarityID.TheColorRarity
			item.UseSound = SoundID.Item1; // The sound when the weapon is being used
			item.autoReuse = false; // Whether the weapon can be used more than once automatically by holding the use button
			item.crit = 4; // The critical strike chance the weapon has. The player, by default, has 4 critical strike chance

			//The useStyle of the item. 
			//Use useStyle 1 for normal swinging or for throwing
			//use useStyle 2 for an item that drinks such as a potion,
			//use useStyle 3 to make the sword act like a shortsword
			//use useStyle 4 for use like a life crystal,
			//and use useStyle 5 for staffs or guns
			item.useStyle = ItemUseStyleID.SwingThrow; // 1 is the useStyle
		}

		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("It keeps cool in the heat of battle.");
		}

		//how to offset a melee weapon? figure this out.

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ObsidianIngot>(), 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		// Star Wrath/Starfury style weapon. Spawn projectiles from sky that aim towards mouse.
		// See Source code for Star Wrath projectile to see how it passes through tiles.
		/*	The following changes to SetDefaults 
		 	item.shoot = 503;
			item.shootSpeed = 8f;
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 target = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
			float ceilingLimit = target.Y;
			if (ceilingLimit > player.Center.Y - 200f)
			{
				ceilingLimit = player.Center.Y - 200f;
			}
			for (int i = 0; i < 3; i++)
			{
				position = player.Center + new Vector2((-(float)Main.rand.Next(0, 401) * player.direction), -600f);
				position.Y -= (100 * i);
				Vector2 heading = target - position;
				if (heading.Y < 0f)
				{
					heading.Y *= -1f;
				}
				if (heading.Y < 20f)
				{
					heading.Y = 20f;
				}
				heading.Normalize();
				heading *= new Vector2(speedX, speedY).Length();
				speedX = heading.X;
				speedY = heading.Y + Main.rand.Next(-40, 41) * 0.02f;
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage * 2, knockBack, player.whoAmI, 0f, ceilingLimit);
			}
			return false;
		}*/
	}
}

