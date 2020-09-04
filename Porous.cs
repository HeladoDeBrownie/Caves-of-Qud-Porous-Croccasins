using System;
using static System.String;

namespace XRL.World.Parts
{
    [Serializable]
    public class helado_PorousCroccasins_AlternativeRender : IPart
    {
        public static Random RandomSource = null;
        public string Tile = null;
        public string Adjective = null;
        public string Description = null;
        public int Chance = 100;

        public helado_PorousCroccasins_AlternativeRender()
        {
            if (RandomSource == null)
            {
                RandomSource = XRL.Rules.Stat.GetSeededRandomGenerator(
                    Seed: "helado_PorousCroccasins_AlternativeRender"
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
            if (!IsNullOrEmpty(Adjective))
            {
                @event.AddAdjective(Adjective);
            }

            return true;
        }

        public override bool HandleEvent(GetShortDescriptionEvent @event)
        {
            if (!IsNullOrEmpty(Description))
            {
                @event.Base.Clear().Append(Description);
            }

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
            if (!IsNullOrEmpty(Tile))
            {
                @event.Tile = Tile;
            }

            return true;
        }

        public override bool SameAs(IPart iPart)
        {
            var part = iPart as helado_PorousCroccasins_AlternativeRender;

            return
                Tile == part.Tile &&
                Adjective == part.Adjective &&
                Description == part.Description &&
                Chance == part.Chance &&
                base.SameAs(part);
        }
    }
}
