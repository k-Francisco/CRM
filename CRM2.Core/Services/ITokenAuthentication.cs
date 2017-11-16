using System;
using System.Collections.Generic;
using System.Text;

namespace CRM2.Dependency
{
    public interface ITokenAuthentication
    {
        List<string> GetTokens();
    }
}
