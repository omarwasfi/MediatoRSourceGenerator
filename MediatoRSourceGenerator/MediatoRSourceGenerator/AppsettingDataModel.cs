using System;
namespace MediatoRSourceGenerator
{
	public class AppsettingDataModel
	{
        public string ProjectPath { get; set; }
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
        public string DBContextClass { get; set; }
        public string DataModelName { get; set; }
        public string DataModelNameAtTheDBContext { get; set; }
    }
}

