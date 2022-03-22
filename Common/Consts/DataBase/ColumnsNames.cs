namespace Common.Consts.DataBase;

public static class ColumnsNames
{
    #region CommonColumns

    public const string NAME = "name";
    public const string NORMALIZED_NAME = "normalized_name";
    public const string VALUE = "value";
    public const string CONCURRENCY_STAMP = "concurrency_stamp";
    public const string CLAIM_TYPE = "claim_type";
    public const string CLAIM_VALUE = "claim_value";

    #endregion

    #region UserAccount

    public const string USER_ACCOUNT_ID = "user_account_id";
    public const string LOGIN = "login";
    public const string NORMALIZED_LOGIN = "normalized_login";
    public const string EMAIL = "email";
    public const string NORMALIZED_EMAIL = "normalized_email";
    public const string PASSWORD_HASH = "password_hash";
    public const string SECURITY_STAMP = "security_stamp";
    public const string PHONE_NUMBER = "phone_number";
    public const string PHONE_NUMBER_CONFIRMED = "phone_number_confirmed";
    public const string IS_LOCKOUT = "is_lockout";
    public const string ACCESS_FAILED_COUNT = "access_failed_count";

    #endregion

    #region UserDetail

    public const string USER_DETAIL_ID = "user_detail_id";
    public const string FIRST_NAME = "first_name";
    public const string LAST_NAME = "last_name";
    public const string MIDDLE_NAME = "middle_name";
    public const string AGE = "age";

    #endregion

    #region Role

    public const string ROLE_ID = "role_id";

    #endregion

    #region Claim

    public const string ROLE_CLAIMS_ID = "role_claims_id";
    public const string USER_CLAIMS_ID = "user_claims_id";

    #endregion

    #region Provider

    public const string PROVIDER_KEY = "provider_key";
    public const string LOGIN_PROVIDER = "login_provider";
    public const string PROVIDER_DISPLAY_NAME = "provider_display_name";

    #endregion



}