using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    /// <summary>
    /// ����� ������� �������������
    /// ������� Clients  � ��
    /// </summary>
    public class User : UserBase
    {        
        public string? firstName { get; init; }
    }
}