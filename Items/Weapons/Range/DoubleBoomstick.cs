using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace DamionsWeaponMod.Items.Weapons.Range
{
	public class DoubleBoomstick : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 11;
			item.ranged = true;
			item.width = 54;
			item.height = 20;
			item.useTime = 4;
			item.useAnimation = 8;
			item.shoot = 3;
			item.useStyle = 5;
			item.reuseDelay = 44;
			item.noMelee = true;
			item.knockBack = 2;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.rare = 3;
			item.UseSound = SoundID.Item36;
			item.autoReuse = true;
			item.useAmmo = AmmoID.Bullet;
			item.shootSpeed = 16f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Double Boomstick");
			Tooltip.SetDefault("U didn't like bee's?");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Boomstick, 1);
			recipe.AddIngredient(ItemID.IronBar, 15);
			recipe.AddIngredient(ItemID.IllegalGunParts, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 3; Main.rand.Next(2); // 4 or 5 shots
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10)); // 30 degree spread.
																												// If you want to randomize the speed to stagger the projectiles
																												// float scale = 1f - (Main.rand.NextFloat() * .3f);
																												// perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false; // return false because we don't want tmodloader to shoot projectile
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-1, 0);

		}
	}
}