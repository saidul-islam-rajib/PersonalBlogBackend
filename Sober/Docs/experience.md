# Experience MODELS

#### Experience API ENDPOINTS
```js
{
  CreateExperience: POST /user/{:id}/experience
  UpdateExperience: PUT /user/{:id}/update/experience/{:id}
  DeleteExperience: DELETE /user/{:id}/delete/{:id}
  GetAllExperience: GET /experiences
  GetExperienceById: GET /experiences/{:id}
  GetExperienceByTitle: GET /experiences/{:title}
  GetExperienceByTopics: GET /experiences/{:topicIds}
}
```

#### Experience FUNCTIONS
```csharp
class Experience
{
	ExperienceResponse CreateExperience(ExperienceRequest Experience);
  ExperienceResponse UpdateExperience(ExperienceRequest Experience);
  ExperienceResponse UpdateSection(ExperienceSection section);
	bool DeleteExperience(Guid id);
  List<ExperienceResponse> GetAllExperience();
  ExperienceResponse GetExperienceById(Guid id);
  List<ExperienceResponse> GetExperienceByTitle(string title);
  List<ExperienceResponse> GetExperienceByTopics(string topics);
}
```

#### EXPERIENCE REQUEST
```json
POST /experience/user/{:userId}/create
GET /experience/get-all-experience
GET /experience/{:experienceId}
```
```json
{
  "companyName": "ASA International Management Services Limited",
  "shortName": "AMSL",
  "companyLogo": "test logo link",
  "designation": "Junior Software Engineer",
  "isCurrentEmployee": true,
  "startDate": "2024-12-10T10:19:16.685Z",
  "endDate": "2024-12-10T10:19:16.685Z",
  "isFullTimeEmployee": true,
  "skills": [
    {
      "skillName": "Bangladesh Studies"
    }
  ]
}
```


#### EXPERIENCE RESPONSE
```json
GET /experience/{:id}
```

```json
{
    "experienceId": "2e35486e-b587-4d27-b3de-08114b39b17e",
    "userId": "065c14d5-04a0-489b-8931-e000261be27b",
    "companyName": "ASA International Management Services Limited",
    "shortName": "AMSL",
    "companyLogo": "test logo link",
    "designation": "Junior Software Engineer",
    "isCurrentEmployee": true,
    "startDate": "2024-12-10T10:19:16.685Z",
    "endDate": "2024-12-10T10:19:16.685Z",
    "isFullTimeEmployee": true,
    "skills": [
        {
            "skillId": "f9ea3fb1-02cd-4f12-a8a6-8677f2e009ab",
            "skillName": "Bangladesh Studies"
        }
    ],
    "createdDate": "0001-01-01T00:00:00",
    "updatedDate": "0001-01-01T00:00:00"
}
```
