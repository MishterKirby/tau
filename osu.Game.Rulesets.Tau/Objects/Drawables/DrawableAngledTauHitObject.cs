﻿using System;
using JetBrains.Annotations;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Game.Rulesets.Judgements;
using osu.Game.Rulesets.Tau.Judgements;

namespace osu.Game.Rulesets.Tau.Objects.Drawables
{
    public abstract class DrawableAngledTauHitObject<T> : DrawableTauHitObject<T>
        where T : AngledTauHitObject
    {
        /// <summary>
        /// Check to see whether or not this Hit object is in the paddle's range.
        /// Also returns the amount of difference from the center of the paddle this Hit object was validated at.
        /// </summary>
        [CanBeNull]
        public Func<float, ValidationResult> CheckValidation;

        protected DrawableAngledTauHitObject(T obj)
            : base(obj)
        {
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            angleBindable.BindValueChanged(r => Rotation = r.NewValue);
        }

        private readonly BindableFloat angleBindable = new();

        protected override void OnApply()
        {
            base.OnApply();
            angleBindable.BindTo(HitObject.AngleBindable);
        }

        protected override void OnFree()
        {
            base.OnFree();
            angleBindable.UnbindFrom(HitObject.AngleBindable);
        }

        protected override bool CheckForValidation() => IsWithinPaddle();

        public bool IsWithinPaddle() => CheckValidation != null && CheckValidation((HitObject.Angle + GetCurrentOffset()).Normalize()).IsValid;

        protected override void ApplyCustomResult(JudgementResult result)
        {
            if (CheckValidation == null)
                return;

            var delta = CheckValidation(HitObject.Angle + GetCurrentOffset()).DeltaFromPaddleCenter;
            var beatResult = (TauJudgementResult)result;

            if (result.IsHit)
                beatResult.DeltaAngle = delta;
        }

        protected virtual float GetCurrentOffset() => 0f;
    }
}
