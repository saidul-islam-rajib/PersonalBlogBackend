# Skill MODELS

#### Skill API ENDPOINTS
```js
{
  CreateSkill: POST /user/{:id}/skill
  GetAllSkill: GET /USER/{:id}/skill/{:id}
  DeleteSkill: DELETE /user/{:id}/delete/{:id}
}
```

#### Skill FUNCTIONS
```csharp
class Skill
{
	SkillResponse CreateSkill(SkillRequest Skill);
	bool DeleteSkill(Guid id);
  List<SkillResponse> GetAllSkill();
}
```

#### Skill REQUEST
```json
POST /user/{:id}/skill
```
```json
{
  "skillName": "Data Structure & Algorithm"
}
```


#### Skill RESPONSE
```json
GET /skill/{:id}
```

```json
{
  "skillId": "123e4567-e89b-12d3-a456-426614174000",
  "skillName": "ASA International Management Services Limited"  
}
```
