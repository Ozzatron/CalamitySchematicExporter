using CalamityMod.Schematics;
using CalamitySchematicExporter.Tiles;
using CalamitySchematicExporter.Walls;
using Terraria.ModLoader;

namespace CalamitySchematicExporter
{
	public class CalamitySchematicExporter : Mod
	{
		public override void Load()
		{
			CalamitySchematicIO.PreserveTileID = (ushort)ModContent.TileType<PreserverTile>();
			CalamitySchematicIO.PreserveWallID = (ushort)ModContent.WallType<PreserverWall>();
		}

		public override void Unload()
		{
			CalamitySchematicIO.PreserveTileID = 0;
			CalamitySchematicIO.PreserveWallID = 0;
		}
	}
}
