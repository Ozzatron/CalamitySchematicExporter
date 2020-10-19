using CalamityMod.Schematics;
using CalamitySchematicExporter.Projectiles;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamitySchematicExporter.Items
{
	public class SchematicExporterItem : ModItem
	{
		private const string BaseCompressionTooltip = "Right click to toggle compression";
		private static string CompressionStatusString => CalamitySchematicIO.UseCompression ? "enabled" : "disabled";
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Schematic Exporter");
			Tooltip.SetDefault("Hold and drag to select an area to turn into a schematic\n" + "Schematics are written to your Terraria save directory\n" + BaseCompressionTooltip);
		}

		public override void SetDefaults()
		{
			item.width = 38;
			item.height = 26;

			item.useTime = item.useAnimation = 40;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.channel = true;

			item.shoot = ModContent.ProjectileType<SchematicReticle>();
			item.shootSpeed = 0f;

			item.rare = ItemRarityID.Red;
			item.value = 0;

			item.UseSound = SoundID.Item64;
		}

		public override bool AltFunctionUse(Player player) => true;

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			bool rightClick = player.altFunctionUse == ItemAlternativeFunctionID.ActivatedAndUsed;
			if (player.whoAmI == Main.myPlayer && rightClick)
			{
				CalamitySchematicIO.UseCompression = !CalamitySchematicIO.UseCompression;
				Main.PlaySound(SoundID.Item65);
				Main.NewText($"Schematic compression {CompressionStatusString}");
			}
			return !rightClick;
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			TooltipLine compressionTooltip = tooltips.First<TooltipLine>((line) => line.Name == "Tooltip2");
			compressionTooltip.text = $"{BaseCompressionTooltip} (Currently {CompressionStatusString})";
		}
	}
}
