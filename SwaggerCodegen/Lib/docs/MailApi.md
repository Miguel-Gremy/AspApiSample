# IO.Swagger.Api.MailApi

All URIs are relative to */*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiMailSendPost**](MailApi.md#apimailsendpost) | **POST** /api/Mail/Send | 

<a name="apimailsendpost"></a>
# **ApiMailSendPost**
> void ApiMailSendPost (EmailSendResource body = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiMailSendPostExample
    {
        public void main()
        {
            var apiInstance = new MailApi();
            var body = new EmailSendResource(); // EmailSendResource |  (optional) 

            try
            {
                apiInstance.ApiMailSendPost(body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MailApi.ApiMailSendPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**EmailSendResource**](EmailSendResource.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
