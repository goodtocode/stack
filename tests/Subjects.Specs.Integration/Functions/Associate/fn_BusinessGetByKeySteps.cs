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
    public class Fn_BusinessGetByKeySteps : ICrudSteps<Business>
    {
        
        private readonly IConfiguration _config;
        private readonly Fn_BusinessCreateSteps createSteps = new Fn_BusinessCreateSteps();
        public Guid SutKey { get; private set; }
        public Business Sut { get; private set; }
        public IList<Business> Suts { get; private set; } = new List<Business>();
        public IList<Business> RecycleBin { get; private set; } = new List<Business>();

        public Fn_BusinessGetByKeySteps()
        {
            _config = new ConfigurationFactory(Directory.GetCurrentDirectory().Replace("TestResults", "Subjects.Specs.Integration")).Create();
        }

        [Given(@"I have a business key to get from the Azure Function")]
        public async Task GivenIHaveABusinessKeyToGetFromTheAzureFunction()
        {
            createSteps.GivenIHaveANewBusinessForTheAzureFunction();
            await createSteps.WhenBusinessIsCreatedViaAzureFunction();
            Suts = createSteps.Suts;
            Sut = createSteps.Sut;
            SutKey = createSteps.SutKey;
            Assert.IsTrue(SutKey != Guid.Empty);
        }

        [When(@"Business is queried by key via Azure Function")]
        public async Task WhenBusinessIsQueriedByKeyViaAzureFunction()
        {
            var client = new HttpClientFactory().CreateJsonClient<Business>();
            var response = await client.GetAsync(new AzureFunctionUrlFactory(_config, "Subjects", "Business").CreateGetByKeyUrl(SutKey));
            Assert.IsTrue(response.IsSuccessStatusCode);
            var result = await response.Content.ReadAsStringAsync();
            Suts.Add(JsonConvert.DeserializeObject<Business>(result));
            Sut = Suts.FirstOrDefault();
            SutKey = Sut.BusinessKey;
        }

        [Then(@"the matching business is returned from the Azure Function")]
        public void ThenTheMatchingBusinessIsReturnedFromTheAzureFunction()
        {
            Assert.IsTrue(Sut.BusinessKey == SutKey);
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            await createSteps.Cleanup();
        }
    }
}
