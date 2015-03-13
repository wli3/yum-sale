using System.Collections.Generic;
using System.Security.Claims;
using MvcContrib.TestHelper.Fakes;

namespace YumSaleTests.FakeModel
{
    public class FakeClaimIdentity : ClaimsIdentity
    {

        private readonly FakeIdentity _fakeIdentity;


        public FakeClaimIdentity(string id, string userName)
            : base(userName)
        {
            _fakeIdentity = new FakeIdentity(userName);
            base.AddClaims(new List<Claim>
            {
                new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", userName),
                new Claim(ClaimTypes.Sid, id)
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
            get
            {
                return _fakeIdentity.AuthenticationType;
            }
        }
    }
}