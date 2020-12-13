using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace DamionsWeaponMod.Items.Weapons.Range
{
    public class AntlionBow : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 9;
            item.ranged = true;
            item.width = 22;
            item.height = 40;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            item.rare = 2;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shoot = 1;
            item.shootSpeed = 8f;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.useAmmo = AmmoID.Arrow;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Antlion Bow");
            Tooltip.SetDefault("Shoots a small poisoned thorn and two additional arrow's");
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-2, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 0.6f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			Projectile.NewProjectile(position.X, position.Y, speedX * 1.2f, speedY * 1.4f + 1f, type, damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("Thorn"), damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X, position.Y, speedX * 1.2f, speedY * 1.4f - 1f, type, damage, knockBack, player.whoAmI);
			return false;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SandBlock, 25);
            recipe.AddIngredient(ItemID.Cactus, 15);
            recipe.AddIngredient(ItemID.AntlionMandible, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
