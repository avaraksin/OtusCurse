using System;
using Otus.Generics.Task.Generics;
using Otus.Generics.Task.Models;

namespace Otus.Generics.Task.Services
{
    /// <summary>
    /// Базрвый логгер
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseLogger<in T> where T : ISession<BaseAccount>
    {
        /// <summary>
        /// Логирует сессию
        /// </summary>
        /// <param name="session"></param>
        void LogSession(T session);
    }

    /// <summary>
    /// Лолигрует сессию базового аккаутнта
    /// </summary>
    public class BaseAccountLogger : IBaseLogger<ISession<BaseAccount>>
    {
        public void LogSession(ISession<BaseAccount> session)
        {
            MyConsole.WriteLine($"I'm BASE logger and this is  '{session}'");
        }
    }

    /// <summary>
    /// Логиурет сессию бизнес аккаунта
    /// </summary>
    public class BigAccountLogger : IBaseLogger<ISession<BigBusinessAccount>>
    {
        public void LogSession(ISession<BigBusinessAccount> session)
        {
            MyConsole.WriteLine($"I'm big business logger and this is '{session}'");
        }
    }
}