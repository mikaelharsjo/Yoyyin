using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Yoyyin.Data;
using Yoyyin.Data.Core.Entities;
using Yoyyin.PresentationModel.MarkupProviders;

namespace Yoyyin.Tests.PresentationModel
{
    [TestFixture]
    public class FacebookImageMarkupProviderShould
    {
        [Test]
        public void ReturnEmptyStringIfUserDontHaveFacebook()
        {
            FacebookImageMarkupProvider facebookImageMarkupProvider =
                new FacebookImageMarkupProvider(new User { Image = new byte[] { } });

            Assert.That(facebookImageMarkupProvider.GetMarkup(), Is.EqualTo(""));
        }

        [Test]
        public void ReturnEmptyStringIfUserHasFacebookAndYoyyinImage()
        {
            FacebookImageMarkupProvider facebookImageMarkupProvider =
                new FacebookImageMarkupProvider(new User {FacebookID = "123", Image = new byte[] {}});

            Assert.That(facebookImageMarkupProvider.GetMarkup(), Is.EqualTo(""));
        }

        [Test]
        public void ReturnMarkupIfUserHasFacebookAndNoYoyyinImage()
        {
            FacebookImageMarkupProvider facebookImageMarkupProvider =
                new FacebookImageMarkupProvider(new User { FacebookID = "123" });

            Assert.That(facebookImageMarkupProvider.GetMarkup(), Is.EqualTo("https://graph.facebook.com/123/picture"));
        }
    }
}
