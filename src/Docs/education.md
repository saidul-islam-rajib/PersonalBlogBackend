# EDUCATION MODELS

#### EDUCATION API ENDPOINTS
```js
{
  CreateEducation: POST /user/{:id}/education
  UpdateEducation: PUT /user/{:id}/update/education/{:id}
  DeleteEducation: DELETE /user/{:id}/delete/{:id}
  GetAllEducation: GET /educations
  GetEducationByTitle: GET /educations/{:title}
}
```

#### EDUCATION FUNCTIONS
```csharp
class Education
{
	EducationResponse CreateEducation(EducationRequest Education);
  EducationResponse UpdateEducation(EducationRequest Education);
	bool DeleteEducation(Guid id);
  List<EducationResponse> GetAllEducation();
  List<EducationResponse> GetEducationByTitle(string title);
}
```

#### EDUCATION REQUEST
```json
POST /user/{:id}/education
```
```json
{
  "instituteName": "DAFFODIL INTERNATIONAL UNIVERSITY",
  "instituteLogo": "logo link will be here",
  "department": "Bachelor in Computer Science & Engineering",
  "startDate": "2024/12/04",
  "endDate": "2024/12/04",  
  "skills": [
    {
      "skillId": "123e4567-e89b-12d3-a456-426614174000"
    },
    {      
      "skillId": "123e4567-e89b-12d3-a456-426614174000"
    }
  ]
}
```


#### EDUCATION RESPONSE
```json
GET /education/{:id}
```

```json
{
  "educationId": "123e4567-e89b-12d3-a456-426614174000",
  "instituteName": "ASA International Management Services Limited",
  "instituteLogo": "logo link will be here",
  "department": "Junior Software Engineer",
  "startDate": "2024/12/04",
  "endDate": "2024/12/04",  
  "skills": [
    {
      "skillName": "Data Structure & Algorithm"
    },
    {      
      "skillName": "Data Structure & Algorithm"
    }
  ]
}
```
