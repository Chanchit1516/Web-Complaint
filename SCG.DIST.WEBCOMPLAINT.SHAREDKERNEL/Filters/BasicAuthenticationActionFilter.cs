using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SCG.DIST.WEBCOMPLAINT.SHAREDKERNEL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.DIST.WEBCOMPLAINT.SHAREDKERNEL.Filters
{
    public class BasicAuthenticationActionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => 2;
        public BasicAuthenticationSystem SystemTerm { get; set; }
        private readonly ILogger<BasicAuthenticationActionFilter> _logger;
        private readonly IConfiguration _appConfig;

        public BasicAuthenticationActionFilter(ILogger<BasicAuthenticationActionFilter> logger, IConfiguration appConfig, BasicAuthenticationSystem systemTerm = BasicAuthenticationSystem.General)
        {
            _logger = logger;
            _appConfig = appConfig;
            SystemTerm = systemTerm;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var authHeader = context.HttpContext.Request.Headers["Authorization"];
            var authenticationToken = authHeader.ToString();
            if (string.IsNullOrEmpty(authenticationToken))
            {
                _logger.LogInformation($"BasicAuthentication Not Provided");
                context.Result = new UnauthorizedResult();
                return;
            }

            authenticationToken = authenticationToken.Replace("Basic ", "").Trim();

            var decodedAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
            var usernamePasswordArray = decodedAuthenticationToken.Split(':');
            var userName = usernamePasswordArray[0];
            var password = usernamePasswordArray[1];

            var challengeCredential = GetAccountCredential();
            var isValid = userName == challengeCredential.Item1 && password == challengeCredential.Item2;

            if (!isValid)
            {
                _logger.LogInformation($"BasicAuthentication Invalid Username or Password. ['{userName}','{password}']");
                context.Result = new UnauthorizedResult();
            }
            else
            {
                _logger.LogDebug($"BasicAuthentication Valid (Pass)");
            }

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public Tuple<string, string> GetAccountCredential()
        {
            string username, password;

            if (SystemTerm == BasicAuthenticationSystem.CPM)
            {
                username = _appConfig.GetSection("Inbound.BasicAuth.SYSTEMNAME:Username").Value;
                password = _appConfig.GetSection("Inbound.BasicAuth.SYSTEMNAME:Password").Value;
            }
            else
            {
                username = "";
                password = "";
            }

            return new Tuple<string, string>(username, password);
        }

    }

}
