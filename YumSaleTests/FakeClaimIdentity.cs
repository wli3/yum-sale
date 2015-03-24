using System.Collections.Generic;
using System.Security.Claims;
using MvcContrib.TestHelper.Fakes;

namespace YumSaleTests
{
    public class FakeClaimIdentity : ClaimsIdentity
    {
        private readonly FakeIdentity _fakeIdentity;

        public FakeClaimIdentity(string id, string userName)
            : base(userName)
        {
            _fakeIdentity = new FakeIdentity(userName);
            AddClaims(new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.NameIdentifier, id)
            });
        }

        public override bool IsAuthenticated
        {
            get { return _fakeIdentity.IsAuthenticated; }
        }

        public override string Name
        {
            get { return _fakeIdentity.Name; }
        }

        public override string AuthenticationType
        {
            get { return _fakeIdentity.AuthenticationType; }
        }
    }
}