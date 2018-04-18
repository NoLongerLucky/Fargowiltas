using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Weapons
{
	public class PrimeStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Prime Staff");
			Tooltip.SetDefault("'An old foe's limbs reanimated for your desires..'");
		}
		public override void SetDefaults()
		{
			item.damage = 32; 
			item.summon = true;
			item.mana = 10;
			item.width = 26;
			item.height = 28;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 3;
			item.rare = 2; 
			item.UseSound = SoundID.Item44; 
			item.shoot = mod.ProjectileType("PrimeCannon");
			item.shootSpeed = 10f;
			//item.buffType = mod.BuffType("BrainMinion");	//The buff added to player after used the item
			//item.buffTime = 3600;				//The duration of the buff, here is 60 seconds
			item.autoReuse = true;
		}
	}
}
