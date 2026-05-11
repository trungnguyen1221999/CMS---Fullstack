## Database Design (ERD)

```mermaid
graph LR
    subgraph Users
        Admin[Administrators]
        Mod[Moderators]
        Ed[Editors]
        Vis[Visitors]
    end

    subgraph "Server 3 (Admin App)"
        AdminApp[Admin Web Interface]
    end

    subgraph "Server 2 (Portal App)"
        PortalApp[News Portal Web]
    end

    subgraph "Server 1 (API Services)"
        API[Central Admin API]
    end

    subgraph "Server 4 (Database)"
        DB[(SQL Database)]
    end

    %% Flow
    Admin & Mod & Ed --> AdminApp
    Ed & Vis --> PortalApp

    AdminApp --> API
    PortalApp --> API
    API --> DB