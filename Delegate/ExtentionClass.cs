namespace Delegate
{
    /// <summary>
    /// Статический класс - контейнер
    /// </summary>
    public static class ExtentionClass
    {
        /// <summary>
        /// Метод - расширение интерфейса IEnumerable
        /// </summary>
        /// <typeparam name="T">Объект</typeparam>
        /// <param name="e">Коллекция объектов</param>
        /// <param name="getParameter">
        /// Делегат типа Func<in T, out float>, возвращающий число float для объета T
        /// </param>
        /// <returns>Возвращаем объект T, имеющий максимальный GetParameter(T)</returns>
        public static T? GetMax<T>(this IEnumerable<T>? e, Func<T, float>? getParameter) 
        {
            // Упорядочиваем по убыванию чисел, возвращенных GetParameter() 
            // коллецию объектов T и берем первый элемент
            return e != null && getParameter != null ? 
                e.OrderByDescending(x => getParameter(x)).FirstOrDefault() 
                : default(T);
        }
    }
}
