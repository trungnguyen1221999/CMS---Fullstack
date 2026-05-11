# Project Requirements: Admin Dashboard & News Portal

## 1. Admin Panel (Back-office)
- **Role Management**: Define, create, and manage system roles.
- **User Management**: 
    - Assign and modify permissions.
    - Update user credentials (Email, Password).
- **Category Management**: Create and organize news categories.
- **News/Post Management**: 
    - Content moderation (Approve/Reject posts).
    - Publish and schedule articles.
- **Series Management**: Manage collections of related articles.
- **Comment Management**: Monitor, hide, or delete user comments.

---

## 2. News Portal (Front-end)
- **Homepage**: Display featured content and latest news layout.
- **Post Listings**: View articles filtered by categories or tags.
- **Post Details**: Detailed view of article content, images, and videos.
- **Authentication**: 
    - Standard Sign-up & Login.
    - Social Authentication (**Google, Facebook** integration).

---

## 3. User Personal Dashboard
- **Published Posts**: View a history of articles submitted by the user.
- **Published Series**: View and manage the user's article series.
- **Royalty/Earnings Info**: Track payments and revenue for contributed content.
- **Notifications**: Real-time alerts for system updates or post status.

## 4. Post Life Cycle (Workflow Diagram)
stateDiagram
  direction TB
  [*] --> Draft
  Draft --> Canceled:Cancel
  Canceled --> [*]
  Draft --> WaitingForApproval:Submit for approval
  WaitingForApproval --> Rejected:Reject with a comment
  Rejected --> Draft:Assign to creator
  WaitingForApproval --> Published:Approve and publish now
  WaitingForApproval --> WaitingForPublished:Approve and schedule to publish
  WaitingForPublished --> Published:Published (auto or manual)
  Published --> [*]