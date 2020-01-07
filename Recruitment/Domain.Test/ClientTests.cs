using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Domain.Test
{
    public class ClientTests
    {
        private const string ALPHA = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        [Fact]
        public void Should_Create_Successfully()
        {
            var data = new
            {
                Name = "Corporation Inc",
                Website = "https://www.something.somewhere",
                Description = "A corportaion, asking often for java and c# developers"
            };

            var client = new Client(data.Name, data.Website, data.Description);

            Assert.Equal(data.Name, client.Name);
            Assert.Equal(data.Website, client.Website);
            Assert.Equal(data.Description, client.Description);
        }

        [Fact]
        public void Should_Throw_If_No_Name()
        {
            Assert.Throws<ArgumentNullException>(() => new Client("    ", null, null));
            Assert.Throws<ArgumentNullException>(() => new Client(string.Empty, null, null));
            Assert.Throws<ArgumentNullException>(() => new Client(null, null, null));
        }

        [Fact]
        public void Should_Throw_If_Website_Longer()
        {
            var websiteLength = 150;

            var url = new StringBuilder(ALPHA);
            while (url.Length <= websiteLength)
            {
                url.Append(ALPHA);
            }

            Assert.Throws<ArgumentOutOfRangeException>(() => new Client("Client Name", url.ToString(), null));
        }

        [Fact]
        public void Should_Throw_If_Description_Longer()
        {
            var descLength = 1000;

            var strContent = new StringBuilder(ALPHA);
            while (strContent.Length <= descLength)
            {
                strContent.Append(ALPHA);
            }

            Assert.Throws<ArgumentOutOfRangeException>(() => new Client("Client Name", "https://www.something.somewhere", strContent.ToString()));
        }

        [Fact]
        public void Should_Update_Name()
        {
            var data = new
            {
                Name = "Corporation Inc",
                Website = "https://www.something.somewhere",
                Description = "A corportaion, asking often for java and c# developers"
            };

            var client = new Client(data.Name, data.Website, data.Description);
            var newname = "Google Inc.";
            client.UpdateName(newname);

            Assert.Equal(newname, client.Name);
        }

        [Fact]
        public void Should_Update_Website()
        {
            var data = new
            {
                Name = "Corporation Inc",
                Website = "https://www.something.somewhere",
                Description = "A corportaion, asking often for java and c# developers"
            };

            var client = new Client(data.Name, data.Website, data.Description);
            var newWebsite = "https://www.a-new-client.com";

            client.UpdateWebsite(newWebsite);

            Assert.Equal(newWebsite, client.Website);
        }

        [Fact]
        public void Should_Update_Description()
        {
            var data = new
            {
                Name = "Corporation Inc",
                Website = "https://www.something.somewhere",
                Description = "A corportaion, asking often for java and c# developers"
            };

            var client = new Client(data.Name, data.Website, data.Description);
            var newDescr = "some descr";
            client.UpdateDescription(newDescr);

            Assert.Equal(newDescr, client.Description);
        }
    }
}
