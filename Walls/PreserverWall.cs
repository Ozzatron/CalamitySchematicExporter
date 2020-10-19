using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CalamitySchematicExporter.Walls
{
	public class PreserverWall : ModWall
	{
		public override void SetDefaults() {
			Main.wallHouse[Type] = false;
			AddMapEntry(new Color(31, 31, 31));
		}

		public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b) {
			b = g = r = 0.16f;
		}
	}
}