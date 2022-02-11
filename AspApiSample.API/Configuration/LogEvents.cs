namespace AspApiSample.API.Configuration
{
    public class LogEvents
    {
        #region Auth
        public const int SignUp = 101;
        public const int SignUpConfirm = 102;
        public const int SignIn = 103;
        public const int ChangePassword = 104;
        public const int ForgotPassword = 105;
        public const int ResetPassword = 106;
        #endregion

        #region Mail
        public const int SendMail = 201;
        #endregion

        public const int GetItem = 1001;
        public const int ListItems = 1002;
        public const int CreateItem = 1003;
        public const int UpdateItem = 1004;
        public const int DeleteItem = 1005;
    }
}
