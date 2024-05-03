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

- Adding auth to a Swagger page
   
  https://swagger.io/docs/specification/authentication/

- Keycloak on Docker takes about 1 full minute to spin up before the login page is available.  Watching the logs help indicate when it is prepared.




| **Keycloack**													|
|	--- 														|
| **Realm**	| Name		| `dev-lab`								|
| **Client**| Id		| `dev-client`							|
|	 		| Name		| `Dev Client`							|
|	 		| Secret	| `6KjnpbA0Qlf2zLS6pVpiWPSKlLL5ZwHk`	|
| **User**	| Name		| `dev-user`							|
|	 		| Password	| `devuser`								|



