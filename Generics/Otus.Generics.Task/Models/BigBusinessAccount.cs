using System;

namespace Otus.Generics.Task.Models
{
    /// <summary>
    /// Бизнес-аккаунт
    /// </summary>
    public class BigBusinessAccount : BaseAccount, IBaseBusinessAccount
    {
        public BigBusinessAccount(
            string companyName,
             string inn)
        {
            CompanyName = companyName;
            Inn = inn;
        }
        /// <summary>
        /// Название компании
        /// </summary>
        /// <value></value>
        public string CompanyName { get; set; }

        /// <summary>
        /// ИНН
        /// </summary>
        /// <value></value>
        public string Inn { get; set; }

        public string GetPrintName()
        => $"\"{CompanyName}\" [ИНН - {Inn}]";

        public override string ToString()
        {
            return $"big company login={Login}";
        }

        public void UpdateFromUserAccount(UserAccount ua)
        {
            
        }
    }
}