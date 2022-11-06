using System;
using System.IO;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;

namespace MediatoRSourceGenerator 
{
    internal class Program
    {

        public static string ListOfProperties = "";
        public static string ListOfParameters = "";
        public static string ListOfPropertiesEqualsTheParameters = "";

        public static AppsettingDataModel AppsettingDataModel;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello - Here is the current app settings!");

            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();


            AppsettingDataModel = new AppsettingDataModel();
            AppsettingDataModel.ProjectPath = config["ProjectPath"];
            AppsettingDataModel.GenerateAddCommand = bool.Parse(config["GenerateAddCommand"]);
            AppsettingDataModel.GenerateAddCommandHandler = bool.Parse(config["GenerateAddCommandHandler"]);
            AppsettingDataModel.GenerateUpdateCommand = bool.Parse(config["GenerateUpdateCommand"]);
            AppsettingDataModel.GenerateUpdateCommandHandler = bool.Parse(config["GenerateUpdateCommandHandler"]);
            AppsettingDataModel.GenerateUpdateCommandValidator = bool.Parse(config["GenerateUpdateCommandValidator"]);
            AppsettingDataModel.GenerateDeleteCommand = bool.Parse(config["GenerateDeleteCommand"]);
            AppsettingDataModel.GenerateDeleteCommandHandler = bool.Parse(config["GenerateDeleteCommandHandler"]);
            AppsettingDataModel.GenerateDeleteCommandValidator = bool.Parse(config["GenerateDeleteCommandValidator"]);
            AppsettingDataModel.AddClaimsPrincipal = bool.Parse(config["AddClaimsPrincipal"]);
            AppsettingDataModel.DBContextClass = config["DBContextClass"];
            AppsettingDataModel.DataModelName = config["DataModelName"];
            AppsettingDataModel.DataModelNameAtTheDBContext = config["DataModelNameAtTheDBContext"];


            int counter = 1;
            foreach (var property in AppsettingDataModel.GetType().GetProperties())
            {
                var descricao = property;
                var type = property.PropertyType.AssemblyQualifiedName;

                Console.WriteLine($"{counter,-2} - {descricao.Name,-50} {property.GetValue(AppsettingDataModel),-30} || Type: {type} "  );

                counter++;

            }


            GenerateAddCommand(
                AppsettingDataModel,
                TheNameSpace: "CM.Library.Events.Country",
                DataModelName: "Country",
                DataModelNamespace: "CM.Library.DataModels.MetaData;",
                DataModelClass: "CountryDataModel",
                ListOfProperties:ref ListOfProperties,
                ClaimsPrincipalIfTrue: true,
                ListOfParameters:ref ListOfParameters,
                ListOfPropertiesEqualsTheParameters:ref ListOfPropertiesEqualsTheParameters,
                "/Users/omarwasfi/Documents/GitHub/SkateMall/src/CM/Library/Events/Country"
                );

        }



        public static void updateListOfProperties(string typeName , string propertyName)
        {
            ListOfProperties += $"public {typeName} {propertyName} {{ get; set; }}\n ";
        }


        public static void updateListOfParameters(CM.Library.DataModels.MetaData.CountryDataModel countryDataModel, PropertyInfo property, PropertyInfo descricao, string typeName)
        {
            string destinationWord = descricao.Name;
            destinationWord = string.Concat(destinationWord[0].ToString().ToLower(), destinationWord.AsSpan(1));

            if (property == countryDataModel.GetType().GetProperties().First<PropertyInfo>())
            {
                ListOfParameters += $"{typeName} {destinationWord}";
            }
            else
            {
                ListOfParameters += $", {typeName} {destinationWord} ";
            }
        }

        public  static void updateListOfPropertiesEqualsTheParameters(PropertyInfo descricao)
        {
            string destinationWord = descricao.Name;
            destinationWord = string.Concat(destinationWord[0].ToString().ToLower(), destinationWord.AsSpan(1));

            ListOfPropertiesEqualsTheParameters += $" this.{descricao.Name} = {destinationWord}; \n ";
        }


        public static void GenerateAddCommand(AppsettingDataModel appsettingDataModel,
             string TheNameSpace, string DataModelName, string DataModelNamespace,
             string DataModelClass,ref string ListOfProperties, bool ClaimsPrincipalIfTrue,
             ref string ListOfParameters,ref  string ListOfPropertiesEqualsTheParameters,
             string FilePath
            )
        {

            CM.Library.DataModels.MetaData.CountryDataModel countryDataModel = new CM.Library.DataModels.MetaData.CountryDataModel();

            foreach (var property in countryDataModel.GetType().GetProperties())
            {
                var descricao = property;
                var type = property.PropertyType.Name;
                string typeName = "";

                if (property.PropertyType == typeof(string))
                {
                    typeName = "string";
                }
                else if (property.PropertyType == typeof(bool))
                {
                    typeName = "bool";

                }
                else if (property.PropertyType == typeof(int))
                {
                    typeName = "int";

                }
                else if (property.PropertyType == typeof(double))
                {
                    typeName = "double";

                }
                else if (property.PropertyType == typeof(decimal))
                {
                    typeName = "decimal";

                }
                else if (property.PropertyType == typeof(float))
                {
                    typeName = "float";

                }
                else if (property.PropertyType == typeof(long))
                {
                    typeName = "long";

                }
                else if (property.PropertyType == typeof(char))
                {
                    typeName = "char";

                }
                else
                {
                    break;
                }
                if (descricao.Name.Contains("Deleted"))
                {
                    break;
                }

                updateListOfProperties(typeName, descricao.Name);
                updateListOfParameters(countryDataModel, property, descricao, typeName);
                updateListOfPropertiesEqualsTheParameters(descricao);

            }

            if (ClaimsPrincipalIfTrue)
            {
                ListOfProperties += "public ClaimsPrincipal ClaimsPrincipal { get; set; }\n";
                ListOfParameters += $", ClaimsPrincipal claimsPrincipal  ";
                ListOfPropertiesEqualsTheParameters += "this.ClaimsPrincipal = claimsPrincipal;\n";
            }

            string addCommandTemplate = $@"
            using System;
            using CM.Library.DataModels.BusinessModels;
            using MediatR;
            using System.Security.Claims;
            using {DataModelNamespace}

            namespace {TheNameSpace}
            {{
    
                    public class Add{DataModelName}Command : IRequest<{DataModelClass}>
                    {{
                        {ListOfProperties}
        

                        public Add{DataModelName}Command({ListOfParameters})
                        {{
                            {ListOfPropertiesEqualsTheParameters}

                        }}
                    }}
    
            }}

                ";

            Console.WriteLine(addCommandTemplate);

            File.WriteAllText($"{FilePath}/Add{DataModelName}Command.cs", addCommandTemplate);


        }
    }
}