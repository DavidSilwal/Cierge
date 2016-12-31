﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PwdLess.Auth.Services
{
    /// <summary>
    /// Converts a template in configuration to a complete string, given a token.
    /// </summary>
    public interface ITemplateProcessor
    {
        string ProcessTemplate(string totp);
    }
    
    public class EmailTemplateProcessor : ITemplateProcessor
    {
        private IConfigurationRoot _config;
        public EmailTemplateProcessor(IConfigurationRoot config)
        {
            _config = config;
        }

        public string ProcessTemplate(string totp)
        {
            var url = _config["PwdLess:ClientJwtUrl"].Replace("{{totp}}", totp);

            var body = _config["PwdLess:EmailContents:Body"].Replace("{{url}}", url)
                                                             .Replace("{{totp}}", totp);
            return body;
        }
    }
}