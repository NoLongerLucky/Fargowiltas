using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons
{
	public class PillarSummon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pillar Summon");
			Tooltip.SetDefault("Summons the Celestial Pillars");
		}
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 20;
			item.value = 1000;
			item.rare = 1;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = 4;
			item.consumable = true;
		}
        public override string Texture
        {
            get
            {
                return "Fargowiltas/Items/Placeholder";
            }
        }

        public override bool UseItem(Player player)
		{
            int[] pillars = new int[] { NPCID.LunarTowerNebula, NPCID.LunarTowerSolar, NPCID.LunarTowerStardust, NPCID.LunarTowerVortex };
             
            for(int i = 0; i < pillars.Length; i++)
            {
                NPC.NewNPC((int)player.position.X + (400 * i) - 600, (int)player.position.Y - 200, pillars[i]);
            }
			
			Main.NewText("The Celestial Pillars have awoken!", 175, 75, 255);
			
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			return true;

            //make not spawn moonlord?
		}
	}
}