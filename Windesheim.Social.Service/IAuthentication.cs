using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using Windesheim.Social.Objects;

namespace Windesheim.Social.Service
{
    [ServiceContract]
    public interface IAuthentication
    {
        /// <summary>
        /// Use this method to login. Currently only FacebookUserCredentials are supported.
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns></returns>
        [OperationContract]
        Authentication Login(LoginCredentials credentials);
    }
}