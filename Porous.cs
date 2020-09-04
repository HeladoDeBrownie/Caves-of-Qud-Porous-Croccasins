namespace XRL.World.Parts
{
    [System.Serializable]
    public class helado_PorousCroccasins_Porous : IPart
    {
        public const string POROUS_DESCRIPTION = "Like their namesake, they are scaly and temperamental; unlike their namesake, they are porous and worn on one's feet.";
        public int Chance = 10;

        public override bool WantEvent(int id, int cascade)
        {
            return
                id == GetDisplayNameEvent.ID ||
                id == GetShortDescriptionEvent.ID ||
                id == ObjectCreatedEvent.ID ||
                base.WantEvent(id, cascade);
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
            if (!Chance.in100())
            {
                ParentObject.RemovePart(this);
            }

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
