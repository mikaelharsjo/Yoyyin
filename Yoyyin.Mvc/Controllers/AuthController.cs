using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OpenId;
using DotNetOpenAuth.OpenId.Extensions.SimpleRegistration;
using DotNetOpenAuth.OpenId.RelyingParty;

namespace Yoyyin.Mvc.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult FirstSignIn()
        {
            var openid = new OpenIdRelyingParty();
            var response = openid.GetResponse();

            if (response != null)
            {
                switch (response.Status)
                {
                    case AuthenticationStatus.Authenticated:
                        var claimsResponse = response.GetExtension<ClaimsResponse>();
                        FormsAuthentication.SetAuthCookie(claimsResponse.Email, true);
                        return RedirectToAction("Index", "Member");
                    case AuthenticationStatus.Canceled:
                        ModelState.AddModelError("loginIdentifier",
                                                 "Login was cancelled at the provider");
                        break;
                    case AuthenticationStatus.Failed:
                        ModelState.AddModelError("loginIdentifier",
                                                 "Login failed using the provided OpenID identifier");
                        break;
                }
            }

            return View();
        }
        public ActionResult SignIn()
        {
            var openid = new OpenIdRelyingParty();
            var response = openid.GetResponse();

            if (response != null)
            {
                switch (response.Status)
                {
                    case AuthenticationStatus.Authenticated:
                        var claimsResponse = response.GetExtension<ClaimsResponse>();
                        FormsAuthentication.SetAuthCookie(claimsResponse.Email, true);
                        return RedirectToAction("Index", "Member");
                    case AuthenticationStatus.Canceled:
                        ModelState.AddModelError("loginIdentifier",
                                                 "Login was cancelled at the provider");
                        break;
                    case AuthenticationStatus.Failed:
                        ModelState.AddModelError("loginIdentifier",
                                                 "Login failed using the provided OpenID identifier");
                        break;
                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult SignIn(string openIdProviderUrl)
        {
            if (!Identifier.IsValid(openIdProviderUrl))
            {
                ModelState.AddModelError("loginIdentifier",
                                         "The specified login identifier is invalid");
                return View();
            }

            if (ModelState.IsValid)
            {
                var openid = new OpenIdRelyingParty();
                var identifier = Identifier.Parse(openIdProviderUrl);

                var thisUri = Request.Url;
                //var returnUri = new Uri(string.Format("{0}://{1}:{2}{3}", thisUri.Scheme, thisUri.Host, thisUri.Port, returnUrl));

                var request = openid.CreateRequest(identifier, Realm.AutoDetect, thisUri);

                // Require some additional data
                request.AddExtension(new ClaimsRequest
                {
                    Email = DemandLevel.Require,
                    FullName = DemandLevel.Require
                });

                return request.RedirectingResponse.AsActionResult();
            }
            return View();
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("~/");
        }
    }
}
