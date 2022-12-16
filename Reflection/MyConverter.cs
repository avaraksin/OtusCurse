using System.Reflection;

namespace Reflection
{
    /// <summary>
    /// Класс сериализации/десериализации
    /// </summary>
    public static class MyConverter
    {
        /// <summary>
        /// Сериализация объекта
        /// </summary>
        /// <param name="source">Объект сериализации</param>
        /// <returns>Строка - сериализованный объект</returns>
        public static string SerializeObject(object source)
        {
            Type type = source.GetType();
            string retString = string.Empty;
            int i = 0;

            // Выбираем только свойства
            foreach(var t in type.GetProperties())
            {
                // Только типа int
                if (t.PropertyType == typeof(int))
                {
                    if (i > 0)
                    {
                        retString += ";";
                    }
                    retString += t.Name + "=" + (int)t.GetValue(source);
                    i++;
                }
            }

            return retString;
        }

        /// <summary>
        /// Десериализация строки в класс T
        /// </summary>
        /// <typeparam name="T">Класс в который десериализуется строка</typeparam>
        /// <param name="strObject">Сериализованная строка</param>
        /// <returns>Класс T</returns>
        public static T? DeserializeObject<T>(string strObject) where T : class
        {
            T t;
            
            // Пробуем создать экзкмляр класса
            // Класс должен иметь конструктор без параметров
            try
            {
                t = Activator.CreateInstance<T>();
            }
            catch { return null; }

            Type type = t.GetType();

            // Сплитим строку по ;
            List<string> values = strObject.Split(';').ToList();

            // Выбираем все свойства класса
            List<PropertyInfo> properties = type.GetProperties().ToList();

            foreach(string value in values)
            {
                // Сплитим каждый элемент по знаку =
                List<string> parts = value.Split('=').ToList();
                if (parts.Count == 2)
                {
                    // Если в классе есть свойство с нужным именем
                    if (properties.Select(x => x.Name).ToList().Contains(parts[0]))
                    {
                        // и тип свойства int
                        if (type.GetProperty(parts[0]).PropertyType == typeof(int))
                        {
                            type.GetProperty(parts[0]).SetValue(t, int.Parse(parts[1])); 
                        }
                    }
                }
            }

            return t;
        }
    }
}
