using System;
namespace MediatoRSourceGenerator
{
	public class AppsettingDataModel
	{
        public bool GenerateAddCommand { get; set; }
        public bool GenerateAddCommandHandler { get; set; }
        public bool GenerateAddCommandValidator { get; set; }
        public bool GenerateUpdateCommand { get; set; }
        public bool GenerateUpdateCommandHandler { get; set; }
        public bool GenerateUpdateCommandValidator { get; set; }
        public bool GenerateDeleteCommand { get; set; }
        public bool GenerateDeleteCommandHandler { get; set; }
        public bool GenerateDeleteCommandValidator { get; set; }
        public bool AddClaimsPrincipal { get; set; }
        public string TheEventsNameSpace { get; set; }
        public string TheQueriesNameSpace { get; set; }
        public string DataModelName { get; set; }
        public string DataModelNamespace { get; set; }
        public string EventsFilePath { get; set; }
        public string QueriesFilePath { get; set; }
        public string DataModelClass { get; set; }
        public string DataModelClassWithNamespace { get; set; }
        public string DBContextClass { get; set; }
    }
}

