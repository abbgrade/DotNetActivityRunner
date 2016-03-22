﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using CommonModels = Microsoft.Azure.Management.DataFactories.Common.Models;
using Models = Microsoft.Azure.Management.DataFactories.Models;

namespace DotNetActivityRunner
{
    public class Wizard
    {
        public static void InitParameters(
            string pipelinePath,
            string activityName,
            out List<Models.LinkedService> linkedServices,
            out List<Models.Dataset> datasets,
            out Models.Activity activity)
        {
            // init the parameters
            linkedServices = new List<Models.LinkedService>();
            datasets = new List<Models.Dataset>();
            activity = new Models.Activity();

            // parse the pipeline json source
            var pipelineJson = File.ReadAllText(pipelinePath);
            var dummyPipeline = JsonConvert.DeserializeObject<Pipeline>(pipelineJson);

            foreach (var dummyActivity in dummyPipeline.Properties.Activities)
            {
                // find the relevant activity in the pipeline
                if (dummyActivity.Name != activityName)
                    continue;

                // get the input and output tables
                var dummyDatasets = new HashSet<ActivityData>();
                dummyDatasets.UnionWith(dummyActivity.Inputs);
                dummyDatasets.UnionWith(dummyActivity.Outputs);

                var dummyServices = new HashSet<LinkedService>();

                // init the data tables
                foreach (var dummyDataset in dummyDatasets)
                {
                    // parse the table json source
                    var dataPath = Path.Combine(Path.GetDirectoryName(pipelinePath), dummyDataset.Name + ".json");
                    var dataJson = File.ReadAllText(dataPath);
                    var dummyTable = JsonConvert.DeserializeObject<Table>(dataJson);

                    // init the azure model
                    var blobDataset = new Models.AzureBlobDataset();
                    blobDataset.FolderPath = dummyTable.Properties.TypeProperties.FolderPath;
                    blobDataset.FileName = dummyTable.Properties.TypeProperties.FileName;

                    var dataDataset = new Models.Dataset(dummyDataset.Name, new Models.DatasetProperties(blobDataset, new CommonModels.Availability(), ""));
                    dataDataset.Properties.LinkedServiceName = dummyTable.Properties.LinkedServiceName;
                    datasets.Add(dataDataset);

                    // register the input or output in the activity
                    if (dummyDataset is ActivityInput)
                        activity.Inputs.Add(new CommonModels.ActivityInput(dummyDataset.Name));

                    if (dummyDataset is ActivityOutput)
                        activity.Outputs.Add(new CommonModels.ActivityOutput(dummyDataset.Name));

                    // parse the linked service json source for later use
                    var servicePath = Path.Combine(Path.GetDirectoryName(pipelinePath), dummyTable.Properties.LinkedServiceName + ".json");
                    var serviceJson = File.ReadAllText(servicePath);
                    var storageService = JsonConvert.DeserializeObject<StorageService>(serviceJson);

                    dummyServices.Add(storageService);
                }

                // parse the hd insight service json source
                {
                    var servicePath = Path.Combine(Path.GetDirectoryName(pipelinePath), dummyActivity.LinkedServiceName + ".json");
                    var serviceJson = File.ReadAllText(servicePath);
                    var computeService = JsonConvert.DeserializeObject<ComputeService>(serviceJson);

                    dummyServices.Add(computeService);
                }

                // init the services
                foreach (var dummyService in dummyServices)
                {
                    Models.LinkedService linkedService = null;

                    // init if it is a storage service
                    if (dummyService is StorageService)
                    {
                        var dummyStorageService = dummyService as StorageService;

                        var service = new Models.AzureStorageLinkedService();
                        service.ConnectionString = dummyStorageService.Properties.TypeProperties.ConnectionString;
                        linkedService = new Models.LinkedService(
                            dummyService.Name,
                            new Models.LinkedServiceProperties(service)
                        );
                    }

                    // init if it is a hd insight service
                    if (dummyService is ComputeService)
                    {
                        var service = new Models.HDInsightLinkedService();
                        linkedService = new Models.LinkedService(
                            dummyService.Name,
                            new Models.LinkedServiceProperties(service)
                        );
                    }

                    linkedServices.Add(linkedService);
                }
            }
        }
    }
}