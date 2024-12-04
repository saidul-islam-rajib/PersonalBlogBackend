# PUBLICATION MODELS

#### PUBLICATION API ENDPOINTS
```js
{
  CreatePublication: POST /user/{:id}/publication
  UpdatePublication: PUT /user/{:id}/update/publication/{:id}
  DeletePublication: DELETE /user/{:id}/delete/{:id}
  GetAllPublication: GET /publications
  GetPublicationByTitle: GET /publications/{:title}
}
```

#### PUBLICATION FUNCTIONS
```csharp
class Publication
{
	PublicationResponse CreatePublication(PublicationRequest Publication);
  PublicationResponse UpdatePublication(PublicationRequest Publication);
	bool DeletePublication(Guid id);
  List<PublicationResponse> GetAllPublication();
  List<PublicationResponse> GetPublicationByTitle(string title);
}
```

#### PUBLICATION REQUEST
```json
POST /user/{:id}/publication
```
```json
{
  "title": "logo link will be here",
  "journalName": "Bachelor in Computer Science & Engineering",
  "abstraction": "short description will be here.", 
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


#### PUBLICATION RESPONSE
```json
GET /publication/{:id}
```

```json
{
  "publicationId": "123e4567-e89b-12d3-a456-426614174000",
  "title": "logo link will be here",
  "journalName": "Bachelor in Computer Science & Engineering",
  "abstraction": "short description will be here.", 
  "skills": [
    {
      "skillName": "Networking"
    },
    {      
      "skillName": "Networking"
    }
  ]
}
```
