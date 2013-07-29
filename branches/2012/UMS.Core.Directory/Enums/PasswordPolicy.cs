using System;

namespace UMS.Core.Directory.Enums
{
    [Flags]
    internal enum PasswordPolicy
    {
        DomainPasswordComplex = 1,
        DomainPasswordNoAnonChange = 2,
        DomainPasswordNoClearChange = 4,
        DomainLockoutAdmins = 8,
        DomainPasswordStoreCleartext = 16,
        DomainRefusePasswordChange = 32
    }
}
