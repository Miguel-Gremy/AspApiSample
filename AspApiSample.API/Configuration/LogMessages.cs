namespace AspApiSample.API.Configuration
{
    public static class LogMessages
    {
        #region Auth
        public static string SignUp => "Create account for {email}";
        public static string SignUpConfirm => "Confirm the creation of account {email}";
        public static string SignIn => "Sign in for account {email}";
        public static string ChangePassword => "Change password for {email}";
        public static string ForgotPassword => "Forgot password for {email}";
        public static string ResetPassword => "Reset password for account {email}";
        #endregion

        #region Mail
        public static string SendMail => "Send email to {email}";
        #endregion

        public static string GetItem => "Get items from {table} : {data}";
        public static string ListItems => "List items from {table}";
        public static string CreateItem => "Create item for {table} : {data}";
        public static string UpdateItem => "Update item for {table} : {data}";
        public static string DeleteItem => "Delete item for {table} : {data}";

    }
}
