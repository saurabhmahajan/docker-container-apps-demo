az group create -l westus -n demo

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
sameple: 

> az container create --resource-group saurabh-demo --name democontainer --image mcr.microsoft.com/azuredocs/aci-helloworld:latest --dns-name-label aci-demo-$RANDOM --port 80
	------> pay attention to ipAddress -> fqdn ( Fully Qualified Domain Name)

> az container delete --resource-group saurabh-demo --name democontainer

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------


az acr create --resource-group demo --name saurabhacidemo --sku basic
	------> note the loginServer from the json output ( saurabhacidemo.azurecr.io )

az acr login --name saurabhacidemo

docker images

docker tag 30a2d6c8f7b7 saurabhacidemo.azurecr.io/hellodockerconsole:v1

docker push saurabhacidemo.azurecr.io/hellodockerconsole:v1

az acr repository list --name saurabhacidemo

$REGISTERY_NAME="saurabhacidemo"

$ACR_REGISTRY_ID = az acr show --name saurabhacidemo --query id --output tsv

$ACR_REGISTRY_ID = az acr show --name saurabhacidemo --query id --output tsv

$SP_PASSWORD = az ad sp create-for-rbac --name acr-demo-pull --scopes $ACR_REGISTRY_ID --role acrpull --query password --output tsv

$SP_APP_ID = az ad sp list --display-name acr-demo-pull --query [].appId --output tsv

az container create --resource-group demo --name democontainer --image saurabhacidemo.azurecr.io/hellodockerconsole:v1 --registry-username $SP_APP_ID --registry-password $SP_PASSWORD --dns-name aci-demo-2222 --port 80



---

ENV Variables

az container create --resource-group demo --name democontainerv3 --image saurabhacidemo.azurecr.io/hellodockerconsole:v2 --registry-username $SP_APP_ID --registry-password $SP_PASSWORD --dns-name aci-demo-444 --port 80 --environment-variables CLIENT_ID=ZZZ123
