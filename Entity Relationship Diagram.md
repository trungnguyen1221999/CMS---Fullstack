## Database Design (ERD)

The following diagram illustrates the database structure based on the system design (including Identity Tables and Content Management Tables):

```mermaid
erDiagram
    AppUsers ||--o{ AppUserRoles : "User has roles"
    AppRoles ||--o{ AppUserRoles : "Role assigned to users"
    AppUsers ||--o{ AppUserClaims : "User claims"
    AppUsers ||--o{ AppUserLogins : "External logins"
    AppUsers ||--o{ AppUserTokens : "User tokens"
    AppRoles ||--o{ AppRoleClaims : "Role claims"

    AppUsers ||--o{ Posts : "OwnerUserId"
    AppUsers ||--o{ Series : "OwnerUserId"
    AppUsers ||--o{ PostActivityLogs : "UserId"

    PostCategories ||--o{ Posts : "CategoryId"
    Posts ||--o{ PostTags : "PostId"
    Tags ||--o{ PostTags : "TagId"
    
    Posts ||--o{ PostInSeries : "PostId"
    Series ||--o{ PostInSeries : "SeriesId"
    
    Posts ||--o{ PostActivityLogs : "PostId"

    AppUsers {
        Guid Id
        String FirstName
        String LastName
        Boolean IsActive
        String UserName
        String Email
        String PasswordHash
        DateTime DateCreated
        DateTime Dob
        DateTime VipExpireDate
    }

    Posts {
        Guid Id
        String Name
        String Slug
        String Content
        Guid CategoryId
        String Status
        Decimal RoyaltyAmount
        Guid OwnerUserId
        Guid ApprovedUserId
    }

    Series {
        Guid Id
        String Name
        String Description
        String Slug
        Guid OwnerUserId
    }

    PostCategories {
        Guid Id
        String Name
        String Slug
        Guid ParentId
        Boolean IsActive
    }

    PostActivityLogs {
        Guid Id
        Guid PostId
        String FromStatus
        String ToStatus
        String Note
        DateTime DateCreated
        Guid UserId
    }

    PostInSeries {
        Guid PostId
        Guid SeriesId
        Int DisplayOrder
    }