namespace Common.Constants.DataBase;

public static class ColumnNames
{
    #region CommonColumns

    public const string NAME = "name";
    public const string NORMALIZED_NAME = "normalized_name";
    public const string VALUE = "value";
    public const string CONCURRENCY_STAMP = "concurrency_stamp";
    public const string CLAIM_TYPE = "claim_type";
    public const string CLAIM_VALUE = "claim_value";

    #endregion

    #region User

    public const string USER_ID = "user_id";
    public const string USERNAME = "username";
    public const string NORMALIZED_USERNAME = "normalized_username";
    public const string EMAIL = "email";
    public const string NORMALIZED_EMAIL = "normalized_email";
    public const string EMAIL_CONFIRMED = "email_confirmed";
    public const string PASSWORD_HASH = "password_hash";
    public const string SECURITY_STAMP = "security_stamp";
    public const string PHONE_NUMBER = "phone_number";
    public const string PHONE_NUMBER_CONFIRMED = "phone_number_confirmed";
    public const string TWO_FACTOR_ENABLED = "two_factor_enabled";
    public const string LOCKOUT_END = "lockout_end";
    public const string IS_LOCKOUT = "is_lockout";
    public const string ACCESS_FAILED_COUNT = "access_failed_count";
    public const string FIRST_NAME = "first_name";
    public const string LAST_NAME = "last_name";
    public const string MIDDLE_NAME = "middle_name";

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

    #region Store

    public const string STORE_ID = "store_id";

    #endregion

    #region Product

    public const string PRODUCT_ID = "product_id";
    public const string PRICE = "price";

    #endregion
    
    #region Property

    public const string PROPERTY_ID = "property_id";

    #endregion

    #region Option

    public const string OPTION_ID = "option_id";
    public const string COUNT = "count";
    public const string PRICE_INCREASE = "price_increase";

    #endregion
    
}