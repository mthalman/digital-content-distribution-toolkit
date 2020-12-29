﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.4.0.0
//      SpecFlow Generator Version:3.4.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace blendnet.crm.contentprovider.api.bdd.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class ContentProviderFeatureFeature : object, Xunit.IClassFixture<ContentProviderFeatureFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "ContentProviderFeature.feature"
#line hidden
        
        public ContentProviderFeatureFeature(ContentProviderFeatureFeature.FixtureData fixtureData, blendnet_crm_contentprovider_api_bdd_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "ContentProviderFeature", "\tTest all the CRUD operations for Content Provider", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Create Content Provider")]
        [Xunit.TraitAttribute("FeatureTitle", "ContentProviderFeature")]
        [Xunit.TraitAttribute("Description", "Create Content Provider")]
        [Xunit.TraitAttribute("Category", "contentProvider")]
        [Xunit.InlineDataAttribute("true", new string[0])]
        [Xunit.InlineDataAttribute("false", new string[0])]
        public virtual void CreateContentProvider(string present, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "contentProvider"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("present", present);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Content Provider", null, tagsOfScenario, argumentsOfScenario);
#line 5
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 6
  testRunner.Given(string.Format("admin is \"{0}\" in the given data to create", present), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 7
  testRunner.When("I submit the request to create", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 8
  testRunner.Then("create response should recieve created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 9
  testRunner.And("I should delete the created record", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Read Content Provider")]
        [Xunit.TraitAttribute("FeatureTitle", "ContentProviderFeature")]
        [Xunit.TraitAttribute("Description", "Read Content Provider")]
        [Xunit.TraitAttribute("Category", "contentProvider")]
        [Xunit.InlineDataAttribute("true", new string[0])]
        [Xunit.InlineDataAttribute("false", new string[0])]
        public virtual void ReadContentProvider(string present, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "contentProvider"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("present", present);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Read Content Provider", null, tagsOfScenario, argumentsOfScenario);
#line 16
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 17
  testRunner.Given(string.Format("admin is \"{0}\" in the given data to create", present), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 18
  testRunner.When("I submit the request to create", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 19
  testRunner.And("I submit the request to read content", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 20
  testRunner.Then("read content response should recieve success with created id", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 21
  testRunner.And("I should delete the created record", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Update Content Provider")]
        [Xunit.TraitAttribute("FeatureTitle", "ContentProviderFeature")]
        [Xunit.TraitAttribute("Description", "Update Content Provider")]
        [Xunit.TraitAttribute("Category", "contentProvider")]
        [Xunit.InlineDataAttribute("true", new string[0])]
        [Xunit.InlineDataAttribute("false", new string[0])]
        public virtual void UpdateContentProvider(string present, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "contentProvider"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("present", present);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Update Content Provider", null, tagsOfScenario, argumentsOfScenario);
#line 28
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 29
  testRunner.Given(string.Format("admin is \"{0}\" in the given data to create", present), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 30
  testRunner.When("I submit the request to create", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 31
  testRunner.And("I submit the request to update content name", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 32
  testRunner.And("I submit the request to read updated content for updation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 33
  testRunner.Then("update content response should receive nocontent and updated name value", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 34
  testRunner.And("I should delete the created record", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Activate Content Provider")]
        [Xunit.TraitAttribute("FeatureTitle", "ContentProviderFeature")]
        [Xunit.TraitAttribute("Description", "Activate Content Provider")]
        [Xunit.TraitAttribute("Category", "contentProvider")]
        [Xunit.InlineDataAttribute("true", new string[0])]
        [Xunit.InlineDataAttribute("false", new string[0])]
        public virtual void ActivateContentProvider(string present, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "contentProvider"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("present", present);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Activate Content Provider", null, tagsOfScenario, argumentsOfScenario);
#line 41
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 42
  testRunner.Given(string.Format("admin is \"{0}\" in the given data to create", present), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 43
  testRunner.When("I submit the request to create", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 44
  testRunner.And("I submit the request to update content activation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 45
  testRunner.And("I submit the request to read updated content for activation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 46
  testRunner.Then("update content response should receive nocontent and updated activated value", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 47
  testRunner.And("I should delete the created record", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="DeActivate Content Provider")]
        [Xunit.TraitAttribute("FeatureTitle", "ContentProviderFeature")]
        [Xunit.TraitAttribute("Description", "DeActivate Content Provider")]
        [Xunit.TraitAttribute("Category", "contentProvider")]
        [Xunit.InlineDataAttribute("true", new string[0])]
        [Xunit.InlineDataAttribute("false", new string[0])]
        public virtual void DeActivateContentProvider(string present, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "contentProvider"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("present", present);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DeActivate Content Provider", null, tagsOfScenario, argumentsOfScenario);
#line 54
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 55
  testRunner.Given(string.Format("admin is \"{0}\" in the given data to create", present), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 56
  testRunner.When("I submit the request to create", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 57
  testRunner.And("I submit the request to update content deactivation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 58
  testRunner.And("I submit the request to read updated content for deactivation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 59
  testRunner.Then("update content response should receive nocontent and updated deactivated value", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 60
  testRunner.And("I should delete the created record", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Delete Content Provider")]
        [Xunit.TraitAttribute("FeatureTitle", "ContentProviderFeature")]
        [Xunit.TraitAttribute("Description", "Delete Content Provider")]
        [Xunit.TraitAttribute("Category", "contentProvider")]
        [Xunit.InlineDataAttribute("true", new string[0])]
        [Xunit.InlineDataAttribute("false", new string[0])]
        public virtual void DeleteContentProvider(string present, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "contentProvider"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("present", present);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete Content Provider", null, tagsOfScenario, argumentsOfScenario);
#line 67
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 68
  testRunner.Given(string.Format("admin is \"{0}\" in the given data to create", present), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 69
  testRunner.When("I submit the request to create", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 70
  testRunner.And("I submit the request to delete", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 71
  testRunner.And("I submit the request to read content", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 72
  testRunner.Then("read content response should recieve notfound", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Create Content Administrator")]
        [Xunit.TraitAttribute("FeatureTitle", "ContentProviderFeature")]
        [Xunit.TraitAttribute("Description", "Create Content Administrator")]
        [Xunit.TraitAttribute("Category", "contentProvider")]
        [Xunit.InlineDataAttribute("true", new string[0])]
        [Xunit.InlineDataAttribute("false", new string[0])]
        public virtual void CreateContentAdministrator(string present, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "contentProvider"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("present", present);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Content Administrator", null, tagsOfScenario, argumentsOfScenario);
#line 79
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 80
  testRunner.Given(string.Format("admin is \"{0}\" in the given data to create", present), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 81
  testRunner.When("I submit the request to create", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 82
  testRunner.And("I submit the request to create content administrator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 83
  testRunner.And("I submit the request to read content", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 84
  testRunner.Then("create content administrator response should recieve nocontent", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 85
  testRunner.And("I should delete the created record", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Update Content Administrator")]
        [Xunit.TraitAttribute("FeatureTitle", "ContentProviderFeature")]
        [Xunit.TraitAttribute("Description", "Update Content Administrator")]
        [Xunit.TraitAttribute("Category", "contentProvider")]
        [Xunit.InlineDataAttribute("true", new string[0])]
        [Xunit.InlineDataAttribute("false", new string[0])]
        public virtual void UpdateContentAdministrator(string present, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "contentProvider"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("present", present);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Update Content Administrator", null, tagsOfScenario, argumentsOfScenario);
#line 92
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 93
  testRunner.Given(string.Format("admin is \"{0}\" in the given data to create", present), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 94
  testRunner.When("I submit the request to create", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 95
  testRunner.And("I submit the request to create content administrator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 96
  testRunner.And("I submit the request to read content", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 97
  testRunner.And("I submit the request to update content-administrator name", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 98
  testRunner.And("I submit the request to read content", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 99
  testRunner.Then("update content-administrator response should receive nocontent and updated name v" +
                        "alue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 100
  testRunner.And("I should delete the created record", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Activate Content Administrator")]
        [Xunit.TraitAttribute("FeatureTitle", "ContentProviderFeature")]
        [Xunit.TraitAttribute("Description", "Activate Content Administrator")]
        [Xunit.TraitAttribute("Category", "contentProvider")]
        [Xunit.InlineDataAttribute("true", new string[0])]
        [Xunit.InlineDataAttribute("false", new string[0])]
        public virtual void ActivateContentAdministrator(string present, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "contentProvider"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("present", present);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Activate Content Administrator", null, tagsOfScenario, argumentsOfScenario);
#line 107
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 108
  testRunner.Given(string.Format("admin is \"{0}\" in the given data to create", present), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 109
  testRunner.When("I submit the request to create", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 110
  testRunner.And("I submit the request to create content administrator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 111
  testRunner.And("I submit the request to read content", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 112
  testRunner.And("I submit the request to update content-administrator activation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 113
  testRunner.And("I submit the request to read content", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 114
  testRunner.Then("update content-administrator response should receive nocontent and updated activa" +
                        "ted value", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 115
  testRunner.And("I should delete the created record", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="DeActivate Content Administrator")]
        [Xunit.TraitAttribute("FeatureTitle", "ContentProviderFeature")]
        [Xunit.TraitAttribute("Description", "DeActivate Content Administrator")]
        [Xunit.TraitAttribute("Category", "contentProvider")]
        [Xunit.InlineDataAttribute("true", new string[0])]
        [Xunit.InlineDataAttribute("false", new string[0])]
        public virtual void DeActivateContentAdministrator(string present, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "contentProvider"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("present", present);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DeActivate Content Administrator", null, tagsOfScenario, argumentsOfScenario);
#line 122
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 123
  testRunner.Given(string.Format("admin is \"{0}\" in the given data to create", present), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 124
  testRunner.When("I submit the request to create", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 125
  testRunner.And("I submit the request to create content administrator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 126
  testRunner.And("I submit the request to read content", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 127
  testRunner.And("I submit the request to update content-administrator deactivation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 128
  testRunner.And("I submit the request to read content", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 129
  testRunner.Then("update content-administrator response should receive nocontent and updated deacti" +
                        "vated value", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 130
  testRunner.And("I should delete the created record", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.4.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                ContentProviderFeatureFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                ContentProviderFeatureFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion