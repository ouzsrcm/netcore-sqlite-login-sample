using System.ComponentModel.DataAnnotations.Schema;

namespace users.Models.DatabaseEntities;

public class UserLoginLog : DefaultEntity
{
    public Guid UserId { get; set; }

    public string UserName { get; set; }
    public string ClientIp { get; set; }
    public DateTime ProccessDate { get; set; }

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }

}