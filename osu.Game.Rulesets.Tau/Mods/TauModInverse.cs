﻿using System;
using osu.Framework.Graphics.Sprites;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Tau.Objects;
using osu.Game.Rulesets.Tau.UI;
using osu.Game.Rulesets.UI;
using osuTK;

namespace osu.Game.Rulesets.Tau.Mods
{
    public class TauModInverse : Mod, IApplicableToDrawableRuleset<TauHitObject>
    {
        public override string Name => "Inverse";
        public override string Acronym => "IN";
        public override ModType Type => ModType.Fun;
        public override IconUsage? Icon => TauIcons.ModInverse;
        public override string Description => @"Beats will appear outside of the playfield.";
        public override double ScoreMultiplier => 1.09;
        public override Type[] IncompatibleMods => new[] { typeof(TauModHidden) };

        public void ApplyToDrawableRuleset(DrawableRuleset<TauHitObject> drawableRuleset)
        {
            var ruleset = (TauDrawableRuleset)drawableRuleset;
            var properties = ruleset.CachedProperties;

            properties.InverseModEnabled.Value = true;

            var playfield = ruleset.Playfield;
            playfield.Scale = new Vector2(0.75f);
        }
    }
}
