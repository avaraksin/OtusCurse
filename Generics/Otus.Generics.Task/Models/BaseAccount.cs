using System;

namespace Otus.Generics.Task.Models
{
    /// <summary>
    /// Базовый аккаунт
    /// </summary>
    public class BaseAccount
    {
        /// <summary>
        /// Логин
        /// </summary>
        /// <value></value>
        public string Login { get; set; }

        /// <summary>
        /// Идентификатор
        /// </summary>
        /// <value></value>
        public int Id { get; set; }

        /// <summary>
        /// Дата создания аккаунта
        /// </summary>
        /// <value></value>
        public DateTime Created { get; set; }

        public override string ToString()
        {
            return $"login={Login}";
        }
    }
}