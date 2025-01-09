# Project MODELS

#### Project API ENDPOINTS
```js
{
  CreateProject: Project /user/{:id}/project
  UpdateProject: PUT /user/{:id}/update/project/{:id}
  DeleteProject: DELETE /user/{:id}/delete/{:id}
  GetAllProject: GET /projects
  GetProjectById: GET /projects/{:id}
  GetProjectByTitle: GET /projects/{:title}
  GetProjectByTopics: GET /projects/{:topicIds}
}
```

#### Project FUNCTIONS
```csharp
class Project
{
	ProjectResponse CreateProject(ProjectRequest Project);
  ProjectResponse UpdateProject(ProjectRequest Project);
  ProjectResponse UpdateSection(ProjectSection section);
	bool DeleteProject(Guid id);
  List<ProjectResponse> GetAllProject();
  ProjectResponse GetProjectById(Guid id);
  List<ProjectResponse> GetProjectByTitle(string title);
  List<ProjectResponse> GetProjectByTopics(string topics);
}
```

#### PROJECT REQUEST
```json
POST /user/{:id}/project
```
```json
{
  "srcLink": "https://github.com/saidul-islam-rajib/Dinner_Host",
  "postId": "6126960c-0e94-46d6-a270-e836bf767b6a",
  "date": "2024/12/04"
}
```


#### Project RESPONSE
```json
GET /project/{:id}
```

```json
{
    "projectId": "6126960c-0e94-46d6-a270-e836bf767b6a",
    "projectTitle": "HELPFUL TIPS TO BECOME SOFTWARE ENGINEER",   
    "abstract": "This tips will helpful for those people want...",
    "averageRating": 0,    
    "sections": [
      {
        "sectionId": "07e8b33e-5b0c-4fc2-b284-2c92e5dd3fd9",
        "title": "INTRODUCTION",
        "description": "1st section description will be here",
        "items": [
          {
            "itemId": "a1d50fea-36d7-490a-ba50-2b4879215e01",
            "itemTitle": "SELF OBSERVATION",
            "itemDescription": "1st item description will be here",
            "itemImages":"image link will be here."
          },
          {
            "itemId": "a1d50fea-36d7-490a-ba50-2b4879215e01",
            "itemTitle": "SELF OBSERVATION",
            "itemDescription": "1st item description will be here",
            "itemImages":"image link will be here."
          }
        ]
      }
    ],
    "srcLink": "https://github.com/saidul-islam-rajib/Dinner_Host",
    "userId": "123e4567-e89b-12d3-a456-426614174000",
    "topicIds": [1,2,3,4,5,...,10],
    "commentIds": [1,2,3,4,5,6,...,50],
    "date":"December 04, 2024",
    "createdDate": "04/12/2024",
    "updatedDate": "04/12/2024"
}
```
