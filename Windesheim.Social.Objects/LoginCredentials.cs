﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Windesheim.Social.Objects
{
    [DataContract]
    [KnownType(typeof(FacebookLoginCredentials))]
    public class LoginCredentials
    {
    }
}
