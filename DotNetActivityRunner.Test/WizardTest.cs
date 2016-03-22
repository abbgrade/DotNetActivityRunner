using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using DfModels = Microsoft.Azure.Management.DataFactories.Models;
using DfRuntime = Microsoft.Azure.Management.DataFactories.Runtime;

namespace DotNetActivityRunner.Test
{
    [TestClass]
    public class WizardTest
    {
        [TestMethod]
        public void TestInitParameters()
        {
            // uninitialized Params
            List<DfModels.LinkedService> linkedServices = null;
            List<DfModels.Dataset> datasets = null;
            DfModels.Activity activity = null;
            DfRuntime.IActivityLogger logger = new ActivityLogger();

            // testdata
            var pipelinePath = Path.GetFullPath(@"..\..\Data\logs-etl-pipeline.json");
            var activityName = "stage";

            Assert.IsTrue(File.Exists(pipelinePath));

            // do run the wizard
            Wizard.InitParameters(pipelinePath, activityName,
                out linkedServices, out datasets, out activity);

            Assert.AreEqual(2, linkedServices.Count);
            Assert.AreEqual(2, datasets.Count);

            // run the activity
            DfRuntime.IDotNetActivity testedActivity = new TestActivity();
            testedActivity.Execute(linkedServices, datasets, activity, logger);
        }
    }

    internal class TestActivity : DfRuntime.IDotNetActivity
    {
        public IDictionary<string, string> Execute(IEnumerable<DfModels.LinkedService> linkedServices, IEnumerable<DfModels.Dataset> datasets, DfModels.Activity activity, DfRuntime.IActivityLogger logger)
        {
            // do your elephant business
            return null;
        }
    }
}