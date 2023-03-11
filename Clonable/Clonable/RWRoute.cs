namespace Clonable
{
    /// <summary>
    /// Перевозка по железной дороге
    /// </summary>
    public class RWRoute : Route, IMyCloneable<RWRoute>, ICloneable
    {
        /// <summary>
        /// Склад прихода
        /// </summary>
        public string? Waterhouse => Destination;
        
        
        /// <summary>
        /// Платформа погрузки
        /// </summary>
        public string? Platform { get; set; }

        public RWRoute(string lot, DateTime etd, DateTime eta) : base(lot, etd, eta)
        {
        }

        public override RWRoute MyClone()
        {
            RWRoute rWRoute = (RWRoute) base.MyClone();
            rWRoute.Platform = Platform;
            return rWRoute;
        }

        public override object Clone()
        {
            return MyClone();
        }
    }
}
