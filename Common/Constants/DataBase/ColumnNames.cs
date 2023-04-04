namespace Common.Constants.DataBase;

public static class ColumnNames
{
    #region Common

    public const string NAME = "name";
    public const string NORMALIZED_NAME = "normalized_name";
    public const string VALUE = "value";
    public const string CONCURRENCY_STAMP = "concurrency_stamp";
    public const string CLAIM_TYPE = "claim_type";
    public const string CLAIM_VALUE = "claim_value";
    public const string PRICE = "price";
    public const string QUANTITY = "quantity";
    public const string DATE_TIME_CREATED = "date_time_created";
    public const string DATE_TIME_MODIFIED = "date_time_modified";

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

    #region Catalog
    
    public const string CATEGORY_ID = "category_id";

    #endregion
    
    #region Product

    public const string PRODUCT_ID = "product_id";

    #endregion

    #region SubProduct

    public const string SUB_PRODUCT_ID = "sub_product_id";

    #endregion

    #region AddOn

    public const string ADD_ON_ID = "add_on_id";

    #endregion

    #region Parameter

    public const string PARAMETER_ID = "parameter_id";

    #endregion

    #region ParameterValue

    public const string PARAMETER_VALUE_ID = "parameter_value_id";

    #endregion

    #region SubProductParameterValue

    public const string SUB_PRODUCT_PARAMETER_VALUE_ID = "sub_product_parameter_value";

    #endregion
}