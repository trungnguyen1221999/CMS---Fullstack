## Database Design (ERD)

graph TD
    subgraph Users
        Admin[Administrators]
        Mod[Moderators]
        Ed[Editors]
        Vis[Visitors]
    end

    subgraph "Server 3 (UI Applications)"
        AdminApp[Admin Web App]
    end

    subgraph "Server 2 (UI Applications)"
        PortalApp[Portal Web App]
    end

    subgraph "Server 1 (API Services)"
        AdminAPI[Admin API]
    end

    subgraph "Server 4 (Data Storage)"
        DB[(Central Database)]
    end

    %% Connections
    Admin --> AdminApp
    Mod --> AdminApp
    Ed --> AdminApp
    
    Ed --> PortalApp
    Vis --> PortalApp

    AdminApp --> AdminAPI
    PortalApp --> AdminAPI
    
    AdminAPI --> DB