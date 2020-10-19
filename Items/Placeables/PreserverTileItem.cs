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
			item.width = 12;
			item.height = 12;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 4;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.createTile = ModContent.TileType<Tiles.PreserverTile>();
		}
	}
}
