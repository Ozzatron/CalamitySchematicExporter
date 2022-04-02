using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CalamitySchematicExporter.Tiles
{
	public class PreserverTile : ModTile
	{
		public override void SetStaticDefaults() {
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = false;
			Main.tileBlockLight[Type] = false;
			Main.tileLighted[Type] = true;
			Main.tileWaterDeath[Type] = false;
			Main.tileLavaDeath[Type] = false;
			Main.tileNoAttach[Type] = false;
			AddMapEntry(new Color(31, 31, 31));
		}

		public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b) {
			b = g = r = 0.16f;
		}
	}
}