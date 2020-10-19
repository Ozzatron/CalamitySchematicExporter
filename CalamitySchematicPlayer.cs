using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using CalamityMod.Schematics;

namespace CalamitySchematicExporter
{
	// This class simply holds a Rectangle for keeping track of the schematic's area.
	public class CalamitySchematicPlayer : ModPlayer
	{
		internal Point? CornerOne = null;
		internal Point? CornerTwo = null;

		// Property with a getter that dynamically assembles the corners to produce a meaningful Rectangle.
		internal Rectangle? SchematicArea
		{
			get
			{
				if (!CornerOne.HasValue || !CornerTwo.HasValue)
					return null;
				Point c1 = CornerOne.GetValueOrDefault();
				Point c2 = CornerTwo.GetValueOrDefault();
				
				// It is possible the player dragged the corners in any direction, so use Abs and Min to find the true upper left corner.
				int startingX = Math.Min(c1.X, c2.X);
				int width = Math.Abs(c1.X - c2.X);
				int startingY = Math.Min(c1.Y, c2.Y);
				int height = Math.Abs(c1.Y - c2.Y);
				return new Rectangle(startingX, startingY, width, height);
			}
		}

		internal bool AttemptExportSchematic()
		{
			CalamitySchematicPlayer csp = null;
			if (player != null && player.active)
				csp = player.GetModPlayer<CalamitySchematicPlayer>();
			if (csp is null)
				return false;
			Rectangle? rectNull = csp.SchematicArea;
			if (!rectNull.HasValue)
				return false;
			Rectangle area = rectNull.Value;

			ExportResult result;
			try
			{
				result = CalamitySchematicIO.ExportSchematic(area);
				PrintResultMessage(result);
			} catch
			{
				Main.NewText("An unknown error occured during schematic export. Check your log file.", Color.MediumVioletRed);
				throw;
			}
			finally
			{
				// Regardless of whether the export succeeded, the player's corner data needs to be erased.
				csp.CornerOne = csp.CornerTwo = null;
			}

			return result == ExportResult.Success;
		}

		// Print a message to console depending on the result of the export operation.
		private void PrintResultMessage(ExportResult result)
		{
			string message;
			bool goodResponse = false;
			switch (result)
			{
				case ExportResult.Success:
					message = "Schematic exported. Check your Terraria save folder.";
					goodResponse = true;
					break;
				case ExportResult.CornerOutOfWorld:
					message = "One or more corners of the area is outside the game world.";
					break;
				case ExportResult.ZeroArea:
					message = "Provided rectangle has zero area. No data to export.";
					break;
				default:
					message = "Undefined export status. This is almost certainly bad.";
					break;
			}
			Color messageColor = goodResponse ? Color.White : Color.MediumVioletRed;
			Main.NewText(message, messageColor);
		}
	}
}
