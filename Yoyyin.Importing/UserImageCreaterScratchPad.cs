using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Yoyyin.Importing
{
    [TestFixture]
    public class UserImageCreaterScratchPad
    {
        [Test]
        public void Test()
        {
            UserImageCreater userImageCreater = new UserImageCreater();

            

            userImageCreater.CreateImages();
        }
    }
}
