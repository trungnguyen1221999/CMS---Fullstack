## Database Design (ERD)

The following diagram illustrates the database structure based on the system design (including Identity Tables and Content Management Tables):

```mermaid
erDiagram
    AppUsers ||--o{ AppUserRoles : "has"
    AppRoles ||--o{ AppUserRoles : "assigned to"
    AppUsers ||--o{ AppUserClaims : "has"
    AppUsers ||--o{ AppUserLogins : "logs in with"
    AppUsers ||--o{ AppUserTokens : "owns"
    
    AppUsers ||--o{ Posts : "authors"
    AppUsers ||--o{ PostActivityLogs : "performs"
    AppUsers ||--o{ Series : "owns"

    PostCategories ||--o{ PostCategories : "parent/child"
    PostCategories ||--o{ Posts : "contains"
    
    Posts ||--o{ PostTags : "has"
    Tags ||--o{ PostTags : "categorizes"
    
    Posts ||--o{ PostInSeries : "part of"
    Series ||--o{ PostInSeries : "groups"
    
    Posts ||--o{ PostActivityLogs : "tracks"

    AppUsers {
        string Id
        string UserName
        string Email
        string FullName
        datetime DateCreated
        decimal RoyaltyBalance
    }

    Posts {
        string Id
        string Name
        string Slug
        string Content
        int Status
        decimal RoyaltyAmount
        string OwnerUserId
        string CategoryId
    }

    Series {
        string Id
        string Name
        string OwnerUserId
    }

    PostActivityLogs {
        int Id
        string PostId
        string FromStatus
        string ToStatus
        datetime DateCreated
        string UserId
    }