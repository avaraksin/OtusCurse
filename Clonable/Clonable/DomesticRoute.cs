
namespace Clonable
{
    /// <summary>
    /// Внутренняя перевозка
    /// Не содержит морской части
    /// </summary>
    public class DomesticRoute : InterRoute, IMyCloneable<DomesticRoute>, ICloneable
    {
        public new ShipRoute? Ship => null;
        public DomesticRoute(string lot, DateTime etd, DateTime eta) : base(lot, etd, eta)
        {
        }

        public DomesticRoute(string lot, DateTime etd, DateTime eta, ShipRoute ship, RWRoute rW) : base(lot, etd, eta, ship, rW)
        {
        }

        public override DomesticRoute MyClone()
        {
            DomesticRoute domesticRoute = new (Lot, ETD, ETA);
            domesticRoute.RWRoute = RWRoute?.MyClone();
            return domesticRoute;
        }

        public override object Clone()
        {
            return MyClone();
        }

    }
}
