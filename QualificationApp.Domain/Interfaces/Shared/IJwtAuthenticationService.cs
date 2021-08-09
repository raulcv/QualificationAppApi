using System;
using System.Collections.Generic;
using System.Text;

namespace QualificationApp.Domain.Interfaces.Shared
{
    public interface IJwtAuthenticationService
    {
        //string Authenticate(string usuario, string password);
        string Authentication(string usuario, string authPassword, string password, string salt);

    }
}
