using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySchematicExporter.Items.Placeables
{
	public class PreserverTileItem : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Schematic Preserver Tile");
			Tooltip.SetDefault("Not consumable\n" + "Used in schematics\n" + "Schematics will not override existing tiles to place this tile");
		}

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
