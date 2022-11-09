using System;
using System.IO;
using System.Reflection;
using Humanizer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;

namespace MediatoRSourceGenerator 
{
    internal class Program
    {

        public static string ListOfProperties = "";
        public static string ListOfParameters = "";
        public static string ListOfPropertiesEqualsTheParameters = "";
        public static string ListOfMappingRequestToNewDatabaseModel = "";
        public static string ListOfMappingRequestToTheUpdatedDatabaseModel = "";

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


            ListOfParameters = "";
            ListOfProperties = "";
            ListOfPropertiesEqualsTheParameters = "";

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



            ListOfParameters = "";
            ListOfProperties = "";
            ListOfPropertiesEqualsTheParameters = "";

            GenerateUpdateCommand(
            AppsettingDataModel,
            TheNameSpace: "CM.Library.Events.Country",
            DataModelName: "Country",
            DataModelNamespace: "CM.Library.DataModels.MetaData;",
            DataModelClass: "CountryDataModel",
            ListOfProperties: ref ListOfProperties,
            ClaimsPrincipalIfTrue: true,
            ListOfParameters: ref ListOfParameters,
            ListOfPropertiesEqualsTheParameters: ref ListOfPropertiesEqualsTheParameters,
            "/Users/omarwasfi/Documents/GitHub/SkateMall/src/CM/Library/Events/Country"
            );

            ListOfParameters = "";
            ListOfProperties = "";
            ListOfPropertiesEqualsTheParameters = "";

            GenerateDeleteCommand(
            AppsettingDataModel,
            TheNameSpace: "CM.Library.Events.Country",
            DataModelName: "Country",
            DataModelNamespace: "CM.Library.DataModels.MetaData;",
            DataModelClass: "CountryDataModel",
            ListOfProperties: ref ListOfProperties,
            ClaimsPrincipalIfTrue: true,
            ListOfParameters: ref ListOfParameters,
            ListOfPropertiesEqualsTheParameters: ref ListOfPropertiesEqualsTheParameters,
            "/Users/omarwasfi/Documents/GitHub/SkateMall/src/CM/Library/Events/Country"
            );

            ListOfMappingRequestToNewDatabaseModel = "";

            GenerateAddCommandHandler(
            AppsettingDataModel,
            TheNameSpace: "CM.Library.Events.Country",
            DataModelName: "Country",
            DataModelNamespace: "CM.Library.DataModels.MetaData;",
            DataModelClass: "CountryDataModel",
            ListOfMappingRequestToNewDatabaseModel: ref ListOfMappingRequestToNewDatabaseModel,
            "/Users/omarwasfi/Documents/GitHub/SkateMall/src/CM/Library/Events/Country"
            );

            GenerateAddCommandValidator(
            AppsettingDataModel,
            TheNameSpace: "CM.Library.Events.Country",
            DataModelName: "Country",
            DataModelNamespace: "CM.Library.DataModels.MetaData;",
            DataModelClass: "CountryDataModel",
            "/Users/omarwasfi/Documents/GitHub/SkateMall/src/CM/Library/Events/Country");

            ListOfMappingRequestToTheUpdatedDatabaseModel = "";

            GenerateUpdateCommandHandler(
                AppsettingDataModel,
                TheNameSpace: "CM.Library.Events.Country",
                DataModelName: "Country",
                DataModelNamespace: "CM.Library.DataModels.MetaData;",
                DataModelClass: "CountryDataModel",
                ListOfMappingRequestToTheUpdatedDatabaseModel: ref ListOfMappingRequestToTheUpdatedDatabaseModel,
                "/Users/omarwasfi/Documents/GitHub/SkateMall/src/CM/Library/Events/Country"
);

            GenerateUpdateCommandValidator(
               AppsettingDataModel,
               TheNameSpace: "CM.Library.Events.Country",
               DataModelName: "Country",
               DataModelNamespace: "CM.Library.DataModels.MetaData;",
               DataModelClass: "CountryDataModel",
               "/Users/omarwasfi/Documents/GitHub/SkateMall/src/CM/Library/Events/Country");

            GenerateDaleteCommandHandler(
               AppsettingDataModel,
               TheNameSpace: "CM.Library.Events.Country",
               DataModelName: "Country",
               DataModelNamespace: "CM.Library.DataModels.MetaData;",
               DataModelClass: "CountryDataModel",
               "/Users/omarwasfi/Documents/GitHub/SkateMall/src/CM/Library/Events/Country");


            GenerateDeleteCommandValidator(
               AppsettingDataModel,
               TheNameSpace: "CM.Library.Events.Country",
               DataModelName: "Country",
               DataModelNamespace: "CM.Library.DataModels.MetaData;",
               DataModelClass: "CountryDataModel",
               "/Users/omarwasfi/Documents/GitHub/SkateMall/src/CM/Library/Events/Country");

            GenerateGetByIdQuery(
               AppsettingDataModel,
               TheNameSpace: "CM.Library.Queries.Country",
               DataModelName: "Country",
               DataModelNamespace: "CM.Library.DataModels.MetaData;",
               DataModelClass: "CountryDataModel",
               "/Users/omarwasfi/Documents/GitHub/SkateMall/src/CM/Library/Queries/Country");


            GenerateGetQuery(
              AppsettingDataModel,
              TheNameSpace: "CM.Library.Queries.Country",
              DataModelName: "Country",
              DataModelNamespace: "CM.Library.DataModels.MetaData;",
              DataModelClass: "CountryDataModel",
              "/Users/omarwasfi/Documents/GitHub/SkateMall/src/CM/Library/Queries/Country");


            GenerateGetQueryHandler(
              AppsettingDataModel,
              TheNameSpace: "CM.Library.Queries.Country",
              DataModelName: "Country",
              DataModelNamespace: "CM.Library.DataModels.MetaData;",
              DataModelClass: "CountryDataModel",
              "/Users/omarwasfi/Documents/GitHub/SkateMall/src/CM/Library/Queries/Country");


            GenerateGetByIdQueryHandler(
              AppsettingDataModel,
              TheNameSpace: "CM.Library.Queries.Country",
              DataModelName: "Country",
              DataModelNamespace: "CM.Library.DataModels.MetaData;",
              DataModelClass: "CountryDataModel",
              "/Users/omarwasfi/Documents/GitHub/SkateMall/src/CM/Library/Queries/Country");
        }



        public static void updateListOfProperties(string typeName , string propertyName)
        {
            ListOfProperties += $"public {typeName} {propertyName} {{ get; set; }}\n ";
        }


        public static void updateListOfParameters(CM.Library.DataModels.MetaData.CountryDataModel countryDataModel, PropertyInfo property, string descricaoName, string typeName,bool skipCommaAtTheBegin = false)
        {
            string destinationWord = descricaoName;
            destinationWord = string.Concat(destinationWord[0].ToString().ToLower(), destinationWord.AsSpan(1));

            if (property == countryDataModel.GetType().GetProperties().First<PropertyInfo>() || skipCommaAtTheBegin)
            {
                ListOfParameters += $"{typeName} {destinationWord}";
            }
            else
            {
                ListOfParameters += $", {typeName} {destinationWord} ";
            }
        }

        public  static void updateListOfPropertiesEqualsTheParameters(string descricaoName)
        {
            string destinationWord = descricaoName;
            destinationWord = string.Concat(destinationWord[0].ToString().ToLower(), destinationWord.AsSpan(1));

            ListOfPropertiesEqualsTheParameters += $" this.{descricaoName} = {destinationWord}; \n ";
        }

        private static void UpdateListOfMappingRequestToNewDatabaseModel(string DataModelName, string descricaoName)
        {
            ListOfMappingRequestToNewDatabaseModel += $"{string.Concat(DataModelName[0].ToString().ToLower(), DataModelName.AsSpan(1))}DataModel.{descricaoName} = request.{descricaoName};\n";
        }

        private static void UpdateListOfMappingRequestToTheUpdatedDatabaseModel(string DataModelName, string descricaoName)
        {
            ListOfMappingRequestToTheUpdatedDatabaseModel += $"selected{DataModelName}DataModel.{descricaoName} = request.{descricaoName};\n";
        }


        public static void GenerateAddCommand(AppsettingDataModel appsettingDataModel,
             string TheNameSpace, string DataModelName, string DataModelNamespace,
             string DataModelClass,ref string ListOfProperties, bool ClaimsPrincipalIfTrue,
             ref string ListOfParameters,ref  string ListOfPropertiesEqualsTheParameters,
             string FilePath
            )
        {

            CM.Library.DataModels.MetaData.CountryDataModel countryDataModel = new CM.Library.DataModels.MetaData.CountryDataModel();

            bool skipCommaAtTheBegin = true;

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
                    continue;
                }
                if (descricao.Name.Equals("Deleted"))
                {
                    continue;
                }
                if (descricao.Name.Equals("Id"))
                {
                    continue;
                }

                updateListOfProperties(typeName, descricao.Name);
                updateListOfParameters(countryDataModel, property, descricao.Name, typeName, skipCommaAtTheBegin: skipCommaAtTheBegin);
                skipCommaAtTheBegin = false;
                updateListOfPropertiesEqualsTheParameters(descricao.Name);

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


        public static void GenerateUpdateCommand(AppsettingDataModel appsettingDataModel,
             string TheNameSpace, string DataModelName, string DataModelNamespace,
             string DataModelClass, ref string ListOfProperties, bool ClaimsPrincipalIfTrue,
             ref string ListOfParameters, ref string ListOfPropertiesEqualsTheParameters,
             string FilePath
            )
        {



            CM.Library.DataModels.MetaData.CountryDataModel countryDataModel = new CM.Library.DataModels.MetaData.CountryDataModel();

         


            foreach (PropertyInfo property in countryDataModel.GetType().GetProperties())
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

                updateListOfProperties(typeName, descricao.Name);
                updateListOfParameters(countryDataModel, property, descricao.Name, typeName);
                updateListOfPropertiesEqualsTheParameters(descricao.Name);

            }

            if (ClaimsPrincipalIfTrue)
            {
                ListOfProperties += "public ClaimsPrincipal ClaimsPrincipal { get; set; }\n";
                ListOfParameters += $", ClaimsPrincipal claimsPrincipal  ";
                ListOfPropertiesEqualsTheParameters += "this.ClaimsPrincipal = claimsPrincipal;\n";
            }

            string UpdateCommandTemplate = $@"
            using System;
            using CM.Library.DataModels.BusinessModels;
            using MediatR;
            using System.Security.Claims;
            using {DataModelNamespace}

            namespace {TheNameSpace}
            {{
    
                    public class Update{DataModelName}Command : IRequest<{DataModelClass}>
                    {{
                        {ListOfProperties}
        

                        public Update{DataModelName}Command({ListOfParameters})
                        {{
                            {ListOfPropertiesEqualsTheParameters}

                        }}
                    }}
    
            }}

                ";

            Console.WriteLine(UpdateCommandTemplate);

            File.WriteAllText($"{FilePath}/Update{DataModelName}Command.cs", UpdateCommandTemplate);


        }

        public static void GenerateDeleteCommand(AppsettingDataModel appsettingDataModel,
             string TheNameSpace, string DataModelName, string DataModelNamespace,
             string DataModelClass, ref string ListOfProperties, bool ClaimsPrincipalIfTrue,
             ref string ListOfParameters, ref string ListOfPropertiesEqualsTheParameters,
             string FilePath
            )
        {



            CM.Library.DataModels.MetaData.CountryDataModel countryDataModel = new CM.Library.DataModels.MetaData.CountryDataModel();




            foreach (PropertyInfo property in countryDataModel.GetType().GetProperties())
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
                if (descricao.Name.Equals("Id"))
                {
                    updateListOfProperties(typeName, descricao.Name);
                    updateListOfParameters(countryDataModel, property, descricao.Name, typeName);
                    updateListOfPropertiesEqualsTheParameters(descricao.Name);
                }

                

            }

            if (ClaimsPrincipalIfTrue)
            {
                ListOfProperties += "public ClaimsPrincipal ClaimsPrincipal { get; set; }\n";
                ListOfParameters += $", ClaimsPrincipal claimsPrincipal  ";
                ListOfPropertiesEqualsTheParameters += "this.ClaimsPrincipal = claimsPrincipal;\n";
            }

            string DeleteCommandTemplate = $@"
using System;
using CM.Library.DataModels.BusinessModels;
using MediatR;
using System.Security.Claims;
using {DataModelNamespace}

namespace {TheNameSpace}
{{
    
    public class Delete{DataModelName}Command : IRequest<{DataModelClass}>
    {{
         {ListOfProperties}
        

         public Delete{DataModelName}Command({ListOfParameters})
         {{
            {ListOfPropertiesEqualsTheParameters}

         }}
    }}
    
}}

                ";

            Console.WriteLine(DeleteCommandTemplate);

            File.WriteAllText($"{FilePath}/Delete{DataModelName}Command.cs", DeleteCommandTemplate);


        }


        public static void GenerateAddCommandHandler(AppsettingDataModel appsettingDataModel,
             string TheNameSpace, string DataModelName, string DataModelNamespace,
             string DataModelClass,
             ref string ListOfMappingRequestToNewDatabaseModel,
             string FilePath
            )
                {



                    CM.Library.DataModels.MetaData.CountryDataModel countryDataModel = new CM.Library.DataModels.MetaData.CountryDataModel();




                    foreach (PropertyInfo property in countryDataModel.GetType().GetProperties())
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
                        if (descricao.Name.Equals("Deleted"))
                        {
                            continue;
                        }
                        if (descricao.Name.Equals("Id"))
                        {
                            continue;
                        }


                        UpdateListOfMappingRequestToNewDatabaseModel(DataModelName, descricao.Name);

                    }


                    string AddCommandHandlerTemplate = $@"
        using System;
        using System.Security.Claims;
        using System.Threading;
        using System.Threading.Tasks;
        using CM.Library.DataModels.BusinessModels;
        using CM.Library.DBContexts;
        using MediatR;
        using {DataModelNamespace}


        namespace {TheNameSpace}
        {{
            public class Add{DataModelName}CommandHandler : IRequestHandler<Add{DataModelName}Command,{DataModelClass}>
            {{
                private readonly CurrentStateDBContext _currentStateDBContext;
                private readonly IMediator _mediator;


                public Add{DataModelName}CommandHandler(IMediator mediator,CurrentStateDBContext currentStateDBContext)
                {{
                    this._currentStateDBContext = currentStateDBContext;
                    this._mediator = mediator;

                }}

                public async Task<{DataModelClass}> Handle(Add{DataModelName}Command request, CancellationToken cancellationToken)
                {{

                    {DataModelClass} {string.Concat(DataModelName[0].ToString().ToLower(), DataModelName.AsSpan(1))}DataModel = new {DataModelClass}();

                    {ListOfMappingRequestToNewDatabaseModel}

                    await _currentStateDBContext.AddAsync({string.Concat(DataModelName[0].ToString().ToLower(), DataModelName.AsSpan(1))}DataModel);
                    await _currentStateDBContext.SaveChangesAsync();

                    return {string.Concat(DataModelName[0].ToString().ToLower(), DataModelName.AsSpan(1))}DataModel;
                }}
            }}
        }}



                        ";

                    Console.WriteLine(AddCommandHandlerTemplate);

                    File.WriteAllText($"{FilePath}/Add{DataModelName}CommandHandler.cs", AddCommandHandlerTemplate);


                }

        public static void GenerateAddCommandValidator(AppsettingDataModel appsettingDataModel,
    string TheNameSpace, string DataModelName, string DataModelNamespace,
    string DataModelClass,
    string FilePath,
    bool CheckIfTheIdExcitingInTheDatabase = true,
    bool CheckIfTheCurrentUserAdminOrManager = true
    )
        {

            string AddCommandValidatorTemplate = $@"
using System;
using CM.Library.DataModels;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using CM.Library.Queries.Person;
using CM.Library.Queries.Roles;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using CM.Library.Queries.{DataModelName};
using {DataModelNamespace}

namespace {TheNameSpace}
{{
    public class Add{DataModelName}CommandValidator : AbstractValidator<Add{DataModelName}Command>
    {{
        private readonly IMediator _mediator;

        public Add{DataModelName}CommandValidator(IMediator mediator)
        {{
            _mediator = mediator;

            CascadeMode = CascadeMode.Stop;



            RuleFor(x => x).MustAsync(async (Add{DataModelName}Command, cancellation) => {{
                return await IsTheAuthorizedUserIsAdminstratorOrManager(Add{DataModelName}Command.ClaimsPrincipal);
            }}).WithMessage(""You must be an Administrator or Manager"");


        }}

        private async Task<bool> IsTheAuthorizedUserIsAdminstratorOrManager(ClaimsPrincipal claimsPrincipal)
        {{
            PersonDataModel authorizedPerson = await _mediator.Send(new GetTheAuthorizedPersonQuery(claimsPrincipal));

            List<IdentityRole> roles = await _mediator.Send(new GetPersonRolesQuery(authorizedPerson.Id));

            if (roles.Find(x => x.Id == ""Administrator"") != null)
            {{
                return true;
            }}
            else if (roles.Find(x => x.Id == ""Manager"") != null)
            {{
                return true;
            }}
            else
            {{
                return false;
            }}

        }}


    }}
}}




                            ";

            Console.WriteLine(AddCommandValidatorTemplate);

            File.WriteAllText($"{FilePath}/Add{DataModelName}CommandValidator.cs", AddCommandValidatorTemplate);


        }


        public static void GenerateUpdateCommandHandler(AppsettingDataModel appsettingDataModel,
            string TheNameSpace, string DataModelName, string DataModelNamespace,
            string DataModelClass,
            ref string ListOfMappingRequestToTheUpdatedDatabaseModel,
            string FilePath
            )
                    {



                        CM.Library.DataModels.MetaData.CountryDataModel countryDataModel = new CM.Library.DataModels.MetaData.CountryDataModel();




                        foreach (PropertyInfo property in countryDataModel.GetType().GetProperties())
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
                            if (descricao.Name.Equals("Id"))
                            {
                                continue;
                            }



                            UpdateListOfMappingRequestToTheUpdatedDatabaseModel(DataModelName, descricao.Name);

                        }


                        string AddCommandHandlerTemplate = $@"
            using System;
            using System.Security.Claims;
            using System.Threading;
            using System.Threading.Tasks;
            using CM.Library.DataModels.BusinessModels;
            using CM.Library.DBContexts;
            using MediatR;
using CM.Library.Queries.{DataModelName};

            using {DataModelNamespace}


            namespace {TheNameSpace}
            {{
                public class Update{DataModelName}CommandHandler : IRequestHandler<Update{DataModelName}Command,{DataModelClass}>
                {{
                    private readonly CurrentStateDBContext _currentStateDBContext;

                    private readonly IMediator _mediator;

                    public Update{DataModelName}CommandHandler(CurrentStateDBContext currentStateDBContext,IMediator mediator)
                    {{
                        this._currentStateDBContext = currentStateDBContext;

                        this._mediator = mediator;
                    }}

                    public async Task<{DataModelClass}> Handle(Update{DataModelName}Command request, CancellationToken cancellationToken)
                    {{
                        {DataModelClass} selected{DataModelName}DataModel = await _mediator.Send(new Get{DataModelName}ByIdQuery(request.Id));

                        {ListOfMappingRequestToTheUpdatedDatabaseModel}

                        _currentStateDBContext.Update(selected{DataModelName}DataModel);
                        await _currentStateDBContext.SaveChangesAsync();

                        return selected{DataModelName}DataModel;
                    }}
                }}
            }}


                            ";

                        Console.WriteLine(AddCommandHandlerTemplate);

                        File.WriteAllText($"{FilePath}/Update{DataModelName}CommandHandler.cs", AddCommandHandlerTemplate);


                    }

        public static void GenerateUpdateCommandValidator(AppsettingDataModel appsettingDataModel,
    string TheNameSpace, string DataModelName, string DataModelNamespace,
    string DataModelClass,
    string FilePath,
    bool CheckIfTheIdExcitingInTheDatabase = true,
    bool CheckIfTheCurrentUserAdminOrManager = true
    )
        {


            string UpdateCommandValidatorTemplate = $@"
using System;
using CM.Library.DataModels;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using CM.Library.Queries.Person;
using CM.Library.Queries.Roles;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using CM.Library.Queries.{DataModelName};
using {DataModelNamespace}

namespace {TheNameSpace}
{{
    public class Update{DataModelName}CommandValidator : AbstractValidator<Update{DataModelName}Command>
    {{
        private readonly IMediator _mediator;

        public Update{DataModelName}CommandValidator(IMediator mediator)
        {{
            _mediator = mediator;

            CascadeMode = CascadeMode.Stop;


            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage(""The Id is Empty !"");

            RuleFor(x => x).MustAsync(async (Update{DataModelName}Command, cancellation) => {{
                return await IsTheAuthorizedUserIsAdminstratorOrManager(Update{DataModelName}Command.ClaimsPrincipal);
            }}).WithMessage(""You must be an Administrator or Manager"");

            RuleFor(x => x).MustAsync(async (Update{DataModelName}Command, cancellation) => {{
                return await IsTheIdExistingInTheDatabase(Update{DataModelName}Command.Id);
            }}).WithMessage(""This Id is not existing !"");
        }}

        private async Task<bool> IsTheAuthorizedUserIsAdminstratorOrManager(ClaimsPrincipal claimsPrincipal)
        {{
            PersonDataModel authorizedPerson = await _mediator.Send(new GetTheAuthorizedPersonQuery(claimsPrincipal));

            List<IdentityRole> roles = await _mediator.Send(new GetPersonRolesQuery(authorizedPerson.Id));

            if (roles.Find(x => x.Id == ""Administrator"") != null)
            {{
                return true;
            }}
            else if (roles.Find(x => x.Id == ""Manager"") != null)
            {{
                return true;
            }}
            else
            {{
                return false;
            }}

        }}

        private async Task<bool> IsTheIdExistingInTheDatabase(string id)
        {{
            {DataModelClass} {DataModelClass.Camelize()} = await _mediator.Send(new Get{DataModelName}ByIdQuery(id));
            

            if ({DataModelClass.Camelize()} != null)
            {{
                return true;
            }}
            else
            {{
                return false;
            }}

        }}

    }}
}}




                            ";

            Console.WriteLine(UpdateCommandValidatorTemplate);

            File.WriteAllText($"{FilePath}/Update{DataModelName}CommandValidator.cs", UpdateCommandValidatorTemplate);


        }



        public static void GenerateDaleteCommandHandler(AppsettingDataModel appsettingDataModel,
            string TheNameSpace, string DataModelName, string DataModelNamespace,
            string DataModelClass,
            string FilePath
            )
                    {



                        CM.Library.DataModels.MetaData.CountryDataModel countryDataModel = new CM.Library.DataModels.MetaData.CountryDataModel();




                        foreach (PropertyInfo property in countryDataModel.GetType().GetProperties())
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
                            if (descricao.Name.Equals("Id"))
                            {
                                continue;
                            }



                            UpdateListOfMappingRequestToTheUpdatedDatabaseModel(DataModelName, descricao.Name);

                        }


                        string AddCommandHandlerTemplate = $@"
            using System;
            using System.Security.Claims;
            using System.Threading;
            using System.Threading.Tasks;
            using CM.Library.DataModels.BusinessModels;
            using CM.Library.DBContexts;
            using MediatR;
using CM.Library.Queries.{DataModelName};

            using {DataModelNamespace}


            namespace {TheNameSpace}
            {{
                public class Delete{DataModelName}CommandHandler : IRequestHandler<Delete{DataModelName}Command,{DataModelClass}>
                {{
                    private readonly CurrentStateDBContext _currentStateDBContext;

                    private readonly IMediator _mediator;

                    public Delete{DataModelName}CommandHandler(CurrentStateDBContext currentStateDBContext,IMediator mediator)
                    {{
                        this._currentStateDBContext = currentStateDBContext;

                        this._mediator = mediator;
                    }}

                    public async Task<{DataModelClass}> Handle(Delete{DataModelName}Command request, CancellationToken cancellationToken)
                    {{
                        {DataModelClass} selected{DataModelName}DataModel = await _mediator.Send(new Get{DataModelName}ByIdQuery(request.Id));

                        selected{DataModelName}DataModel.Deleted = true;

                        _currentStateDBContext.Update(selected{DataModelName}DataModel);
                        await _currentStateDBContext.SaveChangesAsync();

                        return selected{DataModelName}DataModel;
                    }}
                }}
            }}


                            ";

                        Console.WriteLine(AddCommandHandlerTemplate);

                        File.WriteAllText($"{FilePath}/Delete{DataModelName}CommandHandler.cs", AddCommandHandlerTemplate);


                    }

        public static void GenerateDeleteCommandValidator(AppsettingDataModel appsettingDataModel,
            string TheNameSpace, string DataModelName, string DataModelNamespace,
            string DataModelClass,
            string FilePath,
            bool CheckIfTheIdExcitingInTheDatabase = true,
            bool CheckIfTheCurrentUserAdminOrManager = true
            )
        {

            string DeleteCommandValidatorTemplate = $@"
using System;
using CM.Library.DataModels;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using CM.Library.Queries.Person;
using CM.Library.Queries.Roles;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using CM.Library.Queries.{DataModelName};
using {DataModelNamespace}

namespace {TheNameSpace}
{{
    public class Delete{DataModelName}CommandValidator : AbstractValidator<Delete{DataModelName}Command>
    {{
        private readonly IMediator _mediator;

        public Delete{DataModelName}CommandValidator(IMediator mediator)
        {{
            _mediator = mediator;

            CascadeMode = CascadeMode.Stop;


            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage(""The Id is Empty !"");

            RuleFor(x => x).MustAsync(async (Delete{DataModelName}Command, cancellation) => {{
                return await IsTheAuthorizedUserIsAdminstratorOrManager(Delete{DataModelName}Command.ClaimsPrincipal);
            }}).WithMessage(""You must be an Administrator or Manager"");

            RuleFor(x => x).MustAsync(async (Delete{DataModelName}Command, cancellation) => {{
                return await IsTheIdExistingInTheDatabase(Delete{DataModelName}Command.Id);
            }}).WithMessage(""This Id is not existing !"");
        }}

        private async Task<bool> IsTheAuthorizedUserIsAdminstratorOrManager(ClaimsPrincipal claimsPrincipal)
        {{
            PersonDataModel authorizedPerson = await _mediator.Send(new GetTheAuthorizedPersonQuery(claimsPrincipal));

            List<IdentityRole> roles = await _mediator.Send(new GetPersonRolesQuery(authorizedPerson.Id));

            if (roles.Find(x => x.Id == ""Administrator"") != null)
            {{
                return true;
            }}
            else if (roles.Find(x => x.Id == ""Manager"") != null)
            {{
                return true;
            }}
            else
            {{
                return false;
            }}

        }}

        private async Task<bool> IsTheIdExistingInTheDatabase(string id)
        {{
            {DataModelClass} {DataModelClass.Camelize()} = await _mediator.Send(new Get{DataModelName}ByIdQuery(id));
            

            if ({DataModelClass.Camelize()} != null)
            {{
                return true;
            }}
            else
            {{
                return false;
            }}

        }}

    }}
}}




                            ";

            Console.WriteLine(DeleteCommandValidatorTemplate);

            File.WriteAllText($"{FilePath}/Delete{DataModelName}CommandValidator.cs", DeleteCommandValidatorTemplate);


        }


        public static void GenerateGetByIdQuery(AppsettingDataModel appsettingDataModel,
            string TheNameSpace, string DataModelName, string DataModelNamespace,
            string DataModelClass,
            string FilePath
            )
                    {


                        string AddCommandHandlerTemplate = $@"
            using System;
            using MediatR;
            using {DataModelNamespace}


            namespace {TheNameSpace}
            {{
	            public class Get{DataModelName}ByIdQuery : IRequest<{DataModelClass}>
	            {{

                    public string Id {{ get; set; }}


                    public Get{DataModelName}ByIdQuery(string id)
                    {{
                        this.Id = id;
                    }}

	            }}
            }}



                            ";

                        Console.WriteLine(AddCommandHandlerTemplate);

                        File.WriteAllText($"{FilePath}/Get{DataModelName}ByIdQuery.cs", AddCommandHandlerTemplate);


                    }


        public static void GenerateGetQuery(AppsettingDataModel appsettingDataModel,
            string TheNameSpace, string DataModelName, string DataModelNamespace,
            string DataModelClass,
            string FilePath
            )
                    {


                        string AddCommandHandlerTemplate = $@"
            using System;
            using System.Collections.Generic;
            using CM.Library.DataModels.BusinessModels;
            using MediatR;
            using {DataModelNamespace}


            namespace {TheNameSpace}
            {{
                public class Get{DataModelName.Pluralize()}Query : IRequest<List<{DataModelClass}>>
                {{

                    public Get{DataModelName.Pluralize()}Query()
                    {{
                    }}
                }}
            }}


                            ";

                        Console.WriteLine(AddCommandHandlerTemplate);

                        File.WriteAllText($"{FilePath}/Get{DataModelName.Pluralize()}Query.cs", AddCommandHandlerTemplate);


                    }


        public static void GenerateGetQueryHandler(AppsettingDataModel appsettingDataModel,
                string TheNameSpace, string DataModelName, string DataModelNamespace,
                string DataModelClass,
                string FilePath
                )
        {


            string AddCommandHandlerTemplate = $@"
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CM.Library.DataModels.BusinessModels;
using CM.Library.DBContexts;
using MediatR;
using {DataModelNamespace}


namespace {TheNameSpace}
{{
    public class Get{DataModelName.Pluralize()}QueryHandler : IRequestHandler<Get{DataModelName.Pluralize()}Query,List<{DataModelClass}>>
    {{

        private readonly CurrentStateDBContext _currentStateDBContext;


        public Get{DataModelName.Pluralize()}QueryHandler(CurrentStateDBContext currentStateDBContext)
        {{
            this._currentStateDBContext = currentStateDBContext;
        }}


        public async Task<List<{DataModelClass}>> Handle(Get{DataModelName.Pluralize()}Query request, CancellationToken cancellationToken)
        {{
            List<{DataModelClass}> {DataModelName.Pluralize().Camelize()} = await _currentStateDBContext.{DataModelName.Pluralize()}.ToListAsync();

            return {DataModelName.Pluralize().Camelize()};
        }}
    }}
}}




                ";

            Console.WriteLine(AddCommandHandlerTemplate);

            File.WriteAllText($"{FilePath}/Get{DataModelName.Pluralize()}QueryHandler.cs", AddCommandHandlerTemplate);


        }



        public static void GenerateGetByIdQueryHandler(AppsettingDataModel appsettingDataModel,
            string TheNameSpace, string DataModelName, string DataModelNamespace,
            string DataModelClass,
            string FilePath
            )
            {


                string AddCommandHandlerTemplate = $@"


    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using CM.Library.DataModels.BusinessModels;
    using CM.Library.DBContexts;
    using MediatR;
    using {DataModelNamespace}


    namespace {TheNameSpace}
    {{
        public class Get{DataModelName}ByIdQueryHandler : IRequestHandler<Get{DataModelName}ByIdQuery,{DataModelClass}>
        {{

            private readonly CurrentStateDBContext _currentStateDBContext;


            public Get{DataModelName}ByIdQueryHandler(CurrentStateDBContext currentStateDBContext)
            {{
                this._currentStateDBContext = currentStateDBContext;
            }}


            public async Task<{DataModelName}DataModel> Handle(Get{DataModelName}ByIdQuery request, CancellationToken cancellationToken)
            {{
                {DataModelClass} {DataModelName.Camelize()} = await _currentStateDBContext.{DataModelName.Pluralize()}.FindAsync(request.Id);


                return {DataModelName.Camelize()};
            }}
        }}
    }}

                    ";

                Console.WriteLine(AddCommandHandlerTemplate);

                File.WriteAllText($"{FilePath}/Get{DataModelName}ByIdQueryHandler.cs", AddCommandHandlerTemplate);


            }


    }
}