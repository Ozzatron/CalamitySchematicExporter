using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySchematicExporter.Items.Placeables
{
	public class PreserverTileItem : ModItem
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
			Item.createTile = ModContent.TileType<Tiles.PreserverTile>();
		}
	}
}
