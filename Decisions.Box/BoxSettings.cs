using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Box.V2;
using Box.V2.Auth;
using Box.V2.Config;
using Box.V2.JWTAuth;
using DecisionsFramework;
using DecisionsFramework.Data.DataTypes;
using DecisionsFramework.Data.ORMapper;
using DecisionsFramework.Design.ConfigurationStorage;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using DecisionsFramework.Design.Properties;
using DecisionsFramework.ServiceLayer;
using DecisionsFramework.ServiceLayer.Actions;
using DecisionsFramework.ServiceLayer.Actions.Common;
using DecisionsFramework.ServiceLayer.Services.Accounts;
using DecisionsFramework.ServiceLayer.Services.Accounts.ActiveDirectory;
using DecisionsFramework.ServiceLayer.Services.Administration;
using DecisionsFramework.ServiceLayer.Services.ExternalServiceReference;
using DecisionsFramework.ServiceLayer.Services.Folder;
using DecisionsFramework.ServiceLayer.Utilities;

namespace Decisions.Box;

[ORMEntity("box_settings")]
[DataContract]
[Writable]
public class BoxSettings : AbstractModuleSettings, IInitializable, INotifyPropertyChanged, IValidationSource
{
     // Client ID
     [ORMField]
     private string clientId;

     [DataMember]
     [WritableValue]
     [PropertyHiddenByValue(nameof(UseJsonAuthFile), true, true)]
     public string ClientId
     {
         get => clientId;
         set
         {
             clientId = value;
             OnPropertyChanged(nameof(ClientId));
         }
     }
    
    // Client Secret
    [ORMField]
    private string clientSecret;

    [DataMember]
    [WritableValue]
    [PropertyHiddenByValue(nameof(UseJsonAuthFile), true, true)]
    public string ClientSecret
    {
        get => clientSecret;
        set
        {
            clientSecret = value;
            OnPropertyChanged(nameof(ClientSecret));
        }
    }
    
    // Private Key
    [ORMField]
    private string privateKey;

    [DataMember]
    [WritableValue]
    [PropertyHiddenByValue(nameof(UseDeveloperToken), true, true)]
    [PropertyHiddenByValue(nameof(UseJsonAuthFile), true, true)]
    public string PrivateKey
    {
        get => privateKey;
        set
        {
            privateKey = value;
            OnPropertyChanged(nameof(PrivateKey));
        }
    }
    
    // Private Key Password
    [ORMField]
    private string privateKeyPassword;

    [DataMember]
    [WritableValue]
    [PropertyHiddenByValue(nameof(UseDeveloperToken), true, true)]
    [PropertyHiddenByValue(nameof(UseJsonAuthFile), true, true)]
    public string PrivateKeyPassword
    {
        get => privateKeyPassword;
        set
        {
            privateKeyPassword = value;
            OnPropertyChanged(nameof(PrivateKeyPassword));
        }
    }
    
    // Public Key ID
    [ORMField]
    private string publicKeyId;

    [DataMember]
    [WritableValue]
    [PropertyHiddenByValue(nameof(UseDeveloperToken), true, true)]
    [PropertyHiddenByValue(nameof(UseJsonAuthFile), true, true)]
    public string PublicKeyId
    {
        get => publicKeyId;
        set
        {
            publicKeyId = value;
            OnPropertyChanged(nameof(PublicKeyId));
        }
    }
    
    // Enterprise ID
    [ORMField]
    private string enterpriseId;
    
    [DataMember]
    [WritableValue]
    [PropertyHiddenByValue(nameof(UseDeveloperToken), true, true)]
    [PropertyHiddenByValue(nameof(UseJsonAuthFile), true, true)]
    public string EnterpriseId
    {
        get => enterpriseId;
        set
        {
            enterpriseId = value;
            OnPropertyChanged(nameof(EnterpriseId));
        }
    }
    
    // Use Developer Token for authentication
    [ORMField]
    private bool useDeveloperToken;
    
    [DataMember]
    [WritableValue]
    [PropertyClassification(0, "Use Developer Token", new string[] { "Alternate Authentication" })]
    public bool UseDeveloperToken
    {
        get { return useDeveloperToken; }
        set
        {
            useDeveloperToken = value;
            if (useDeveloperToken)
                UseJsonAuthFile = false;

            OnPropertyChanged(nameof(UseJsonAuthFile));
            OnPropertyChanged(nameof(UseDeveloperToken));
            OnPropertyChanged(nameof(ClientId));
            OnPropertyChanged(nameof(clientSecret));
            OnPropertyChanged(nameof(PrivateKey));
            OnPropertyChanged(nameof(PrivateKeyPassword));
            OnPropertyChanged(nameof(PublicKeyId));
            OnPropertyChanged(nameof(EnterpriseId));
            OnPropertyChanged(nameof(DeveloperToken));
            OnPropertyChanged(nameof(JsonConfig));
        }
    }
        
    // Developer Token
    [ORMField]
    private string developerToken;

    [DataMember]    
    [WritableValue]
    [PropertyHiddenByValue(nameof(UseDeveloperToken), true, false)]
    public string DeveloperToken
    {
        get => developerToken;
        set
        {
            developerToken = value;
            OnPropertyChanged(nameof(DeveloperToken));
        }
    }

    // Use JSON configuration file for authentication
    [ORMField]
    private bool useJsonAuthFile;
    
    [DataMember]
    [WritableValue]
    [PropertyClassification(0, "Use JSON Authentication File", new string[] { "Alternate Authentication" })]
    public bool UseJsonAuthFile
    {
        get => useJsonAuthFile;
        set
        {
            useJsonAuthFile = value;
            if (UseJsonAuthFile)
                UseDeveloperToken = false;

            OnPropertyChanged(nameof(UseJsonAuthFile));
            OnPropertyChanged(nameof(UseDeveloperToken));
            OnPropertyChanged(nameof(ClientId));
            OnPropertyChanged(nameof(clientSecret));
            OnPropertyChanged(nameof(PrivateKey));
            OnPropertyChanged(nameof(PrivateKeyPassword));
            OnPropertyChanged(nameof(PublicKeyId));
            OnPropertyChanged(nameof(EnterpriseId));
            OnPropertyChanged(nameof(DeveloperToken));
            OnPropertyChanged(nameof(JsonConfig));
        }
    }
    
    // JsonContent
    [ORMField(typeof(ORMBinaryFieldConverter))]
    [WritableValue]
    private FileData jsonConfig;

    [DataMember]
    [WritableValue]
    [PropertyHiddenByValue(nameof(UseJsonAuthFile), true, false)]
    public FileData JsonConfig
    {
        get => jsonConfig;
        set
        {
            jsonConfig = value;
            OnPropertyChanged(nameof(JsonConfig));
        }
    }

    public BoxSettings()
    {
        this.EntityName = "Box Module Settings";
    }
    
    public BoxClient GetClient()
    {
        const string shortError = "Please configure the Box Module Settings.";

        if (!UseJsonAuthFile)
        {
            if (string.IsNullOrEmpty(ClientId) || string.IsNullOrEmpty(ClientSecret))
                throw new ArgumentNullException($"Missing Client Id or Client Secret. {shortError}");
        }
        
        // Use developer token 
        if (UseDeveloperToken)
        {
            if (string.IsNullOrEmpty(DeveloperToken))
                throw new ArgumentNullException($"Missing Developer Token. {shortError}");
            
            return GetDeveloperClient();
        }

        if (UseJsonAuthFile)
        {
            if (JsonConfig == null)
                throw new ArgumentNullException($"JSON Keyfile nis missing. {shortError}");
            
            return GetJsonClient();
        }

        if (string.IsNullOrEmpty(EnterpriseId) || string.IsNullOrEmpty(PrivateKey) ||
            string.IsNullOrEmpty(PrivateKeyPassword) || string.IsNullOrEmpty(PublicKeyId))
            throw new ArgumentNullException($"Missing configuratiguration. {shortError}");
        
        return GetFullClient();
    }

    private BoxClient GetDeveloperClient()
    {
        var config = new BoxConfigBuilder(ClientId, ClientSecret, new Uri("http://localhost")).Build();
        var session = new OAuthSession(DeveloperToken, "N/A", 3600, "bearer");
        return new BoxClient(config, session);
    }

    private BoxClient GetJsonClient()
    {
        var jsonContent = Encoding.UTF8.GetString(jsonConfig.Contents);
        var config = BoxConfigBuilder.CreateFromJsonString(jsonContent).Build();
        var session = new BoxJWTAuth(config);
        
        var t = Task.Run(async () =>
        {
            var adminToken = await session.AdminTokenAsync(); //valid for 60 minutes so should be cached and re-used
            return session.AdminClient(adminToken);
        });
        t.Wait();

        return t.Result;
    }

    private BoxClient GetFullClient()
    {
        var boxConfig = new BoxConfigBuilder(ClientId, ClientSecret, EnterpriseId, PrivateKey, PrivateKeyPassword, PublicKeyId).Build();
        var boxJwt = new BoxJWTAuth(boxConfig);

        var t = Task.Run(async () =>
        {
            var adminToken = await boxJwt.AdminTokenAsync(); //valid for 60 minutes so should be cached and re-used
            return boxJwt.AdminClient(adminToken);
        });
        t.Wait();

        return t.Result;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void Initialize()
    {
        ModuleSettingsAccessor<BoxSettings>.GetSettings();
    }

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    public ValidationIssue[] GetValidationIssues()
    {
        List<ValidationIssue> issues = new List<ValidationIssue>();

        if (!UseJsonAuthFile)
        {
            if (string.IsNullOrEmpty(ClientId))
                issues.Add(new ValidationIssue((object)ClientId, "You must specify Client Id."));
            
            if (string.IsNullOrEmpty(ClientSecret))
                issues.Add(new ValidationIssue((object)ClientSecret, $"You must specify Client Secret."));
        }
        
        if (UseDeveloperToken)
        {
            if (string.IsNullOrEmpty(DeveloperToken))
                issues.Add(new ValidationIssue((object)DeveloperToken, "You must specify Developer Token."));
        }
        
        if (UseJsonAuthFile)
        {
            if (JsonConfig == null)
                issues.Add(new ValidationIssue(JsonConfig, "You must provide the JSON configuration file provided in your administration console."));
            
            string extension = System.IO.Path.GetExtension(JsonConfig?.FileName) ?? "";
            if (!extension.EndsWith("json", StringComparison.OrdinalIgnoreCase))
                issues.Add(new ValidationIssue(this, "Unexpected File Extension. The Configuration File must be a valid JSON file with a .json extension."));
        }
        else if (!useDeveloperToken)
        {
            if (string.IsNullOrEmpty(EnterpriseId))
                issues.Add(new ValidationIssue((object)EnterpriseId, "You must specify Enterprise Id."));

            if (string.IsNullOrEmpty(PrivateKey))
                issues.Add(new ValidationIssue((object)PrivateKey, "You must specify a Private Key"));

            if (string.IsNullOrEmpty(PrivateKeyPassword))
                issues.Add(new ValidationIssue((object)PrivateKeyPassword, "You must specify a Private Key password."));
            
            if (string.IsNullOrEmpty(PublicKeyId))
                issues.Add(new ValidationIssue((object)PublicKeyId, "You must specify a Public Key."));
        }

        return issues.ToArray();
    }
    
    public override BaseActionType[] GetActions(AbstractUserContext userContext, EntityActionType[] types)
    {
        List<BaseActionType> actions = new List<BaseActionType>();

        Account userAccount = userContext.GetAccount();

        FolderPermission permission = FolderService.GetAccountEffectivePermissionInternal(
            new SystemUserContext(), this.EntityFolderID, userAccount.AccountID);

        bool canAdministrate = FolderPermission.CanAdministrate == (FolderPermission.CanAdministrate & permission) ||
                                userAccount.GetUserRights<PortalAdministratorModuleRight>() != null ||
                                userAccount.IsAdministrator();

        if (canAdministrate)
        {
            actions.Add(new EditEntityAction(typeof(BoxSettings), "Edit", "Edits Box.com Module Settings") 
            {
                IsDefaultGridAction = true,
                OkActionName = "SAVE",
                CancelActionName = null
            });
        }

        return actions.ToArray();
    }
    
    private void SaveSettings(AbstractUserContext userContext, object obj)
    {
        BoxSettings settings = obj as BoxSettings;
        ORM<BoxSettings> orm = new ORM<BoxSettings>();
        orm.Store(settings);
    }
}