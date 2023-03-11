namespace Clonable
{
    /// <summary>
    /// Международные перевозки.
    /// Содержат перевозку по морю (международная часть)
    /// и перевозка по железной дороге (внутренняя часть)
    /// </summary>
    public class InterRoute : Route, IMyCloneable<InterRoute>, ICloneable
    {
        /// <summary>
        /// Перевозка по морю
        /// </summary>
        public ShipRoute? Ship { get; set; }

        /// <summary>
        /// Перевозка по ЖД
        /// </summary>
        public RWRoute? RWRoute { get; set; }

        public InterRoute(string lot, DateTime etd, DateTime eta) : base(lot, etd, eta)
        {
        }

        public InterRoute(string lot, DateTime etd, DateTime eta, ShipRoute ship, RWRoute rW) : base(lot, etd, eta)
        {
            Ship = ship;
            RWRoute = rW;
        }

        public override InterRoute MyClone()
        {
            InterRoute interRoute = new InterRoute(Lot, ETD, ETA);
            interRoute.Destination = Destination;
            interRoute.Source = Source;
            interRoute.RWRoute = RWRoute?.MyClone();
            interRoute.Ship= Ship?.MyClone();
            return interRoute;
        }

        public override object Clone()
        {
            return MyClone();
        }
    }
}
