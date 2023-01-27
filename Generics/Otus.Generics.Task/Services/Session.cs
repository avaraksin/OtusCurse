using System;
using Otus.Generics.Task.Models;

namespace Otus.Generics.Task.Generics
{
    /// <summary>
    /// Базовый интерфейс сессии
    /// </summary>
    /// <typeparam name="TAccount">Тип аккаунта</typeparam>
    public interface ISession<out TAccount> where TAccount : BaseAccount
    {
        /// <summary>
        /// Дата создания сессии
        /// </summary>
        /// <value></value>
        DateTime Created { set; get; }

        /// <summary>
        /// ВОзвращает текуший аккаунт
        /// </summary>
        /// <returns></returns>
        TAccount GetAccount();
    }


    /// <summary>
    /// Класс сессии
    /// </summary>
    /// <typeparam name="TAccount"></typeparam>
    public class Session<TAccount> : ISession<TAccount>
    where TAccount : BaseAccount
    {


        public Session(TAccount acc)
        {
            Account = acc;

        }

        public TAccount Account { set; private get; }

        public override string ToString()
        {
            return $"Session of type {typeof(TAccount)} Account is {Account}";
        }



        public DateTime Created { set; get; }

        public TAccount GetAccount() => Account;
    }
}