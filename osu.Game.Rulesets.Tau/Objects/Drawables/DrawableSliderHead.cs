﻿namespace osu.Game.Rulesets.Tau.Objects.Drawables
{
    public class DrawableSliderHead : DrawableBeat
    {
        public DrawableSlider DrawableSlider => (DrawableSlider)ParentHitObject;

        public DrawableSliderHead()
        {
        }

        public DrawableSliderHead(SliderHeadBeat hitObject)
            : base(hitObject)
        {
        }

        protected override float GetCurrentOffset() => DrawableSlider.HitObject.Angle;
    }
}
