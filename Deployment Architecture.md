## Database Design (ERD)

```mermaid
graph TD
    %% Define Actors
    Admin_User[Administrators]
    Mod_User[Moderators]
    Ed_User[Editors]
    Vis_User[Visitors]

    %% Define UI Layer
    subgraph Server_3["Server 3 (UI Layer)"]
        AdminApp[Admin App]
    end

    subgraph Server_2["Server 2 (UI Layer)"]
        PortalApp[Portal App]
    end

    subgraph Mobile_Device["Client Device"]
        MobileApp[Mobile App]
    end

    %% Define API Layer
    subgraph Server_1["Server 1 (API Layer)"]
        AdminAPI[Admin API]
        Text_Service[Text Service]
        MobileAPI[Mobile API]
    end

    %% Define Data Layer
    subgraph Server_4["Server 4 (Data Layer)"]
        DB[(Database)]
    end

    %% Connections for Admin/Mod/Editor
    Admin_User --> AdminApp
    Mod_User --> AdminApp
    Ed_User --> AdminApp
    
    %% Connections for Portal
    Ed_User --> PortalApp
    Vis_User --> PortalApp

    %% Connections for Mobile
    Vis_User --> MobileApp

    %% Backend Flow
    AdminApp --> AdminAPI
    PortalApp --> AdminAPI
    
    MobileApp --> MobileAPI

    %% Data Flow
    AdminAPI --> DB
    MobileAPI --> DB

    %% Styling
    style AdminApp fill:#d1e7dd,stroke:#198754
    style PortalApp fill:#fff3cd,stroke:#ffc107
    style MobileApp fill:#f8d7da,stroke:#dc3545
    style AdminAPI fill:#cfe2ff,stroke:#0d6efd
    style MobileAPI fill:#cfe2ff,stroke:#0d6efd
    style DB fill:#6f42c1,stroke:#59359a,color:#fff