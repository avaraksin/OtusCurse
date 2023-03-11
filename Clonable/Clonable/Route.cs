
namespace Clonable
{
    /// <summary>
    /// Маршрут. Родительский класс для всех маршрутов
    /// </summary>
    public class Route : IMyCloneable<Route>, ICloneable
    {
        public Guid Id { get; }

        /// <summary>
        /// Имя лота
        /// </summary>
        public string Lot { get; set; }

        /// <summary>
        /// Дата отправления
        /// </summary>
        public DateTime ETD { get; set; }

        /// <summary>
        /// Дата прибытия
        /// </summary>
        public DateTime ETA { get; set; }

        /// <summary>
        /// Пункт назначения
        /// </summary>
        public string? Destination { get; set; }

        /// <summary>
        /// Пункт отправки
        /// </summary>
        public string? Source { get; set; }
        
        public Route(string lot, DateTime etd, DateTime eta) 
        {
            Id = Guid.NewGuid();
            Lot = lot;
            ETD = etd;
            ETA = eta;
        }

        /// <summary>
        /// Реализуем интерфейс IMyCloneable
        /// </summary>
        /// <returns></returns>
        public virtual Route MyClone()
        {
            return (Route) this.MemberwiseClone();
        }

        /// <summary>
        /// Реализуем интерфейс ICloneable
        /// </summary>
        /// <returns></returns>
        public virtual object Clone()
        {
            return (Route) this.MemberwiseClone();
        }
    }
}
