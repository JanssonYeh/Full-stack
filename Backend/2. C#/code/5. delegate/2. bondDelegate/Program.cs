//除了一个委托绑定一个方法，我们可以给一个委托添加多个方法(多播委托)

//当调用委托时，会按添加顺序一次性调用所有委托方法，如果摸个方法在调用列表多次出现，则会按照顺序调用多次

/*
 *  场景：当一个新用户注册(username,Email,RegisterTime)后，需要触发以下操作：
 *      1. 发送欢迎邮件(SendWelcomeEmail)
 *      2. 创建用户档案(CreateUserProfile)
 *      3. 通知管理员(NotifyAdministrator)
 *      4. 记录审计日志(WriteToAuditLog)
 */

//1. 定义委托类型
public delegate void UserRegisterHandler(UserRegisterHandlerMdole user);

class UserRegistrationModel
{
    //当一个新用户注册(username,Email,RegisterTime)
    public string Username { get; set; }
    public string Email { get; set; }
    public DateTime RegisterTime { get; set; }
}

public class UserRegistrationService
{
    private UserRegisteredHandler onUserRegistered;

    public UserRegistrationService()
    {
        // 注册多个处理方法
        onUserRegistered += SendWelcomeEmail;
        onUserRegistered += CreateUserProfile;
        onUserRegistered += NotifyAdministrator;
        onUserRegistered += WriteToAuditLog;
    }

    public async Task<IActionResult> Register(UserRegistrationModel model)
    {
        try
        {
            bool registrationSuccess = await ProcessRegistration(model);

            if (registrationSuccess)
            {
                onUserRegistered?.Invoke(model);
                return new OkResult();
            }

            return new BadRequestResult();
        }
        catch (Exception ex)
        {
            return new StatusCodeResult(500);
        }
    }

    private void SendWelcomeEmail(UserRegistrationModel user)
    {
        var emailService = new EmailService();
        emailService.SendEmail(user.Email, "Welcome!", "Welcome to our website!");
    }

    private void CreateUserProfile(UserRegistrationModel user)
    {
        var profileData = new UserProfile
        {
            Username = user.Username,
            CreatedDate = DateTime.Now
        };
        // 保存到数据库
    }

    private void NotifyAdministrator(UserRegistrationModel user)
    {
        var notification = new AdminNotification
        {
            Message = $"New user registered: {user.Username}",
            Time = DateTime.Now
        };
        // 发送通知
    }

    private void WriteToAuditLog(UserRegistrationModel user)
    {
        var logEntry = new AuditLog
        {
            Action = "User Registration",
            Username = user.Username,
            Timestamp = DateTime.Now
        };
        // 保存日志
    }
}

// RegistrationController.cs - 控制器
public class RegistrationController : Controller
{
    private readonly UserRegistrationService _registrationService;

    public RegistrationController(UserRegistrationService registrationService)
    {
        _registrationService = registrationService;
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] UserRegistrationModel model)
    {
        return await _registrationService.Register(model);
    }
}