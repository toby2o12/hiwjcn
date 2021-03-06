﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormApp.AuthWebService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AuthWebService.IAuthApiService")]
    public interface IAuthApiService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthApiService/GetAccessToken", ReplyAction="http://tempuri.org/IAuthApiService/GetAccessTokenResponse")]
        Lib.mvc._<Lib.mvc.auth.TokenModel> GetAccessToken(string client_id, string client_secret, string code, string grant_type);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthApiService/GetAccessToken", ReplyAction="http://tempuri.org/IAuthApiService/GetAccessTokenResponse")]
        System.Threading.Tasks.Task<Lib.mvc._<Lib.mvc.auth.TokenModel>> GetAccessTokenAsync(string client_id, string client_secret, string code, string grant_type);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthApiService/GetLoginUserInfoByToken", ReplyAction="http://tempuri.org/IAuthApiService/GetLoginUserInfoByTokenResponse")]
        Lib.mvc._<Lib.mvc.user.LoginUserInfo> GetLoginUserInfoByToken(string client_id, string access_token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthApiService/GetLoginUserInfoByToken", ReplyAction="http://tempuri.org/IAuthApiService/GetLoginUserInfoByTokenResponse")]
        System.Threading.Tasks.Task<Lib.mvc._<Lib.mvc.user.LoginUserInfo>> GetLoginUserInfoByTokenAsync(string client_id, string access_token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthApiService/GetAuthCodeByOneTimeCode", ReplyAction="http://tempuri.org/IAuthApiService/GetAuthCodeByOneTimeCodeResponse")]
        Lib.mvc._<string> GetAuthCodeByOneTimeCode(string client_id, string scopeJson, string phone, string sms);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthApiService/GetAuthCodeByOneTimeCode", ReplyAction="http://tempuri.org/IAuthApiService/GetAuthCodeByOneTimeCodeResponse")]
        System.Threading.Tasks.Task<Lib.mvc._<string>> GetAuthCodeByOneTimeCodeAsync(string client_id, string scopeJson, string phone, string sms);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthApiService/GetAuthCodeByPassword", ReplyAction="http://tempuri.org/IAuthApiService/GetAuthCodeByPasswordResponse")]
        Lib.mvc._<string> GetAuthCodeByPassword(string client_id, string scopeJson, string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthApiService/GetAuthCodeByPassword", ReplyAction="http://tempuri.org/IAuthApiService/GetAuthCodeByPasswordResponse")]
        System.Threading.Tasks.Task<Lib.mvc._<string>> GetAuthCodeByPasswordAsync(string client_id, string scopeJson, string username, string password);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAuthApiServiceChannel : WindowsFormApp.AuthWebService.IAuthApiService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AuthApiServiceClient : System.ServiceModel.ClientBase<WindowsFormApp.AuthWebService.IAuthApiService>, WindowsFormApp.AuthWebService.IAuthApiService {
        
        public AuthApiServiceClient() {
        }
        
        public AuthApiServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AuthApiServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthApiServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthApiServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Lib.mvc._<Lib.mvc.auth.TokenModel> GetAccessToken(string client_id, string client_secret, string code, string grant_type) {
            return base.Channel.GetAccessToken(client_id, client_secret, code, grant_type);
        }
        
        public System.Threading.Tasks.Task<Lib.mvc._<Lib.mvc.auth.TokenModel>> GetAccessTokenAsync(string client_id, string client_secret, string code, string grant_type) {
            return base.Channel.GetAccessTokenAsync(client_id, client_secret, code, grant_type);
        }
        
        public Lib.mvc._<Lib.mvc.user.LoginUserInfo> GetLoginUserInfoByToken(string client_id, string access_token) {
            return base.Channel.GetLoginUserInfoByToken(client_id, access_token);
        }
        
        public System.Threading.Tasks.Task<Lib.mvc._<Lib.mvc.user.LoginUserInfo>> GetLoginUserInfoByTokenAsync(string client_id, string access_token) {
            return base.Channel.GetLoginUserInfoByTokenAsync(client_id, access_token);
        }
        
        public Lib.mvc._<string> GetAuthCodeByOneTimeCode(string client_id, string scopeJson, string phone, string sms) {
            return base.Channel.GetAuthCodeByOneTimeCode(client_id, scopeJson, phone, sms);
        }
        
        public System.Threading.Tasks.Task<Lib.mvc._<string>> GetAuthCodeByOneTimeCodeAsync(string client_id, string scopeJson, string phone, string sms) {
            return base.Channel.GetAuthCodeByOneTimeCodeAsync(client_id, scopeJson, phone, sms);
        }
        
        public Lib.mvc._<string> GetAuthCodeByPassword(string client_id, string scopeJson, string username, string password) {
            return base.Channel.GetAuthCodeByPassword(client_id, scopeJson, username, password);
        }
        
        public System.Threading.Tasks.Task<Lib.mvc._<string>> GetAuthCodeByPasswordAsync(string client_id, string scopeJson, string username, string password) {
            return base.Channel.GetAuthCodeByPasswordAsync(client_id, scopeJson, username, password);
        }
    }
}
