using Terraria.ModLoader;
using Terraria.ID;

namespace CalamitySchematicExporter.Items.Placeables
{
	public class PreserverWallItem : ModItem
	{
		public override void SetDefaults() {
			Item.width = 12;
			Item.height = 12;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 4;
			Item.tileBoost = 50;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.createWall = ModContent.WallType<Walls.PreserverWall>();
		}
	}
}