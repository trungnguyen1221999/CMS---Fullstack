## Database Design (ERD)

The following diagram illustrates the database structure based on the system design (including Identity Tables and Content Management Tables):

```mermaid
erDiagram
    AppUsers ||--o{ AppUserRoles : ""
    AppRoles ||--o{ AppUserRoles : ""
    AppUsers ||--o{ AppUserClaims : ""
    AppUsers ||--o{ AppUserLogins : ""
    AppUsers ||--o{ AppUserTokens : ""
    AppRoles ||--o{ AppRoleClaims : ""

    AppUsers {
        Guid Id
        String FirstName
        String LastName
        Boolean IsActive
        String RefreshToken
        DateTime RefreshTokenExpiryTime
        DateTime DateCreated
        String UserName
        String NormalizedUserName
        String Email
        String NormalizedEmail
        Boolean EmailConfirmed
        String PasswordHash
        String SecurityStamp
        String ConcurrencyStamp
        String PhoneNumber
        Boolean PhoneNumberConfirmed
        Boolean TwoFactorEnabled
        DateTime LockoutEnd
        Boolean LockoutEnabled
        Int AccessFailedCount
        String Avatar
        DateTime Dob
        DateTime LastLoginDate
        DateTime VipExpireDate
        DateTime VipStartDate
    }

    AppRoles {
        Guid Id
        String DisplayName
        String Name
        String NormalizedName
        String ConcurrencyStamp
    }

    AppUserRoles {
        Guid UserId
        Guid RoleId
    }

    AppUserLogins {
        Guid UserId
        String LoginProvider
        String ProviderKey
        String ProviderDisplayName
    }

    AppUserTokens {
        Guid UserId
        String LoginProvider
        String Name
        String Value
    }

    AppUserClaims {
        Int Id
        Guid UserId
        String ClaimType
        String ClaimValue
    }

    AppRoleClaims {
        Int Id
        Guid RoleId
        String ClaimType
        String ClaimValue
    }

    erDiagram
    Posts ||--o{ PostTags : ""
    Tags ||--o{ PostTags : ""
    Posts ||--o{ PostInSeries : ""
    Series ||--o{ PostInSeries : ""
    Posts ||--o{ PostActivityLogs : ""
    PostCategories ||--o{ Posts : ""

    Series {
        Guid Id
        String Name
        String Description
        String Slug
        Boolean IsActive
        Int SortOrder
        String SeoKeywords
        String SeoDescription
        String Thumbnail
        String Content
        Guid OwnerUserId
    }

    PostInSeries {
        Guid PostId
        Guid SeriesId
        Int DisplayOrder
    }

    Tags {
        Guid Id
        String Name
    }

    Posts {
        Guid Id
        String Name
        String Slug
        String Description
        Guid CategoryId
        String Thumbnail
        String Content
        String Source
        String Status
        Int ViewCount
        String Tags
        String SeoKeywords
        String SeoDescription
        DateTime DateCreated
        DateTime DateModified
        Guid OwnerUserId
        Guid ApprovedUserId
        Boolean IsPaid
        Decimal RoyaltyAmount
    }

    PostTags {
        Guid PostId
        Guid TagId
    }

    PostCategories {
        Guid Id
        String Name
        String Slug
        Guid ParentId
        Boolean IsActive
        DateTime DateCreated
        DateTime DateModified
        String SeoKeywords
        String SeoDescription
        Int SortOrder
    }

    PostActivityLogs {
        Guid Id
        Guid PostId
        String FromStatus
        String ToStatus
        DateTime DateCreated
        String Note
        Guid UserId
    }