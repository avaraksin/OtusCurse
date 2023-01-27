using System;

namespace Otus.Generics.Task.Models
{
    /// <summary>
    /// Аккаунт пользователя - человека
    /// </summary>
    public class UserAccount : BaseAccount
    {
        /// <summary>
        /// Имя
        /// </summary>
        /// <value></value>
        public string Firstname { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        /// <value></value>
        public string Lastname { get; set; }

        public override string ToString()
        {
            return $"user login={Login}";
        }
    }
}