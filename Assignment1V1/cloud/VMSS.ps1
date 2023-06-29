az group create --location eastus --name vmssrg

az vmss create `
  --resource-group vmssrg `
  --name webServerScaleSet `
  --image UbuntuLTS `
  --upgrade-policy-mode automatic `
  --custom-data cloud-init.yml `
  --admin-username azureuser `
  --generate-ssh-keys

 az network lb probe create `
  --lb-name webServerScaleSetLB `
  --resource-group vmssrg `
  --name webServerHealth `
  --port 80 `
  --protocol Http `
  --path /

 az network lb rule create `
  --resource-group vmssrg `
  --name webServerLoadBalancerRuleWeb `
  --lb-name webServerScaleSetLB `
  --probe-name webServerHealth `
  --backend-pool-name webServerScaleSetLBBEPool `
  --backend-port 80 `
  --frontend-ip-name loadBalancerFrontEnd `
  --frontend-port 80 `
  --protocol tcp

