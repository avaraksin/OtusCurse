
namespace Clonable
{
    /// <summary>
    /// Перевозка по морю
    /// </summary>
    public class ShipRoute : Route, IMyCloneable<ShipRoute>, ICloneable
    {
        /// <summary>
        /// Порт прихода
        /// </summary>
        public string? Port => Destination;
        
        /// <summary>
        /// Имя судна
        /// </summary>
        public string? ShipName { get; set; }

        public ShipRoute(string lot, DateTime etd, DateTime eta) : base(lot, etd, eta)
        {
        }


        public override ShipRoute MyClone()
        {
            return new ShipRoute(Lot, ETD, ETA)
            {
                Destination = Destination,
                Source = Source,
                ShipName = ShipName
            };
        }

        public override object Clone()
        {
            return MyClone();
        }
    }
}
