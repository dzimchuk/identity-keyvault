## Set KeyVault name as an environment variable:

- KeyVaultName

## Authenticate using a principal

- AZURE_CLIENT_ID
- AZURE_CLIENT_SECRET
- AZURE_TENANT_ID

## Authenticate from Visual Studio or using a system-assigned identity

Nothing to be done.

## Authenticate using user-assigned managed identity

Set `UserAssignedClientId` environment variable.

## Running docker

docker run --rm -it -p 5002:80 -e ASPNETCORE_URLS="http://+" -e ASPNETCORE_ENVIRONMENT=Staging -e ASPNETCORE_FORWARDEDHEADERS_ENABLED=true -v %APPDATA%\microsoft\UserSecrets\:/root/.microsoft/usersecrets keyvaulttest:latest

## Deploying to Kubernetes using Helm (local cluster)

helm upgrade \
    --install \
    --create-namespace \
    --atomic \
    --wait \
    --namespace keyvault-test \
    keyvaulttest \
    ./kubernetes/keyvaulttest \
    --set registry= \
    --set env.KeyVaultName= \
    --set env.AZURE_CLIENT_ID=    \
    --set env.AZURE_CLIENT_SECRET=    \
    --set env.AZURE_TENANT_ID=

## Accessing Cluster IP service through the proxy:

http://localhost:8001/api/v1/namespaces/keyvault-test/services/keyvault-test-app:80/proxy/test

## Deploying to Kubernetes using Helm (AKS)

helm upgrade \
    --install \
    --create-namespace \
    --atomic \
    --wait \
    --namespace keyvault-test \
    keyvaulttest \
    ./kubernetes/keyvaulttest \
    --set registry= \
    --set env.KeyVaultName= \
    --set env.UserAssignedClientId= \
    --set dns.name=keyvaulttest.51.138.82.127.nip.io
