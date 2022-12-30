namespace Otus.Generics.Task.Models
{
    /// <summary>
    /// Аккаунт - ИП
    /// </summary>
    public class PrivateBussinessAccount : UserAccount, IBaseBusinessAccount
    {

        public string GetPrintName()
        {
            return $"ИП \"{Firstname} {Lastname} \"";
        }

        public override string ToString()
        {
            return $"private business login={Login}";
        }

        public void UpdateFromUserAccount(UserAccount ua)
        {
            Firstname = ua.Firstname;
            Lastname = ua.Lastname;
        }
    }
}