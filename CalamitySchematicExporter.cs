using CalamityMod.Schematics;
using CalamitySchematicExporter.Tiles;
using CalamitySchematicExporter.Walls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace CalamitySchematicExporter
{
	public class CalamitySchematicExporter : Mod
	{
		private const float Epsilon = 5E-6f;
		private const float OutOfSelectionDimFactor = 0.06f;
		private static readonly Color BaseGridColor = new Color(0.24f, 0.8f, 0.9f, 0.5f);
		private static readonly Rectangle TexUpperHalfRect = new Rectangle(0, 0, 18, 18);

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

		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers) =>
			layers.Insert(0, new LegacyGameInterfaceLayer("Schematic Selection Grid", RenderSchematicSelectionGrid));

		private static bool RenderSchematicSelectionGrid()
		{
			Texture2D gridSquareTex = Main.extraTexture[68];
			Rectangle? rectNull = Main.LocalPlayer.GetModPlayer<CalamitySchematicPlayer>().SchematicArea;
			if (!rectNull.HasValue)
				return true;
			Rectangle selection = rectNull.Value;
			
			Vector2 topLeftScreenTile = (Main.screenPosition / 16f).Floor();
			for (int i = 0; i <= Main.screenWidth; i += 16)
			{
				for (int j = 0; j <= Main.screenHeight; j += 16)
				{
					Vector2 offset = new Vector2(i >> 4, j >> 4);
					Vector2 gridTilePos = topLeftScreenTile + offset;
					Point gridTilePoint = new Point((int)(gridTilePos.X + Epsilon), (int)(gridTilePos.Y + Epsilon));
					bool inSelection = selection.Contains(gridTilePoint);
					Color gridColor = BaseGridColor * (inSelection ? 1f : OutOfSelectionDimFactor);
					Main.spriteBatch.Draw(gridSquareTex, gridTilePos * 16f - Main.screenPosition, TexUpperHalfRect, gridColor, 0f, Vector2.Zero, 1f, 0, 0f);
				}
			}
			return true;
		}
	}
}
