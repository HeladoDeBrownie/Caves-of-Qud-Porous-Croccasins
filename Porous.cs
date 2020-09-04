using System;

namespace XRL.World.Parts
{
    [Serializable]
    public class helado_PorousCroccasins_Porous : IPart
    {
        public const string POROUS_TILE = "helado_croccasins-porous.png";
        public const string POROUS_DESCRIPTION = "Like their namesake, they are scaly and temperamental; unlike their namesake, they are porous and worn on one's feet.";
        public static Random RandomSource = null;
        public int Chance = 100;

        public helado_PorousCroccasins_Porous()
        {
            if (RandomSource == null)
            {
                RandomSource = XRL.Rules.Stat.GetSeededRandomGenerator(
                    Seed: "helado_PorousCroccasins"
                );
            }
        }

        public override bool WantEvent(int id, int _)
        {
            return
                id == GetDisplayNameEvent.ID ||
                id == GetShortDescriptionEvent.ID ||
                id == ObjectCreatedEvent.ID ||
                base.WantEvent(id, _);
        }

        public override bool HandleEvent(GetDisplayNameEvent @event)
        {
            @event.AddAdjective("{{g-K sequence|porous}}");
            return true;
        }

        public override bool HandleEvent(GetShortDescriptionEvent @event)
        {
            @event.Base.Clear().Append(POROUS_DESCRIPTION);
            return true;
        }

        public override bool HandleEvent(ObjectCreatedEvent @event)
        {
            if (!Chance.in100(RandomSource))
            {
                ParentObject.RemovePart(this);
            }

            return true;
        }

        public override bool Render(RenderEvent @event)
        {
            @event.Tile = POROUS_TILE;
            return true;
        }

        public override bool SameAs(IPart part)
        {
            return
                Chance == (part as helado_PorousCroccasins_Porous).Chance &&
                base.SameAs(part);
        }
    }
}
