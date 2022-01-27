# IO.Swagger.Api.AdminApi

All URIs are relative to */*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiAdminRoleRoleNameGet**](AdminApi.md#apiadminrolerolenameget) | **GET** /api/Admin/Role/{roleName} | 
[**ApiAdminRolesCreatePost**](AdminApi.md#apiadminrolescreatepost) | **POST** /api/Admin/Roles/Create | 
[**ApiAdminRolesDeleteRoleNameDelete**](AdminApi.md#apiadminrolesdeleterolenamedelete) | **DELETE** /api/Admin/Roles/Delete/{roleName} | 
[**ApiAdminRolesGet**](AdminApi.md#apiadminrolesget) | **GET** /api/Admin/Roles | 
[**ApiAdminUserCreatePost**](AdminApi.md#apiadminusercreatepost) | **POST** /api/Admin/User/Create | 
[**ApiAdminUserUserEmailGet**](AdminApi.md#apiadminuseruseremailget) | **GET** /api/Admin/User/{userEmail} | 
[**ApiAdminUserUserEmailRolesPost**](AdminApi.md#apiadminuseruseremailrolespost) | **POST** /api/Admin/User/{userEmail}/Roles | 
[**ApiAdminUsersDeleteUserNameDelete**](AdminApi.md#apiadminusersdeleteusernamedelete) | **DELETE** /api/Admin/Users/Delete/{userName} | 
[**ApiAdminUsersGet**](AdminApi.md#apiadminusersget) | **GET** /api/Admin/Users | 

<a name="apiadminrolerolenameget"></a>
# **ApiAdminRoleRoleNameGet**
> RoleGetRoleResponse ApiAdminRoleRoleNameGet (string roleName)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiAdminRoleRoleNameGetExample
    {
        public void main()
        {
            var apiInstance = new AdminApi();
            var roleName = roleName_example;  // string | 

            try
            {
                RoleGetRoleResponse result = apiInstance.ApiAdminRoleRoleNameGet(roleName);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AdminApi.ApiAdminRoleRoleNameGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **roleName** | **string**|  | 

### Return type

[**RoleGetRoleResponse**](RoleGetRoleResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="apiadminrolescreatepost"></a>
# **ApiAdminRolesCreatePost**
> void ApiAdminRolesCreatePost (RoleCreateResource body = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiAdminRolesCreatePostExample
    {
        public void main()
        {
            var apiInstance = new AdminApi();
            var body = new RoleCreateResource(); // RoleCreateResource |  (optional) 

            try
            {
                apiInstance.ApiAdminRolesCreatePost(body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AdminApi.ApiAdminRolesCreatePost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**RoleCreateResource**](RoleCreateResource.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="apiadminrolesdeleterolenamedelete"></a>
# **ApiAdminRolesDeleteRoleNameDelete**
> void ApiAdminRolesDeleteRoleNameDelete (string roleName)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiAdminRolesDeleteRoleNameDeleteExample
    {
        public void main()
        {
            var apiInstance = new AdminApi();
            var roleName = roleName_example;  // string | 

            try
            {
                apiInstance.ApiAdminRolesDeleteRoleNameDelete(roleName);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AdminApi.ApiAdminRolesDeleteRoleNameDelete: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **roleName** | **string**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="apiadminrolesget"></a>
# **ApiAdminRolesGet**
> RoleGetRolesResponse ApiAdminRolesGet ()



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiAdminRolesGetExample
    {
        public void main()
        {
            var apiInstance = new AdminApi();

            try
            {
                RoleGetRolesResponse result = apiInstance.ApiAdminRolesGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AdminApi.ApiAdminRolesGet: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**RoleGetRolesResponse**](RoleGetRolesResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="apiadminusercreatepost"></a>
# **ApiAdminUserCreatePost**
> void ApiAdminUserCreatePost (UserCreateResource body = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiAdminUserCreatePostExample
    {
        public void main()
        {
            var apiInstance = new AdminApi();
            var body = new UserCreateResource(); // UserCreateResource |  (optional) 

            try
            {
                apiInstance.ApiAdminUserCreatePost(body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AdminApi.ApiAdminUserCreatePost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**UserCreateResource**](UserCreateResource.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="apiadminuseruseremailget"></a>
# **ApiAdminUserUserEmailGet**
> UserGetUserResponse ApiAdminUserUserEmailGet (string userEmail)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiAdminUserUserEmailGetExample
    {
        public void main()
        {
            var apiInstance = new AdminApi();
            var userEmail = userEmail_example;  // string | 

            try
            {
                UserGetUserResponse result = apiInstance.ApiAdminUserUserEmailGet(userEmail);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AdminApi.ApiAdminUserUserEmailGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userEmail** | **string**|  | 

### Return type

[**UserGetUserResponse**](UserGetUserResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="apiadminuseruseremailrolespost"></a>
# **ApiAdminUserUserEmailRolesPost**
> void ApiAdminUserUserEmailRolesPost (string userEmail, RoleAddUserResource body = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiAdminUserUserEmailRolesPostExample
    {
        public void main()
        {
            var apiInstance = new AdminApi();
            var userEmail = userEmail_example;  // string | 
            var body = new RoleAddUserResource(); // RoleAddUserResource |  (optional) 

            try
            {
                apiInstance.ApiAdminUserUserEmailRolesPost(userEmail, body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AdminApi.ApiAdminUserUserEmailRolesPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userEmail** | **string**|  | 
 **body** | [**RoleAddUserResource**](RoleAddUserResource.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="apiadminusersdeleteusernamedelete"></a>
# **ApiAdminUsersDeleteUserNameDelete**
> void ApiAdminUsersDeleteUserNameDelete (string userName)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiAdminUsersDeleteUserNameDeleteExample
    {
        public void main()
        {
            var apiInstance = new AdminApi();
            var userName = userName_example;  // string | 

            try
            {
                apiInstance.ApiAdminUsersDeleteUserNameDelete(userName);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AdminApi.ApiAdminUsersDeleteUserNameDelete: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userName** | **string**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="apiadminusersget"></a>
# **ApiAdminUsersGet**
> UserGetUsersResponse ApiAdminUsersGet ()



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiAdminUsersGetExample
    {
        public void main()
        {
            var apiInstance = new AdminApi();

            try
            {
                UserGetUsersResponse result = apiInstance.ApiAdminUsersGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AdminApi.ApiAdminUsersGet: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**UserGetUsersResponse**](UserGetUsersResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
