﻿using GoodToCode.Shared.Specs;
using GoodToCode.Subjects.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GoodToCode.Subjects.Specs
{
    [Binding]
    public class api_BusinessesGetSteps : ICrudSteps<Business>
    {
        private readonly IConfiguration _config;
        private readonly api_BusinessCreateSteps createSteps = new api_BusinessCreateSteps();

        public IList<Business> Suts { get; private set; }
        public Business Sut { get; private set; }
        public Guid SutKey { get; private set; }
        public IList<Business> RecycleBin { get; set; }

        public api_BusinessesGetSteps()
        {
            _config = new ConfigurationFactory(Directory.GetCurrentDirectory().Replace("TestResults", "Subjects.Specs")).Create();
        }

        [Given(@"I request the list of businesses from the Web API")]
        public async Task GivenIRequestTheListOfBusinessesFromTheWebAPI()
        {
            await createSteps.WhenBusinessIsCreatedViaWebAPI();
        }

        [When(@"Businesses are queried via Web API")]
        public async Task WhenBusinessesAreQueriedViaWebAPI()
        {
            var client = new HttpClientFactory().Create();
            var response = await client.GetAsync(new WebApiUrlFactory("Subjects", "Business").CreateGetAllUrl());
            var result = await response.Content.ReadAsStringAsync();
            Suts = JsonConvert.DeserializeObject<List<Business>>(result).Take(5).ToList();
            Sut = Suts.FirstOrDefault();
            SutKey = Sut.BusinessKey;
        }

        [Then(@"All persisted businesses are returned from the Web API")]
        public void ThenAllPersistedBusinessesAreReturnedFromTheWebAPI()
        {
            Assert.IsTrue(Suts.Any());
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            await createSteps.Cleanup();
        }
    }
}
