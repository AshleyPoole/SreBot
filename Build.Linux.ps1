$tag = Get-Date -UFormat "%y%m%d%H-linux"
$latestTag = "latest-linux"
$imageName = "ashleypoole/srebotweb"

docker build -t "${imageName}:${tag}" -f ./Dockerfile.Linux .

docker tag "${imageName}:${tag}" "${imageName}:${latestTag}"

docker push "${imageName}:${tag}"
docker push "${imageName}:${latestTag}"