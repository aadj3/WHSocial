using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Configuration;
using System.ServiceModel.Channels;
using System.Net;

namespace Windesheim.Social.Service.Behaviors
{
    public class AuthenticationExtension : BehaviorExtensionElement, IDispatchMessageInspector
    {
        public object AfterReceiveRequest(ref Message request, System.ServiceModel.IClientChannel channel, System.ServiceModel.InstanceContext instanceContext)
        {
            var header = request.Headers.FindHeader("Authentication", "Windesheim.Social.Objects");
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
        }

        public override Type BehaviorType
        {
            get { return typeof(AuthenticationBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new AuthenticationBehavior();
        }
    }
}