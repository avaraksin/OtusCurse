using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    /// <summary>
    /// Образ таблицы пользователей
    /// Таблица Clients  в БД
    /// </summary>
    public class User : UserBase
    {        
        public string? firstName { get; init; }
    }
}