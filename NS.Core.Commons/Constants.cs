namespace NS.Core.Commons
{
    public class Constants
    {
        public class AppSettingKeys
        {
            public const string DEFAULT_CONTROLLER_ROUTE = "api/[controller]";
            public const string DEFAULT_CONNECTION = "DefaultConnection";
            public const string AUTH_SECRET = "AuthSecret";
        }

        public class ExceptionMessage
        {
            public const string NOT_FOUND = "{0} not found.";
            public const string ITEM_NOT_FOUND = "Item not found.";
            public const string ALREADY_EXIST = "{0} already exist.";
            public const string SUCCESS = "{0} success.";
            public const string SHOULD_GREATER_TODAY = "{0} Date is late.";
            public const string INVALID = "{0} invalid.";
            public const string EMAIL_NOT_ACTIVATED = "Email not activated";
            public const string FILE_NOT_FOUND = "File {0} not found";
            public const string EXPIRATION_TIME = "Expiration time";
            public const string VERIFIED = "Account has been verified";
        }

        public class ContextItem
        {
            public const string USER = "User";
            public const string PERMISSIONS = "Permissions";
        }
        public class MailMessage
        { 
            public const string LINK_VERIFY_EMAIL  = @"<p><a href=""{0}/xac-thuc-tai-khoan?key={1}"">{0}/xac-thuc-tai-khoan?key={1}</a></p>";
            public const string LINK_FORGOT_PASSWORD = @"<p><a href=""{0}/dat-lai-mat-khau?key={1}"">{0}/dat-lai-mat-khau?key={1}</a></p>";
            public const string TICK_LINK = "{0}";
            public const string TIEU_DE_MAIL_YEU_CAU_LIEN_HE = "[{0}] Yêu cầu liên hệ đến bộ phận {1}";
            public const string NOI_DUNG_MAIL_YEU_CAU_LIEN_HE = "<h2> Bộ phận {0} nhận yêu cầu liên hệ với nội dung như sau: </h2><p> ID: {1} </p><p> Họ tên: {2} </p> <p>Số điện thoại: {3} </p><p> Email: {4} </p><p> Nội dung: </p><blockquote><p> {5} </p> </blockquote>";
        }

        public class DefaultValue
        {
            public const int DEFAULT_PAGE_SIZE_VIDEO = 9;
            public const int DEFAULT_PAGE_SIZE = 10;
            public const int DEFAULT_PAGE_NO = 1;
            public const string DEFAULT_CONTROLLER_ROUTE = "api/[controller]/[action]";
            public const string DEFAULT_CONTROLLER_ROUTE_WITHOUT_ACTION = "api/[controller]";
            public const string DEFAULT_ACTION_ROUTE = "[action]";
        }
        public class FileConstans
        {
            public const string STORED_FILES_PATH = "StoredFilesPath";
            public const string NAM_UPLOAD = "Năm {0}";
            public const string IMAGE_URL = "{0}api/file/GetImages/{1}";
        }

        public class SQLRaw
        {
            public const string SET_IDENTITY_INSERT_ON = "SET IDENTITY_INSERT dbo.{0} ON";
            public const string SET_IDENTITY_INSERT_OFF = "SET IDENTITY_INSERT dbo.{0} OFF";
        }
        public class EmailConstants
        {
            public const string SEND_VERIFICATION_EMAIL = "IsNeedConfirmEmail";
            public const string SERVE_HOST = "serveHost";
            public const int EMAIL_VERIFICATION_EXPIRATION_DAYS = 30;
            public const int FORGOT_PASSWORD_EXPIRATION_DATE_NUMBER = 1;
            public const string REQUEST_HEADER_KEY_ORIGIN = "Origin";
        }

    }
}
