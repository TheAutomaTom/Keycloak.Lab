# Keycloak.Lab

## Docker Images: 

- Keycloak

	https://hub.docker.com/r/bitnami/keycloak

-	Postgres

	https://hub.docker.com/_/postgres

## Nugets:

- Keycloak.AuthServices

	https://nikiforovall.github.io/keycloak-authorization-services-dotnet/configuration/configuration-keycloak.html#create-realm

## Technical References & Notes

- Note: Keycloak on Docker takes about 1 full minute to spin up before the login page is available.  Watching the logs help indicate when it is prepared.

- Sample code provider by Nuget maintainer

  https://github.com/NikiforovAll/keycloak-authorization-services-dotnet/

- Adding auth to a Swagger page
   
  https://swagger.io/docs/specification/authentication/


- Setup notes 

	| **Keycloak**													|
	|	--- 														|
	| **Realm**	| Name		| `dev-lab`								|
	| **Client**| Id		| `dev-client`							|
	|	 		| Name		| `Dev Client`							|
	|	 		| Secret	| `6KjnpbA0Qlf2zLS6pVpiWPSKlLL5ZwHk`	|
	| **User 1**| Name		| `dev-user`							|
	|	 		| Password	| `devuser`								|
	|	 		| Roles	    | none								    |
	| **User 2**| Name		| `dev-reader`							|
	|	 		| Password	| `devuser`								|
	|	 		| Roles	    | `Reader`							    |
	| **User 3**| Name		| `dev-writer`							|
	|	 		| Password	| `devuser`								|
	|	 		| Roles	    | `Writer`							    |
	| **User 4**| Name		| `dev-read-and-write`					|
	|	 		| Password	| `devuser`								|
	|	 		| Roles	    | `Reader`, `Writer`				    |
	| **User 5**| Name		| `dev-admin`							|
	|	 		| Password	| `devuser`								|
	|	 		| Roles	    | `Admin`							    |



