using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Windesheim.Social.Objects;

namespace Windesheim.Social.Service.Business.UnitTest
{
    [TestClass]
    public class GroupTest : BaseTestclass
    {
        [TestClass]
        public class GetGroupsMethod : GroupTest
        {
            [TestMethod]
            public void OnlyReturnsPublicGroups()
            {
                var publicGroup = new Group()
                {
                    AccessType = GroupAccess.Open,
                    Description = "OpenGroup",
                    Name = "OpenGroup"
                };

                var secretGroup = new Group()
                {
                    AccessType = GroupAccess.Secret,
                    Description = "SecretGroup",
                    Name = "SecretGroup"
                };

                List<Group> result;

                using (var business = new SocialServiceBusiness(Data))
                {
                    business.Groups.AddGroup(publicGroup);
                    business.Groups.AddGroup(secretGroup);

                    result = business.Groups.GetGroups();
                }

                Assert.AreEqual(1, result.Count);
                Assert.AreEqual(publicGroup, result.Single());
            }
        }

        [TestClass]
        public class GetGroupsExtendedMethod : GroupTest
        {
            [TestMethod]
            public void GetGroupsExtended()
            {
                
            }
        }
        
        [TestClass]
        public class AddGroupMethod : GroupTest
        {
            [TestMethod]
            public void AddGroup()
            {
            }
        }

        [TestClass]
        public class EnrollInGroupMethod : GroupTest
        {
            [TestMethod]
            public void EnrollInGroup()
            {
                
            }
        }
    }
}
