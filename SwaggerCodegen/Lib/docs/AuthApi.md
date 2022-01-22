# IO.Swagger.Api.AuthApi

All URIs are relative to */*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiAuthUserChangePasswordPut**](AuthApi.md#apiauthuserchangepasswordput) | **PUT** /api/Auth/User/ChangePassword | 
[**ApiAuthUserForgotPasswordPost**](AuthApi.md#apiauthuserforgotpasswordpost) | **POST** /api/Auth/User/ForgotPassword | 
[**ApiAuthUserResetPasswordPost**](AuthApi.md#apiauthuserresetpasswordpost) | **POST** /api/Auth/User/ResetPassword | 
[**ApiAuthUserSignInPost**](AuthApi.md#apiauthusersigninpost) | **POST** /api/Auth/User/SignIn | 
[**ApiAuthUserSignUpConfirmGet**](AuthApi.md#apiauthusersignupconfirmget) | **GET** /api/Auth/User/SignUpConfirm | 
[**ApiAuthUserSignUpPost**](AuthApi.md#apiauthusersignuppost) | **POST** /api/Auth/User/SignUp | 

<a name="apiauthuserchangepasswordput"></a>
# **ApiAuthUserChangePasswordPut**
> void ApiAuthUserChangePasswordPut (UserPasswordChangeResource body = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiAuthUserChangePasswordPutExample
    {
        public void main()
        {
            var apiInstance = new AuthApi();
            var body = new UserPasswordChangeResource(); // UserPasswordChangeResource |  (optional) 

            try
            {
                apiInstance.ApiAuthUserChangePasswordPut(body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AuthApi.ApiAuthUserChangePasswordPut: " + e.Message );
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
<a name="apiauthuserforgotpasswordpost"></a>
# **ApiAuthUserForgotPasswordPost**
> UserForgotPasswordResponse ApiAuthUserForgotPasswordPost (UserPasswordForgotResource body = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiAuthUserForgotPasswordPostExample
    {
        public void main()
        {
            var apiInstance = new AuthApi();
            var body = new UserPasswordForgotResource(); // UserPasswordForgotResource |  (optional) 

            try
            {
                UserForgotPasswordResponse result = apiInstance.ApiAuthUserForgotPasswordPost(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AuthApi.ApiAuthUserForgotPasswordPost: " + e.Message );
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
<a name="apiauthuserresetpasswordpost"></a>
# **ApiAuthUserResetPasswordPost**
> void ApiAuthUserResetPasswordPost (UserPasswordResetResource body = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiAuthUserResetPasswordPostExample
    {
        public void main()
        {
            var apiInstance = new AuthApi();
            var body = new UserPasswordResetResource(); // UserPasswordResetResource |  (optional) 

            try
            {
                apiInstance.ApiAuthUserResetPasswordPost(body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AuthApi.ApiAuthUserResetPasswordPost: " + e.Message );
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
<a name="apiauthusersigninpost"></a>
# **ApiAuthUserSignInPost**
> UserSignInResponse ApiAuthUserSignInPost (UserSignInResource body = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiAuthUserSignInPostExample
    {
        public void main()
        {
            var apiInstance = new AuthApi();
            var body = new UserSignInResource(); // UserSignInResource |  (optional) 

            try
            {
                UserSignInResponse result = apiInstance.ApiAuthUserSignInPost(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AuthApi.ApiAuthUserSignInPost: " + e.Message );
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
<a name="apiauthusersignupconfirmget"></a>
# **ApiAuthUserSignUpConfirmGet**
> void ApiAuthUserSignUpConfirmGet (string token = null, string email = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiAuthUserSignUpConfirmGetExample
    {
        public void main()
        {
            var apiInstance = new AuthApi();
            var token = token_example;  // string |  (optional) 
            var email = email_example;  // string |  (optional) 

            try
            {
                apiInstance.ApiAuthUserSignUpConfirmGet(token, email);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AuthApi.ApiAuthUserSignUpConfirmGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **token** | **string**|  | [optional] 
 **email** | **string**|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="apiauthusersignuppost"></a>
# **ApiAuthUserSignUpPost**
> UserSignUpResponse ApiAuthUserSignUpPost (UserSignUpResource body = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiAuthUserSignUpPostExample
    {
        public void main()
        {
            var apiInstance = new AuthApi();
            var body = new UserSignUpResource(); // UserSignUpResource |  (optional) 

            try
            {
                UserSignUpResponse result = apiInstance.ApiAuthUserSignUpPost(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AuthApi.ApiAuthUserSignUpPost: " + e.Message );
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
