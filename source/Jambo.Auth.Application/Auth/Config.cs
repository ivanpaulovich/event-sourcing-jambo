using System;
using System.Collections.Generic;
using System.Text;

namespace Jambo.Auth.Application.Auth
{
    public class Config
    {
        public string SecretKey { get; private set; }
        public string Issuer { get; private set; }

        public Config(string secretKey, string issuer)
        {
            this.SecretKey = secretKey;
            this.Issuer = issuer;
        }
    }
}
