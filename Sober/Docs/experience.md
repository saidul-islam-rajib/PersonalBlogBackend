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
POST /user/{:id}/experience
```
```json
{
  "companyName": "ASA International Management Services Limited",
  "companyLogo": "logo link will be here",
  "designation": "Junior Software Engineer",
  "currentEmployee": false,
  "startDate": "2024/12/04",
  "endDate": "2024/12/04",
  "isFullTimeEmployee": true,
  "skills": [
    {
      "skillName": "Data structure & Algorithms"
    },
    {      
      "skillName": "Computer Networks"
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
  "experienceId": "123e4567-e89b-12d3-a456-426614174000",
  "companyName": "ASA International Management Services Limited",
  "companyLogo": "logo link will be here",
  "designation": "Junior Software Engineer",
  "currentEmployee": "Current Employee",
  "startDate": "2024/12/04",
  "endDate": "2024/12/04",
  "isFullTimeEmployee": "Full Time / Part Time",
  "skills": [
    {
      "skillId": "123e4567-e89b-12d3-a456-426614174000",
      "name": "Data structure & Algorithms"
    },
    {
      "skillId": "123e4567-e89b-12d3-a456-426614174000",
      "name": "Computer Networks"
    }
  ],
  "createdDate": "2024/12/04",
  "updatedDate": "2024/12/04"
}
```
