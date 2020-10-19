using Terraria.ModLoader;
using Terraria.ID;

namespace CalamitySchematicExporter.Items.Placeables
{
	public class PreserverWallItem : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Schematic Preserver Wall");
			Tooltip.SetDefault("Not consumable\n" + "Used in schematics\n" + "Schematics will not override existing walls to place this wall");
		}

		public override void SetDefaults() {
			item.width = 12;
			item.height = 12;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 4;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.createWall = ModContent.WallType<Walls.PreserverWall>();
		}
	}
}