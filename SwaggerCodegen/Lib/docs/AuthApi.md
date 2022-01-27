# IO.Swagger.Api.AuthApi

All URIs are relative to */*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiAuthChangePasswordPut**](AuthApi.md#apiauthchangepasswordput) | **PUT** /api/Auth/ChangePassword | 
[**ApiAuthForgotPasswordPost**](AuthApi.md#apiauthforgotpasswordpost) | **POST** /api/Auth/ForgotPassword | 
[**ApiAuthResetPasswordPost**](AuthApi.md#apiauthresetpasswordpost) | **POST** /api/Auth/ResetPassword | 
[**ApiAuthSignInPost**](AuthApi.md#apiauthsigninpost) | **POST** /api/Auth/SignIn | 
[**ApiAuthSignUpConfirmGet**](AuthApi.md#apiauthsignupconfirmget) | **GET** /api/Auth/SignUpConfirm | 
[**ApiAuthSignUpPost**](AuthApi.md#apiauthsignuppost) | **POST** /api/Auth/SignUp | 

<a name="apiauthchangepasswordput"></a>
# **ApiAuthChangePasswordPut**
> void ApiAuthChangePasswordPut (UserPasswordChangeResource body = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiAuthChangePasswordPutExample
    {
        public void main()
        {
            var apiInstance = new AuthApi();
            var body = new UserPasswordChangeResource(); // UserPasswordChangeResource |  (optional) 

            try
            {
                apiInstance.ApiAuthChangePasswordPut(body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AuthApi.ApiAuthChangePasswordPut: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**UserPasswordChangeResource**](UserPasswordChangeResource.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="apiauthforgotpasswordpost"></a>
# **ApiAuthForgotPasswordPost**
> UserForgotPasswordResponse ApiAuthForgotPasswordPost (UserPasswordForgotResource body = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiAuthForgotPasswordPostExample
    {
        public void main()
        {
            var apiInstance = new AuthApi();
            var body = new UserPasswordForgotResource(); // UserPasswordForgotResource |  (optional) 

            try
            {
                UserForgotPasswordResponse result = apiInstance.ApiAuthForgotPasswordPost(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AuthApi.ApiAuthForgotPasswordPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**UserPasswordForgotResource**](UserPasswordForgotResource.md)|  | [optional] 

### Return type

[**UserForgotPasswordResponse**](UserForgotPasswordResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="apiauthresetpasswordpost"></a>
# **ApiAuthResetPasswordPost**
> void ApiAuthResetPasswordPost (UserPasswordResetResource body = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiAuthResetPasswordPostExample
    {
        public void main()
        {
            var apiInstance = new AuthApi();
            var body = new UserPasswordResetResource(); // UserPasswordResetResource |  (optional) 

            try
            {
                apiInstance.ApiAuthResetPasswordPost(body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AuthApi.ApiAuthResetPasswordPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**UserPasswordResetResource**](UserPasswordResetResource.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="apiauthsigninpost"></a>
# **ApiAuthSignInPost**
> UserSignInResponse ApiAuthSignInPost (UserSignInResource body = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiAuthSignInPostExample
    {
        public void main()
        {
            var apiInstance = new AuthApi();
            var body = new UserSignInResource(); // UserSignInResource |  (optional) 

            try
            {
                UserSignInResponse result = apiInstance.ApiAuthSignInPost(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AuthApi.ApiAuthSignInPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**UserSignInResource**](UserSignInResource.md)|  | [optional] 

### Return type

[**UserSignInResponse**](UserSignInResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="apiauthsignupconfirmget"></a>
# **ApiAuthSignUpConfirmGet**
> void ApiAuthSignUpConfirmGet (string token, string email)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiAuthSignUpConfirmGetExample
    {
        public void main()
        {
            var apiInstance = new AuthApi();
            var token = token_example;  // string | 
            var email = email_example;  // string | 

            try
            {
                apiInstance.ApiAuthSignUpConfirmGet(token, email);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AuthApi.ApiAuthSignUpConfirmGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **token** | **string**|  | 
 **email** | **string**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="apiauthsignuppost"></a>
# **ApiAuthSignUpPost**
> UserSignUpResponse ApiAuthSignUpPost (UserSignUpResource body = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiAuthSignUpPostExample
    {
        public void main()
        {
            var apiInstance = new AuthApi();
            var body = new UserSignUpResource(); // UserSignUpResource |  (optional) 

            try
            {
                UserSignUpResponse result = apiInstance.ApiAuthSignUpPost(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AuthApi.ApiAuthSignUpPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**UserSignUpResource**](UserSignUpResource.md)|  | [optional] 

### Return type

[**UserSignUpResponse**](UserSignUpResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
