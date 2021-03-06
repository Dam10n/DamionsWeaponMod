using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace DamionsWeaponMod.Items.Weapons.Melee
{
    public class Winterblight : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Releases a ice shard that pierces enemies"); //The (English) text shown below your weapon's name
        }

        public override void SetDefaults()
        {
            item.damage = 16;  //e of your weapon
            item.crit = 17;
            item.melee = true;   //Is your weapon a melee weapon?
            item.width = 44;   //Weapon's texture's width
            item.height = 68;   //Weapon's texture's height
            item.useTime = 25;   //The time span of using the weapon. Remember in terraria, 60 frames is a second.
            item.useAnimation = 25;   //The time span of the using animation of the weapon, suggest set it the same as useTime.
            item.useStyle = 1;   //The use style of weapon, 1 for swinging, 2 for drinking, 3 act like shortsword, 4 for use like life crystal, 5 for use staffs or guns
            item.knockBack = 6;   //The force of knockback of the weapon. Maximum is 20
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 2; //The rarity of the weapon, from -1 to 13
            item.UseSound = SoundID.Item1;  //The sound when the weapon is using
            item.autoReuse = true;   //Whether the weapon can use automatically by pressing mousebutton
            item.shoot = mod.ProjectileType("WinterblightP");
            item.shootSpeed = 8f;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(2, 2);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IceBlade, 1);
            recipe.AddIngredient(ItemID.CrimtaneBar, 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}