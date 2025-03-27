namespace Pbk.Core.Features.Auth.Login;

public sealed record LoginCommandResponse(
         string token,
        LoginCommandResponseData data,
        string status,
        string messages
        );

public class LoginCommandResponseData
{
    public string _id { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    public string password { get; set; }
    public string role { get; set; }
    public string confirm_password { get; set; }
    public DateTime changePasswordAt { get; set; }
    public List<string> skills { get; set; }
    public int __v { get; set; }
    public string Description { get; set; }
    public string city { get; set; }
    public string country { get; set; }
    public string designation { get; set; }
    public object joining_date { get; set; }
    public string website { get; set; }
    public string zipcode { get; set; }
    public string passwordtoken { get; set; }
    public DateTime passwordtokenexp { get; set; }
    public object[] exp_year { get; set; }
    public object[] portfolio { get; set; }
    public int? RoleId { get; set; }
    public bool isForeign { get; set; }
    public string? departman { get; set; }  
    public int? departmentId { get; set; }
    public string? userBarsisCode { get; set; }
}
