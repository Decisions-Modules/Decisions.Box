using System.Runtime.Serialization;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    public enum BoxSharedLinkAccessType
    {
        open,
        company,
        collaborators
    }

    [DataContract]
    public enum BoxSyncStateType
    {
        synced,
        not_synced,
        partially_synced
    }

    [DataContract]
    public enum BoxSortBy
    {
        Type,
        Name,
        file_version_id,
        Id,
        policy_name,
        retention_policy_id,
        retention_policy_object_id,
        retention_policy_set_id,
        interacted_at
    }

    [DataContract]
    public enum BoxSortDirection
    {
        ASC,
        DESC
    }

    [DataContract]
    public enum MetadataUpdateOp
    {
        add,
        replace,
        remove,
        test,
        move,
        copy
    }

    [DataContract]
    public enum ResolutionStateType
    {
        completed,
        incomplete,
        approved,
        rejected
    }

    [DataContract]
    public enum MetadataTemplateUpdateOp
    {
        addEnumOption,
        addField,
        editField,
        editTemplate,
        editEnumOption,
        reorderEnumOptions,
        reorderFields,
        removeField,
        removeEnumOption
    }

    [DataContract]
    public enum UserEventsStreamType
    {
        all,
        changes,
        sync
    }

    [DataContract]
    public enum DispositionAction
    {
        permanently_delete,
        remove_retention
    }

    [DataContract]
    public enum BoxCompletionRule
    {
        all_assignees,

        any_assignee
    }
}